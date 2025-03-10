namespace ProjetosEspaciais.Modules
{
    public static class MissaoModule
    {
        public static void MapMissaoEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints
                        .MapGroup("/api/missao")
                        .WithTags("Missao");

            // I N S E R I R
            group.MapPost("/inserir", async ([FromServices] ApplicationDbContext context, [FromBody] MissaoDto novaMissao) =>
            {
                try
                {
                    // Validações de campos obrigatórios
                    if (string.IsNullOrWhiteSpace(novaMissao.Codinome))
                    {
                        return Results.BadRequest("O codinome da missão é obrigatório.");
                    }

                    if (string.IsNullOrWhiteSpace(novaMissao.Descricao))
                    {
                        return Results.BadRequest("A descrição da missão é obrigatória.");
                    }

                    if (string.IsNullOrWhiteSpace(novaMissao.Objetivo))
                    {
                        return Results.BadRequest("O objetivo da missão é obrigatório.");
                    }

                    if (string.IsNullOrWhiteSpace(novaMissao.DuracaoEstimada))
                    {
                        return Results.BadRequest("A duração estimada da missão é obrigatória.");
                    }

                    // Gera um novo ID se o ID atual for vazio
                    if (novaMissao.Id == Guid.Empty)
                    {
                        novaMissao = novaMissao with { Id = Guid.NewGuid() };
                    }

                    // Verifica se o ID já existe no banco de dados
                    var missaoExistente = await context.Missoes.FindAsync(novaMissao.Id);
                    if (missaoExistente != null)
                    {
                        return Results.Conflict("ID indisponível.");
                    }

                    // Verificar se o codinome já existe
                    var codinomeExistente = await context.Missoes
                        .FirstOrDefaultAsync(m => m.Codinome == novaMissao.Codinome);

                    if (codinomeExistente != null)
                    {
                        return Results.BadRequest("Já existe uma missão com este codinome.");
                    }

                    // Verificar se o veículo existe
                    var veiculo = await context.Veiculos.FindAsync(novaMissao.VeiculoId);
                    if (veiculo == null)
                    {
                        return Results.BadRequest("Veículo não encontrado.");
                    }

                    // Verificar se a plataforma existe
                    var plataforma = await context.Plataformas.FindAsync(novaMissao.PlataformaId);
                    if (plataforma == null)
                    {
                        return Results.BadRequest("Plataforma não encontrada.");
                    }

                    // Verificar se a equipe existe
                    var equipe = await context.Equipes.FindAsync(novaMissao.EquipeId);
                    if (equipe == null)
                    {
                        return Results.BadRequest("Equipe não encontrada.");
                    }

                    // novaMissao = novaMissao with
                    // {
                    //     TestesIds = novaMissao.TestesIds ?? new List<Guid>(),
                    //     DocumentosIds = novaMissao.DocumentosIds ?? new List<Guid>(),
                    //     LicencasIds = novaMissao.LicencasIds ?? new List<Guid>()
                    // };

                    var missao = Missao.Inserir(
                        novaMissao.Codinome,
                        novaMissao.Descricao,
                        novaMissao.TipoMissao,
                        novaMissao.Objetivo,
                        novaMissao.StatusMissao,
                        novaMissao.DuracaoEstimada,
                        novaMissao.CustoEstimado,
                        novaMissao.DataInicio,
                        novaMissao.DataTermino,
                        novaMissao.VeiculoId,
                        novaMissao.PlataformaId,
                        novaMissao.EquipeId,
                        novaMissao.MissaoLicencas
                    );

                    // Adiciona as Licenças associadas à missão
                    if (novaMissao.MissaoLicencas.Any())
                    {
                        var licencas = await context.Licencas
                                                    .Where(l => novaMissao.MissaoLicencas.Contains(l.Id))
                                                    .ToListAsync();

                        foreach (var licenca in licencas)
                        {
                            var missaoLicencas = MissaoLicencas.Inserir(missao.Id, licenca.Id);
                            context.MissaoLicencas.Add(missaoLicencas);
                        }
                    }

                    context.Missoes.Add(missao);
                    await context.SaveChangesAsync();

                    // Atualiza o DTO da missão com o ID gerado
                    novaMissao = novaMissao with { Id = missao.Id };

                    // Retorna uma resposta de sucesso com a missão criada
                    return Results.Created($"/api/missao/{novaMissao.Id}", new { mensagem = "Missão cadastrada com sucesso!", missao = novaMissao });
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: ex.ToString(), title: "Erro interno no servidor");
                }
            });

            // O B T E R    P O R    I D
            group.MapGet("/obter-por-id/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
            {
                if (id == Guid.Empty)
                {
                    return Results.BadRequest("Id inválido.");
                }

                var missao = await context.Missoes.FirstOrDefaultAsync(m => m.Id == id);

                if (missao is null)
                {
                    return Results.NotFound("Missão não encontrada.");
                }

                var missoesDto = new MissaoDto(
                    Codinome: missao.Codinome,
                    Descricao: missao.Descricao,
                    TipoMissao: missao.TipoMissao,
                    Objetivo: missao.Objetivo,
                    StatusMissao: missao.StatusMissao,
                    DuracaoEstimada: missao.DuracaoEstimada,
                    CustoEstimado: missao.CustoEstimado,
                    DataInicio: missao.DataInicio,
                    DataTermino: missao.DataTermino,  // Passando o DataTermino aqui corretamente
                    VeiculoId: missao.VeiculoId,
                    PlataformaId: missao.PlataformaId,
                    EquipeId: missao.EquipeId,
                    Id: missao.Id,
                    MissaoLicencas: missao.MissaoLicencas
                );


                return Results.Ok(missoesDto);
            });

            // L I S T A R
            group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
            {
                var missoes = await context.Missoes.ToListAsync();

                var missoesDto = new List<MissaoDto>();

                foreach (var missao in missoes)
                {
                    var missaoLicencas = await context.MissaoLicencas
                                                      .Where(m => m.MissaoId == missao.Id)
                                                      .Select(m => m.LicencaId)
                                                      .ToListAsync();

                    var missaoDto = new MissaoDto(
                        Codinome: missao.Codinome,
                        Descricao: missao.Descricao,
                        TipoMissao: missao.TipoMissao,
                        Objetivo: missao.Objetivo,
                        StatusMissao: missao.StatusMissao,
                        DuracaoEstimada: missao.DuracaoEstimada,
                        CustoEstimado: missao.CustoEstimado,
                        DataInicio: missao.DataInicio,
                        DataTermino: missao.DataTermino,
                        VeiculoId: missao.VeiculoId,
                        PlataformaId: missao.PlataformaId,
                        EquipeId: missao.EquipeId,
                        MissaoLicencas: missaoLicencas,
                        Id: missao.Id
                    );

                    missoesDto.Add(missaoDto);
                }

                return Results.Ok(missoesDto);
            });

            // // L I S T A R   L I C E N Ç A S
            // group.MapGet("/listar-missao-licencas/{missaoId}", async ([FromServices] ApplicationDbContext context, Guid missaoId) =>
            // {
            //     // Verifica se a missão existe
            //     var missaoLicencas = await context.MissaoLicencas
            //                                       //   .Include(ml => ml.Licenca)  // Inclui as informações da Licenca associada
            //                                       .Where(ml => ml.MissaoId == missaoId)
            //                                       .ToListAsync();

            //     if (!missaoLicencas.Any())
            //     {
            //         return Results.NotFound("Não há licenças associadas a essa missão.");
            //     }

            //     // Mapeia os dados das licenças associadas à missão
            //     var missaoLicencasDto = missaoLicencas.Select(ml => new LicencaDto
            //     (
            //         missaoLicencasDto.Id
            //     )
            //     {
            //         MissaoLicencaId = ml.Id,  // ID da relação MissaoLicenca
            //         LicencaId = ml.LicencaId, // ID da Licença
            //         TipoLicenca = ml.Licenca.TipoLicenca,
            //         NomeLicenca = ml.Licenca.Nome,
            //         NumeroLicenca = ml.Licenca.NumeroLicenca,
            //         OrgaoEmissor = ml.Licenca.OrgaoEmissor,
            //         DataEmissao = ml.Licenca.DataEmissao,
            //         DataValidade = ml.Licenca.DataValidade
            //     }).ToList();

            //     return Results.Ok(missaoLicencasDto);
            // });

            // A T U A L I Z A R
            group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] MissaoDto missaoAtualizada) =>
            {
                var missao = await context.Missoes.FindAsync(id);

                if (missao == null)
                {
                    return Results.NotFound("Missão não encontrada.");
                }

                missao = Missao.Atualizar(
                    missao,
                    missaoAtualizada.Codinome,
                    missaoAtualizada.Descricao,
                    missaoAtualizada.TipoMissao,
                    missaoAtualizada.Objetivo,
                    missaoAtualizada.StatusMissao,
                    missaoAtualizada.DuracaoEstimada,
                    missaoAtualizada.CustoEstimado,
                    missaoAtualizada.DataInicio,
                    missaoAtualizada.DataTermino
                );

                await context.SaveChangesAsync();

                return Results.NoContent();
            });


            // R E M O V E R
            group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
            {
                var missao = await context.Missoes.FindAsync(id);

                if (missao == null)
                {
                    return Results.NotFound("Missão não encontrada.");
                }

                missao = Missao.Deletar(missao);

                await context.SaveChangesAsync();

                // context.Missoes.Remove(missao);
                // await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
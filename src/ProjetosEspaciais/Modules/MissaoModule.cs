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

                    novaMissao = novaMissao with
                    {
                        TestesIds = novaMissao.TestesIds ?? new List<Guid>(),
                        DocumentosIds = novaMissao.DocumentosIds ?? new List<Guid>(),
                        LicencasIds = novaMissao.LicencasIds ?? new List<Guid>()
                    };

                    var missao = Missao.Inserir(
                        novaMissao.Codinome,
                        novaMissao.Descricao,
                        novaMissao.TipoMissao,
                        novaMissao.Objetivo,
                        novaMissao.StatusMissao,
                        novaMissao.DuracaoEstimada,
                        novaMissao.CustoEstimado,
                        novaMissao.DataInicio,
                        novaMissao.DataTermino ?? DateOnly.MinValue, // Aqui, DataTermino é do tipo DateOnly
                        novaMissao.VeiculoId,
                        novaMissao.PlataformaId,
                        novaMissao.EquipeId
                    );


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

                var missao = await context.Missoes
                    .Include(m => m.Veiculo)
                    .Include(m => m.Plataforma)
                    .Include(m => m.Equipe)
                    .Include(m => m.Testes)
                    .Include(m => m.Documentos)
                    .Include(m => m.Licencas)
                    .FirstOrDefaultAsync(m => m.Id == id);

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
                    TestesIds: missao.Testes.Select(t => t.Id).ToList(), // Passando lista de TestesIds
                    DocumentosIds: missao.Documentos.Select(d => d.Id).ToList(), // Passando lista de DocumentosIds
                    LicencasIds: missao.Licencas.Select(l => l.Id).ToList(), // Passando lista de LicencasIds
                    Id: missao.Id
                );


                return Results.Ok(missoesDto);
            });

            // L I S T A R
            group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
            {
                var missoes = await context.Missoes
                    .Include(m => m.Veiculo)
                    .Include(m => m.Plataforma)
                    .Include(m => m.Equipe)
                    .Include(m => m.Testes)
                    .Include(m => m.Documentos)
                    .Include(m => m.Licencas)
                    .ToListAsync();

                var missoesDto = missoes.Select(missao => new MissaoDto(
                    Codinome: missao.Codinome,
                    Descricao: missao.Descricao,
                    TipoMissao: missao.TipoMissao,
                    Objetivo: missao.Objetivo,
                    StatusMissao: missao.StatusMissao,
                    DuracaoEstimada: missao.DuracaoEstimada,
                    CustoEstimado: missao.CustoEstimado,
                    DataInicio: missao.DataInicio,
                    DataTermino: missao.DataTermino, // Passando o DataTermino aqui corretamente
                    VeiculoId: missao.VeiculoId,
                    PlataformaId: missao.PlataformaId,
                    EquipeId: missao.EquipeId,
                    TestesIds: missao.Testes.Select(t => t.Id).ToList(),  // Adicionando TestesIds
                    DocumentosIds: missao.Documentos.Select(d => d.Id).ToList(),  // Adicionando DocumentosIds
                    LicencasIds: missao.Licencas.Select(l => l.Id).ToList(),  // Adicionando LicencasIds
                    Id: missao.Id
                )).ToList();

                return Results.Ok(missoesDto);
            });

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
                    missaoAtualizada.DataTermino,
                    missaoAtualizada.TestesIds,   // Lista de Testes (Agora usando List<Guid>)
                    missaoAtualizada.DocumentosIds, // Lista de Documentos (Agora usando List<Guid>)
                    missaoAtualizada.LicencasIds   // Lista de Licenças (Agora usando List<Guid>)
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

                context.Missoes.Remove(missao);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
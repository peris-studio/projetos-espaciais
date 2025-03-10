namespace ProjetosEspaciais.Modules;

public static class TesteModule
{
    public static void MapTesteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
                    .MapGroup("/api/teste")
                    .WithTags("Teste");

        // I N S E R I R
        group.MapPost("/inserir", async ([FromServices] ApplicationDbContext context, [FromBody] TesteDto novoTeste) =>
        {
            try
            {
                // Validações de campos obrigatórios
                if (string.IsNullOrWhiteSpace(novoTeste.Objetivo))
                {
                    return Results.BadRequest("O objetivo do teste é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novoTeste.Resultado))
                {
                    return Results.BadRequest("O resultado do teste é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novoTeste.EquipamentoUtilizado))
                {
                    return Results.BadRequest("O equipamento utilizado é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novoTeste.ConclusaoRecomendacao))
                {
                    return Results.BadRequest("A conclusão/recomendação é obrigatória.");
                }

                // Criação do Teste
                var teste = Teste.Criar(
                    novoTeste.TipoTeste,
                    novoTeste.Objetivo,
                    novoTeste.DataRealizacao,
                    novoTeste.Resultado,
                    novoTeste.EquipamentoUtilizado,
                    novoTeste.ConclusaoRecomendacao,
                    novoTeste.LocalidadeId,
                    novoTeste.EquipeId,
                    novoTeste.PlataformaId
                );

                context.Testes.Add(teste);
                await context.SaveChangesAsync();

                return Results.Created($"/api/teste/{teste.Id}", new { mensagem = "Teste cadastrado com sucesso!", teste = novoTeste });
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

            var teste = await context.Testes
                .Include(t => t.Localidade)
                .Include(t => t.Equipe)
                .Include(t => t.Plataforma)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (teste == null)
            {
                return Results.NotFound("Teste não encontrado.");
            }

            var testeDto = new TesteDto(
                TipoTeste: teste.TipoTeste,
                Objetivo: teste.Objetivo,
                DataRealizacao: teste.DataRealizacao,
                Resultado: teste.Resultado,
                EquipamentoUtilizado: teste.EquipamentoUtilizado,
                ConclusaoRecomendacao: teste.ConclusaoRecomendacao,
                LocalidadeId: teste.LocalidadeId,
                EquipeId: teste.EquipeId,
                PlataformaId: teste.PlataformaId,
                Id: teste.Id
            );

            return Results.Ok(testeDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var testes = await context.Testes
                .Include(t => t.Localidade)
                .Include(t => t.Equipe)
                .Include(t => t.Plataforma)
                .ToListAsync();

            var testesDto = testes.Select(teste => new TesteDto(
                TipoTeste: teste.TipoTeste,
                Objetivo: teste.Objetivo,
                DataRealizacao: teste.DataRealizacao,
                Resultado: teste.Resultado,
                EquipamentoUtilizado: teste.EquipamentoUtilizado,
                ConclusaoRecomendacao: teste.ConclusaoRecomendacao,
                LocalidadeId: teste.LocalidadeId,
                EquipeId: teste.EquipeId,
                PlataformaId: teste.PlataformaId,
                Id: teste.Id
            )).ToList();

            return Results.Ok(testesDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] TesteDto testeAtualizado) =>
        {
            var teste = await context.Testes.FindAsync(id);

            if (teste == null)
            {
                return Results.NotFound("Teste não encontrado.");
            }

            try
            {
                // Verificação de campos obrigatórios
                if (string.IsNullOrWhiteSpace(testeAtualizado.Objetivo))
                {
                    return Results.BadRequest("O campo 'Objetivo' não pode ser nulo ou vazio.");
                }

                // Chamada ao método Atualizar, passando os valores do DTO
                teste.Atualizar(testeAtualizado.Objetivo,
                                testeAtualizado.Resultado,
                                testeAtualizado.EquipamentoUtilizado,
                                testeAtualizado.ConclusaoRecomendacao,
                                testeAtualizado.EquipeId,
                                testeAtualizado.PlataformaId
                );

                // Salvar mudanças no banco
                await context.SaveChangesAsync();

                return Results.NoContent();
            }
            catch (Exception ex)
            {
                // Retorna a mensagem de erro se algo der errado
                return Results.BadRequest(ex.Message);
            }
        });


        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var teste = await context.Testes.FindAsync(id);

            if (teste == null)
            {
                return Results.NotFound("Teste não encontrado.");
            }

            try
            {
                teste.Deletar();
                await context.SaveChangesAsync();

                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
    }
}
namespace ProjetosEspaciais.Modules;

public static class ProjetoModule
{
    public static void MapProjetoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/projeto")
            .WithTags("Projeto");

        // I N S E R I R
        group.MapPost("/inserir", async (ApplicationDbContext context, ProjetoDto novoProjeto) =>
        {
            try
            {
                // Validações de campos obrigatórios
                if (string.IsNullOrWhiteSpace(novoProjeto.Nome))
                {
                    return Results.BadRequest("O nome do projeto é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novoProjeto.Descricao))
                {
                    return Results.BadRequest("A descrição do projeto é obrigatória.");
                }

                // Verificar se o nome já existe
                var nomeExistente = await context.Projetos
                    .FirstOrDefaultAsync(p => p.Nome == novoProjeto.Nome && p.Ativo);

                if (nomeExistente != null)
                {
                    return Results.BadRequest("Já existe um projeto com este nome.");
                }

                // Verificar se o gerente de torre existe
                var gerenteTorre = await context.Membros.FindAsync(novoProjeto.GerenteTorreId);
                if (gerenteTorre == null)
                {
                    return Results.BadRequest("Gerente de torre não encontrado.");
                }

                // Verificar se as missões existem
                var missoes = await context.Missoes
                    .Where(m => novoProjeto.MissoesIds.Contains(m.Id))
                    .ToListAsync();

                if (missoes.Count != novoProjeto.MissoesIds.Count)
                {
                    return Results.BadRequest("Uma ou mais missões não foram encontradas.");
                }

                // Criar o projeto
                var projeto = Projeto.Inserir(
                    novoProjeto.Nome,
                    novoProjeto.Descricao,
                    novoProjeto.StatusProjeto,
                    novoProjeto.DataInicio,
                    novoProjeto.DataTermino,
                    novoProjeto.Orcamento,
                    novoProjeto.FaseAtual,
                    novoProjeto.GerenteTorreId,
                    missoes
                );

                context.Projetos.Add(projeto);
                await context.SaveChangesAsync();

                return Results.Created($"/api/projeto/inserir/{projeto.Id}/", new { mensagem = "Projeto cadastrado com sucesso!", projeto = novoProjeto });
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
                return Results.BadRequest("Id inválido");
            }

            var projeto = await context.Projetos
                .Include(p => p.Missoes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (projeto is null)
            {
                return Results.NotFound("Projeto não encontrado.");
            }

            var projetoDto = new ProjetoDto(
                Nome: projeto.Nome,
                Descricao: projeto.Descricao,
                StatusProjeto: projeto.StatusProjeto,
                DataInicio: projeto.DataInicio,
                DataTermino: projeto.DataTermino,
                Orcamento: projeto.Orcamento,
                FaseAtual: projeto.FaseAtual,
                GerenteTorreId: projeto.GerenteTorreId,
                MissoesIds: projeto.Missoes.Select(m => m.Id).ToList(),
                Id: projeto.Id
            );

            return Results.Ok(projetoDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var projetos = await context.Projetos
                .Include(p => p.Missoes)
                .ToListAsync();

            var projetosDto = projetos.Select(projeto => new ProjetoDto(
                Nome: projeto.Nome,
                Descricao: projeto.Descricao,
                StatusProjeto: projeto.StatusProjeto,
                DataInicio: projeto.DataInicio,
                DataTermino: projeto.DataTermino,
                Orcamento: projeto.Orcamento,
                FaseAtual: projeto.FaseAtual,
                GerenteTorreId: projeto.GerenteTorreId,
                MissoesIds: projeto.Missoes.Select(m => m.Id).ToList(),
                Id: projeto.Id
            )).ToList();

            return Results.Ok(projetosDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] ProjetoDto projetoAtualizado) =>
        {
            var projeto = await context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return Results.NotFound("Projeto não encontrado.");
            }

            // Verificar se o nome já existe para outro projeto ativo
            var nomeExistente = await context.Projetos
                .FirstOrDefaultAsync(p => p.Nome == projetoAtualizado.Nome && p.Id != id && p.Ativo);

            if (nomeExistente != null)
            {
                return Results.BadRequest("Já existe um projeto com este nome.");
            }

            // Verificar se o gerente de torre existe
            var gerenteTorre = await context.Membros.FindAsync(projetoAtualizado.GerenteTorreId);
            if (gerenteTorre == null)
            {
                return Results.BadRequest("Gerente de torre não encontrado.");
            }

            // Verificar se as missões existem
            var missoes = await context.Missoes
                .Where(m => projetoAtualizado.MissoesIds.Contains(m.Id))
                .ToListAsync();

            if (missoes.Count != projetoAtualizado.MissoesIds.Count)
            {
                return Results.BadRequest("Uma ou mais missões não foram encontradas.");
            }

            // Atualizar o projeto
            Projeto.Atualizar(projeto,
                              projetoAtualizado.Nome,
                              projetoAtualizado.Descricao,
                              projetoAtualizado.StatusProjeto,
                              projetoAtualizado.DataInicio,
                              projetoAtualizado.DataTermino,
                              projetoAtualizado.Orcamento,
                              projetoAtualizado.FaseAtual,
                              projetoAtualizado.GerenteTorreId,
                              missoes
            );

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var projeto = await context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return Results.NotFound("Projeto não encontrado.");
            }

            Projeto.Deletar(projeto);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E S T A U R A R
        group.MapPatch("/restaurar/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var projeto = await context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return Results.NotFound("Projeto não encontrado.");
            }

            Projeto.Restaurar(projeto);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
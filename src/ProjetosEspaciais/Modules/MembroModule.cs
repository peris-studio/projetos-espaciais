namespace ProjetosEspaciais.Modules;

public static class MembroModule
{
    public static void MapMembroEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/membro")
            .WithTags("Membro");

        // I N S E R I R
        group.MapPost("/inserir", async (ApplicationDbContext context, MembroDto novoMembro) =>
        {
            try
            {
                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(novoMembro.NomeCompleto) ||
                    string.IsNullOrWhiteSpace(novoMembro.Funcao) ||
                    string.IsNullOrWhiteSpace(novoMembro.Especialidade) ||
                    string.IsNullOrWhiteSpace(novoMembro.Identificador) ||
                    string.IsNullOrWhiteSpace(novoMembro.Senha) ||
                    string.IsNullOrWhiteSpace(novoMembro.Genero.ToString()) ||
                    novoMembro.DataNascimento == default)
                {
                    return Results.BadRequest("Todos os campos são obrigatórios.");
                }

                // Gera um novo ID se o ID estiver vazio
                var id = novoMembro.Id == default ? Guid.NewGuid() : novoMembro.Id;

                // Converte o DTO para a entidade Membro
                var membro = new Membro
                {
                    Id = id,
                    NomeCompleto = novoMembro.NomeCompleto,
                    Funcao = novoMembro.Funcao,
                    Especialidade = novoMembro.Especialidade,
                    Identificador = novoMembro.Identificador,
                    Senha = novoMembro.Senha,
                    Genero = novoMembro.Genero,
                    DataNascimento = novoMembro.DataNascimento
                };

                // Adiciona o membro ao contexto e salva no banco de dados
                context.Membros.Add(membro);
                await context.SaveChangesAsync();

                // Retorna uma resposta de sucesso
                return Results.Created($"/api/membro/{membro.Id}", new { mensagem = "Membro cadastrado com sucesso!", membro = novoMembro with { Id = id } });
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.ToString(), title: "Erro interno no servidor");
            }
        });

        // O B T E R   P O R   I D
        group.MapGet("/obter-por-id/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido.");
            }

            // Busca o membro no banco de dados
            var membro = await context.Membros.FindAsync(id);

            if (membro is null)
            {
                return Results.NotFound("Membro não encontrado.");
            }

            // Converte a entidade Membro para DTO
            var membroDto = new MembroDto(
                membro.NomeCompleto,
                membro.Funcao,
                membro.Especialidade,
                membro.Identificador,
                membro.Senha,
                membro.Genero,
                membro.DataNascimento,
                membro.Id
            );

            return Results.Ok(membroDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            // Busca todos os membros no banco de dados
            var membros = await context.Membros.ToListAsync();

            // Converte as entidades Membro para DTO
            var membrosDto = membros.Select(membro => new MembroDto(
                membro.NomeCompleto,
                membro.Funcao,
                membro.Especialidade,
                membro.Identificador,
                membro.Senha,
                membro.Genero,
                membro.DataNascimento,
                membro.Id
            )).ToList();

            return Results.Ok(membrosDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] MembroDto membroAtualizado) =>
        {
            try
            {
                // Busca o membro no banco de dados
                var membro = await context.Membros.FindAsync(id);

                if (membro is null)
                {
                    return Results.NotFound("Membro não encontrado.");
                }

                // Atualiza os campos do membro
                membro.NomeCompleto = membroAtualizado.NomeCompleto;
                membro.Funcao = membroAtualizado.Funcao;
                membro.Especialidade = membroAtualizado.Especialidade;
                membro.Identificador = membroAtualizado.Identificador;
                membro.Senha = membroAtualizado.Senha;
                membro.Genero = membroAtualizado.Genero;
                membro.DataNascimento = membroAtualizado.DataNascimento;

                // Salva as alterações no banco de dados
                await context.SaveChangesAsync();

                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.ToString(), title: "Erro interno no servidor");
            }
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            try
            {
                // Busca o membro no banco de dados
                var membro = await context.Membros.FindAsync(id);

                if (membro is null)
                {
                    return Results.NotFound("Membro não encontrado.");
                }

                // Remove o membro do contexto e salva as alterações
                context.Membros.Remove(membro);
                await context.SaveChangesAsync();

                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.ToString(), title: "Erro interno no servidor");
            }
        });
    }
}
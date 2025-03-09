namespace ProjetosEspaciais.Modules;

public static class LocalidadeModule
{
    public static void MapLocalidadeEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/localidade")
            .WithTags("Localidade");

        // I N S E R I R
        group.MapPost("/inserir", async (ApplicationDbContext context, LocalidadeDto novaLocalidade) =>
        {
            try
            {
                var localidade = Localidade.Inserir(
                    novaLocalidade.Sede,
                    novaLocalidade.Cidade,
                    novaLocalidade.Estado,
                    novaLocalidade.Pais,
                    novaLocalidade.EnderecoCompleto,
                    novaLocalidade.Id
                );

                context.Localidades.Add(localidade);
                await context.SaveChangesAsync();

                return Results.Created($"/api/localidade/inserir/{localidade.Id}/", new { mensagem = "Localidade cadastrada com sucesso!", localidade = novaLocalidade });
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(ex.Message);
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

            var localidade = await context.Localidades.FindAsync(id);

            if (localidade is null)
            {
                return Results.NotFound("Localidade não encontrada.");
            }

            var localidadeDto = new LocalidadeDto(
                Sede: localidade.Sede,
                Cidade: localidade.Cidade,
                Estado: localidade.Estado,
                Pais: localidade.Pais,
                EnderecoCompleto: localidade.EnderecoCompleto,
                Id: localidade.Id
            );

            return Results.Ok(localidadeDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var localidades = await context.Localidades.ToListAsync();

            var localidadesDto = localidades.Select(localidade => new LocalidadeDto(
                Sede: localidade.Sede,
                Cidade: localidade.Cidade,
                Estado: localidade.Estado,
                Pais: localidade.Pais,
                EnderecoCompleto: localidade.EnderecoCompleto,
                Id: localidade.Id
            )).ToList();

            return Results.Ok(localidadesDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] LocalidadeDto localidadeAtualizada) =>
        {
            var localidade = await context.Localidades.FindAsync(id);

            if (localidade == null)
            {
                return Results.NotFound("Localidade não encontrada.");
            }

            localidade = Localidade.Atualizar(
                localidade,
                localidadeAtualizada.Sede,
                localidadeAtualizada.Cidade,
                localidadeAtualizada.Estado,
                localidadeAtualizada.Pais,
                localidadeAtualizada.EnderecoCompleto
            );

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var localidade = await context.Localidades.FindAsync(id);

            if (localidade == null)
            {
                return Results.NotFound("Localidade não encontrada.");
            }

            localidade = Localidade.Deletar(localidade);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
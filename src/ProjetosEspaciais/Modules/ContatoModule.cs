namespace ProjetosEspaciais.Modules;

public static class ContatoModule
{
    public static void MapContatoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/contato")
            .WithTags("Contato");

        // I N S E R I R 
        group.MapPost("/inserir", async (ApplicationDbContext context, ContatoDto novoContato) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(novoContato.EnderecoContato))
                {
                    return Results.BadRequest("O endereço de contato é obrigatório.");
                }

                var contato = Contato.Inserir(novoContato.TipoContato, novoContato.EnderecoContato, novoContato.Principal, novoContato.Id);

                context.Contatos.Add(contato);
                await context.SaveChangesAsync();

                return Results.Created($"/api/contato/inserir/{contato.Id}/", new { mensagem = "Contato cadastrado com sucesso!", contato = novoContato });
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

            var contato = await context.Contatos.FindAsync(id);

            if (contato is null)
            {
                return Results.NotFound("Contato não encontrado.");
            }

            var contatoDto = new ContatoDto(contato.TipoContato, contato.EnderecoContato, contato.Principal, contato.Id);

            return Results.Ok(contatoDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var contatos = await context.Contatos.ToListAsync();

            var contatosDto = contatos.Select(contato => new ContatoDto(contato.TipoContato, contato.EnderecoContato, contato.Principal, contato.Id)).ToList();

            return Results.Ok(contatosDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] ContatoDto contatoAtualizado) =>
        {
            var contato = await context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return Results.NotFound("Contato não encontrado.");
            }

            contato = Contato.Atualizar(contato, contatoAtualizado.TipoContato, contatoAtualizado.EnderecoContato);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var contato = await context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return Results.NotFound("Contato não encontrado.");
            }

            contato = Contato.Remover(contato);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
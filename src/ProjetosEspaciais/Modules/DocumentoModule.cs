namespace ProjetosEspaciais.Modules;

public static class DocumentoModule
{
    public static void MapDocumentoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/documento")
            .WithTags("Documento");

        // I N S E R I R
        group.MapPost("/inserir", async (ApplicationDbContext context, DocumentoDto novoDocumento) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(novoDocumento.Titulo) || string.IsNullOrWhiteSpace(novoDocumento.Versao))
                {
                    return Results.BadRequest("Título e versão são obrigatórios.");
                }

                var documento = Documento.Inserir(novoDocumento.Titulo, novoDocumento.TipoDocumento, novoDocumento.Versao, novoDocumento.ClassificacaoSegurancaDocumento, novoDocumento.StatusDocumento, novoDocumento.EquipeId);

                context.Documentos.Add(documento);
                await context.SaveChangesAsync();

                return Results.Created($"/api/documento/inserir/{documento.Id}/", new { mensagem = "Documento cadastrado com sucesso!", documento = novoDocumento });
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

            var documento = await context.Documentos.FindAsync(id);

            if (documento is null)
            {
                return Results.NotFound("Documento não encontrado.");
            }

            var documentoDto = new DocumentoDto(documento.Titulo, documento.TipoDocumento, documento.Versao, documento.ClassificacaoSegurancaDocumento, documento.StatusDocumento, documento.EquipeId, documento.Id);

            return Results.Ok(documentoDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var documentos = await context.Documentos.ToListAsync();

            var documentosDto = documentos.Select(documento => new DocumentoDto(documento.Titulo, documento.TipoDocumento, documento.Versao, documento.ClassificacaoSegurancaDocumento, documento.StatusDocumento, documento.EquipeId, documento.Id)).ToList();

            return Results.Ok(documentosDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] DocumentoDto documentoAtualizado) =>
        {
            var documento = await context.Documentos.FindAsync(id);

            if (documento == null)
            {
                return Results.NotFound("Documento não encontrado.");
            }

            documento = Documento.Atualizar(documento, documentoAtualizado.Titulo, documentoAtualizado.Versao, documentoAtualizado.ClassificacaoSegurancaDocumento, documentoAtualizado.StatusDocumento, documentoAtualizado.EquipeId);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var documento = await context.Documentos.FindAsync(id);

            if (documento == null)
            {
                return Results.NotFound("Documento não encontrado.");
            }

            documento = Documento.Deletar(documento);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E S T A U R A R
        group.MapPatch("/restaurar/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var documento = await context.Documentos.FindAsync(id);

            if (documento == null)
            {
                return Results.NotFound("Documento não encontrado.");
            }

            documento = Documento.Restaurar(documento);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
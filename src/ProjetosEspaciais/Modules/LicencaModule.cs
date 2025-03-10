namespace ProjetosEspaciais.Modules;

public static class LicencaModule
{
    public static void MapLicencaEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/licenca")
            .WithTags("Licenca");

        // I N S E R I R
        group.MapPost("/inserir", async (ApplicationDbContext context, LicencaDto novaLicenca) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(novaLicenca.Nome))
                {
                    return Results.BadRequest("O nome da licença é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novaLicenca.NumeroLicenca))
                {
                    return Results.BadRequest("O número da licença é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novaLicenca.OrgaoEmissor))
                {
                    return Results.BadRequest("O órgão emissor da licença é obrigatório.");
                }

                if (novaLicenca.DataValidade < novaLicenca.DataEmissao)
                {
                    return Results.BadRequest("A data de validade não pode ser anterior à data de emissão.");
                }

                var licenca = Licenca.Inserir(
                    novaLicenca.TipoLicenca,
                    novaLicenca.Nome,
                    novaLicenca.NumeroLicenca,
                    novaLicenca.OrgaoEmissor,
                    novaLicenca.DataEmissao,
                    novaLicenca.DataValidade,
                    novaLicenca.RequisitoConformidade,
                    novaLicenca.MissaoLicencas,
                    novaLicenca.Id
                );

                context.Licencas.Add(licenca);
                await context.SaveChangesAsync();

                return Results.Created($"/api/licenca/inserir/{licenca.Id}/", new { mensagem = "Licença cadastrada com sucesso!", licenca = novaLicenca });
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

            var licenca = await context.Licencas.FindAsync(id);

            if (licenca is null)
            {
                return Results.NotFound("Licença não encontrada.");
            }

            var licencaDto = new LicencaDto(
                TipoLicenca: licenca.TipoLicenca,
                Nome: licenca.Nome,
                NumeroLicenca: licenca.NumeroLicenca,
                OrgaoEmissor: licenca.OrgaoEmissor,
                DataEmissao: licenca.DataEmissao,
                DataValidade: licenca.DataValidade,
                RequisitoConformidade: licenca.RequisitoConformidade,
                MissaoLicencas: licenca.MissaoLicencas,
                Id: licenca.Id
            );

            return Results.Ok(licencaDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var licencas = await context.Licencas.ToListAsync();

            var licencasDto = licencas.Select(licenca => new LicencaDto(
                TipoLicenca: licenca.TipoLicenca,
                Nome: licenca.Nome,
                NumeroLicenca: licenca.NumeroLicenca,
                OrgaoEmissor: licenca.OrgaoEmissor,
                DataEmissao: licenca.DataEmissao,
                DataValidade: licenca.DataValidade,
                RequisitoConformidade: licenca.RequisitoConformidade,
                MissaoLicencas: licenca.MissaoLicencas,
                Id: licenca.Id
            )).ToList();

            return Results.Ok(licencasDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] LicencaDto licencaAtualizada) =>
        {
            var licenca = await context.Licencas.FindAsync(id);

            if (licenca == null)
            {
                return Results.NotFound("Licença não encontrada.");
            }

            licenca = Licenca.Atualizar(
                licenca,
                licencaAtualizada.TipoLicenca,
                licencaAtualizada.Nome,
                licencaAtualizada.NumeroLicenca,
                licencaAtualizada.OrgaoEmissor,
                licencaAtualizada.DataEmissao,
                licencaAtualizada.DataValidade,
                licencaAtualizada.RequisitoConformidade
            );

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var licenca = await context.Licencas.FindAsync(id);

            if (licenca == null)
            {
                return Results.NotFound("Licença não encontrada.");
            }

            licenca = Licenca.Deletar(licenca);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
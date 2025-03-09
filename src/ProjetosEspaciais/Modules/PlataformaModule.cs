namespace ProjetosEspaciais.Modules;

public static class PlataformaModule
{
    public static void MapPlataformaEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/plataforma")
            .WithTags("Plataforma");

        // I N S E R I R
        group.MapPost("/inserir", async (ApplicationDbContext context, PlataformaDto novaPlataforma) =>
        {
            try
            {
                // Validações de campos obrigatórios
                if (string.IsNullOrWhiteSpace(novaPlataforma.Nome))
                {
                    return Results.BadRequest("O nome da plataforma é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novaPlataforma.Descricao))
                {
                    return Results.BadRequest("A descrição da plataforma é obrigatória.");
                }

                var nomeExistente = await context.Plataformas
                    .FirstOrDefaultAsync(p => p.Nome == novaPlataforma.Nome);

                if (nomeExistente != null)
                {
                    return Results.BadRequest("Já existe uma plataforma com este nome.");
                }

                // Validar coordenadas
                if (novaPlataforma.CoordenadaLatitude < -90 || novaPlataforma.CoordenadaLatitude > 90)
                {
                    return Results.BadRequest("A latitude deve estar entre -90 e 90.");
                }

                if (novaPlataforma.CoordenadaAltitude < 0)
                {
                    return Results.BadRequest("A altitude não pode ser negativa.");
                }

                var plataforma = Plataforma.Inserir(novaPlataforma.Nome,
                                                  novaPlataforma.Descricao,
                                                  novaPlataforma.TipoPlataforma,
                                                  novaPlataforma.CoordenadaLatitude,
                                                  novaPlataforma.CoordenadaAltitude,
                                                  novaPlataforma.StatusPlataforma
                );

                context.Plataformas.Add(plataforma);
                await context.SaveChangesAsync();

                return Results.Created($"/api/plataforma/inserir/{plataforma.Id}/", new { mensagem = "Plataforma cadastrada com sucesso!", plataforma = novaPlataforma });
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

            var plataforma = await context.Plataformas.FindAsync(id);

            if (plataforma is null)
            {
                return Results.NotFound("Plataforma não encontrada.");
            }

            var plataformaDto = new PlataformaDto(Nome: plataforma.Nome,
                                                  Descricao: plataforma.Descricao,
                                                  TipoPlataforma: plataforma.TipoPlataforma,
                                                  CoordenadaLatitude: plataforma.CoordenadaLatitude,
                                                  CoordenadaAltitude: plataforma.CoordenadaAltitude,
                                                  StatusPlataforma: plataforma.StatusPlataforma,
                                                  Id: plataforma.Id
            );

            return Results.Ok(plataformaDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var plataformas = await context.Plataformas.ToListAsync();

            var plataformasDto = plataformas.Select(plataforma => new PlataformaDto(Nome: plataforma.Nome,
                                                                                    Descricao: plataforma.Descricao,
                                                                                    TipoPlataforma: plataforma.TipoPlataforma,
                                                                                    CoordenadaLatitude: plataforma.CoordenadaLatitude,
                                                                                    CoordenadaAltitude: plataforma.CoordenadaAltitude,
                                                                                    StatusPlataforma: plataforma.StatusPlataforma,
                                                                                    Id: plataforma.Id
            )).ToList();

            return Results.Ok(plataformasDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] PlataformaDto plataformaAtualizada) =>
        {
            var plataforma = await context.Plataformas.FindAsync(id);

            if (plataforma == null)
            {
                return Results.NotFound("Plataforma não encontrada.");
            }

            // Verificar se o nome já existe para outra plataforma
            var nomeExistente = await context.Plataformas
                .FirstOrDefaultAsync(p => p.Nome == plataformaAtualizada.Nome && p.Id != id);

            if (nomeExistente != null)
            {
                return Results.BadRequest("Já existe uma plataforma com este nome.");
            }

            // Validar coordenadas
            if (plataformaAtualizada.CoordenadaLatitude < -90 || plataformaAtualizada.CoordenadaLatitude > 90)
            {
                return Results.BadRequest("A latitude deve estar entre -90 e 90.");
            }

            if (plataformaAtualizada.CoordenadaAltitude < 0)
            {
                return Results.BadRequest("A altitude não pode ser negativa.");
            }

            plataforma = Plataforma.Atualizar(plataforma,
                                              plataformaAtualizada.Nome,
                                              plataformaAtualizada.Descricao,
                                              plataformaAtualizada.TipoPlataforma,
                                              plataformaAtualizada.CoordenadaLatitude,
                                              plataformaAtualizada.CoordenadaAltitude,
                                              plataformaAtualizada.StatusPlataforma
            );

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var plataforma = await context.Plataformas.FindAsync(id);

            if (plataforma == null)
            {
                return Results.NotFound("Plataforma não encontrada.");
            }

            plataforma = Plataforma.Deletar(plataforma);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
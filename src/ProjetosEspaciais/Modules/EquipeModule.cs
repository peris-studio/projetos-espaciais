namespace ProjetosEspaciais.Modules;

public static class EquipeModule
{
    public static void MapEquipeEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/equipe")
            .WithTags("Equipe");

        // I N S E R I R
        group.MapPost("/inserir", async (ApplicationDbContext context, EquipeDto novaEquipe) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(novaEquipe.Codinome))
                {
                    return Results.BadRequest("O codinome da equipe é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novaEquipe.Funcao))
                {
                    return Results.BadRequest("A função da equipe é obrigatória.");
                }

                var equipe = Equipe.Inserir(novaEquipe.Codinome, novaEquipe.Funcao, novaEquipe.ContatoId, novaEquipe.LiderId, novaEquipe.Id);

                context.Equipes.Add(equipe);
                await context.SaveChangesAsync();

                return Results.Created($"/api/equipe/inserir/{equipe.Id}/", new { mensagem = "Equipe cadastrada com sucesso!", equipe = novaEquipe });
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

            var equipe = await context.Equipes
                .Include(e => e.Contato)
                .Include(e => e.Lider)
                .Include(e => e.Membros)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipe is null)
            {
                return Results.NotFound("Equipe não encontrada.");
            }

            var equipeDto = new EquipeDto(
                Codinome: equipe.Codinome,
                Funcao: equipe.Funcao,
                MembroId: equipe.Membros.FirstOrDefault()?.Id ?? Guid.Empty, // Exemplo de como obter o ID de um membro
                ContatoId: equipe.ContatoId,
                LiderId: equipe.LiderId ?? Guid.Empty,
                Id: equipe.Id
            );

            return Results.Ok(equipeDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var equipes = await context.Equipes
                .Include(e => e.Contato)
                .Include(e => e.Lider)
                .Include(e => e.Membros)
                .ToListAsync();

            var equipesDto = equipes.Select(equipe => new EquipeDto(
                                            Codinome: equipe.Codinome,
                                            Funcao: equipe.Funcao,
                                            MembroId: equipe.Membros.FirstOrDefault()?.Id ?? Guid.Empty, // Exemplo de como obter o ID de um membro
                                            ContatoId: equipe.ContatoId,
                                            LiderId: equipe.LiderId ?? Guid.Empty,
                                            Id: equipe.Id
            )).ToList();

            return Results.Ok(equipesDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] EquipeDto equipeAtualizada) =>
        {
            var equipe = await context.Equipes.FindAsync(id);

            if (equipe == null)
            {
                return Results.NotFound("Equipe não encontrada.");
            }

            equipe = Equipe.Atualizar(equipe, equipeAtualizada.Codinome, equipeAtualizada.Funcao, equipeAtualizada.ContatoId, equipeAtualizada.LiderId);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var equipe = await context.Equipes.FindAsync(id);

            if (equipe == null)
            {
                return Results.NotFound("Equipe não encontrada.");
            }

            equipe = Equipe.Remover(equipe);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
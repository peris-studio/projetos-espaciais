namespace ProjetosEspaciais.Modules;

public static class VeiculoModule
{
    public static void MapVeiculoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
                    .MapGroup("/api/veiculo")
                    .WithTags("Veículo");

        // I N S E R I R
        group.MapPost("/inserir", async ([FromServices] ApplicationDbContext context, [FromBody] VeiculoDto novoVeiculo) =>
        {
            try
            {
                // Validações de campos obrigatórios
                if (string.IsNullOrWhiteSpace(novoVeiculo.Nome))
                {
                    return Results.BadRequest("O nome do veículo é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(novoVeiculo.Placa))
                {
                    return Results.BadRequest("A placa do veículo é obrigatória.");
                }

                if (string.IsNullOrWhiteSpace(novoVeiculo.Marca))
                {
                    return Results.BadRequest("A marca do veículo é obrigatória.");
                }

                if (string.IsNullOrWhiteSpace(novoVeiculo.Modelo))
                {
                    return Results.BadRequest("O modelo do veículo é obrigatório.");
                }

                // Verificar se a placa já existe no banco de dados
                var veiculoExistente = await context.Veiculos
                    .FirstOrDefaultAsync(v => v.Placa == novoVeiculo.Placa);

                if (veiculoExistente != null)
                {
                    return Results.BadRequest("Já existe um veículo com essa placa.");
                }

                // Criação do novo veículo
                var veiculo = Veiculo.Inserir(
                    novoVeiculo.Nome,
                    novoVeiculo.Placa,
                    novoVeiculo.Marca,
                    novoVeiculo.Modelo,
                    novoVeiculo.Ano,
                    novoVeiculo.Cor,
                    novoVeiculo.TipoVeiculo,
                    novoVeiculo.TipoCombustivel,
                    novoVeiculo.TipoTransmissao,
                    novoVeiculo.Capacidade,
                    novoVeiculo.EspecificacaoTecnicaExtra
                );

                context.Veiculos.Add(veiculo);
                await context.SaveChangesAsync();

                // Atualiza o DTO do veículo com o ID gerado
                novoVeiculo = novoVeiculo with { Id = veiculo.Id };

                // Retorna uma resposta de sucesso com o veículo criado
                return Results.Created($"/api/veiculo/{novoVeiculo.Id}", new { mensagem = "Veículo cadastrado com sucesso!", veiculo = novoVeiculo });
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

            var veiculo = await context.Veiculos
                .FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo is null)
            {
                return Results.NotFound("Veículo não encontrado.");
            }

            var veiculoDto = new VeiculoDto(
                Nome: veiculo.Nome,
                Placa: veiculo.Placa,
                Marca: veiculo.Marca,
                Modelo: veiculo.Modelo,
                Ano: veiculo.Ano,
                Cor: veiculo.Cor,
                TipoVeiculo: veiculo.TipoVeiculo,
                TipoCombustivel: veiculo.TipoCombustivel,
                TipoTransmissao: veiculo.TipoTransmissao,
                Capacidade: veiculo.Capacidade,
                EspecificacaoTecnicaExtra: veiculo.EspecificacaoTecnicaExtra ?? "nulo",
                Id: veiculo.Id
            );

            return Results.Ok(veiculoDto);
        });

        // L I S T A R
        group.MapGet("/listar", async ([FromServices] ApplicationDbContext context) =>
        {
            var veiculos = await context.Veiculos.ToListAsync();

            var veiculosDto = veiculos.Select(veiculo => new VeiculoDto(
                Nome: veiculo.Nome,
                Placa: veiculo.Placa,
                Marca: veiculo.Marca,
                Modelo: veiculo.Modelo,
                Ano: veiculo.Ano,
                Cor: veiculo.Cor,
                TipoVeiculo: veiculo.TipoVeiculo,
                TipoCombustivel: veiculo.TipoCombustivel,
                TipoTransmissao: veiculo.TipoTransmissao,
                Capacidade: veiculo.Capacidade,
                EspecificacaoTecnicaExtra: veiculo.EspecificacaoTecnicaExtra ?? "nulo",
                Id: veiculo.Id
            )).ToList();

            return Results.Ok(veiculosDto);
        });

        // A T U A L I Z A R
        group.MapPatch("/atualizar/{id}", async ([FromServices] ApplicationDbContext context, Guid id, [FromBody] VeiculoDto veiculoAtualizado) =>
        {
            var veiculo = await context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return Results.NotFound("Veículo não encontrado.");
            }

            veiculo = Veiculo.Atualizar(
                veiculo,
                veiculoAtualizado.Nome,
                veiculoAtualizado.Placa,
                veiculoAtualizado.Marca,
                veiculoAtualizado.Modelo,
                veiculoAtualizado.Ano,
                veiculoAtualizado.Cor,
                veiculoAtualizado.TipoVeiculo,
                veiculoAtualizado.TipoCombustivel,
                veiculoAtualizado.TipoTransmissao,
                veiculoAtualizado.Capacidade,
                veiculoAtualizado.EspecificacaoTecnicaExtra
            );

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", async ([FromServices] ApplicationDbContext context, Guid id) =>
        {
            var veiculo = await context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return Results.NotFound("Veículo não encontrado.");
            }

            context.Veiculos.Remove(veiculo);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
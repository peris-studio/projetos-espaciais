namespace ProjetosEspaciais.Dtos;

public record TesteDto(TipoTeste TipoTeste,
                       string Objetivo,
                       DateOnly DataRealizacao,
                       string Resultado,
                       string Equipamentoutilizado,
                       string ConclusaoRecomendacao,
                       Guid LocalidadeId,
                       Guid EquipeId,
                       Guid PlataformaId,
                       Guid HistoricoAlteracaoId,
                       Guid Id = default);
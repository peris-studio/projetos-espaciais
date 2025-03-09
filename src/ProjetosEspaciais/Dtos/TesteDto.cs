namespace ProjetosEspaciais.Dtos
{
    public record TesteDto(TipoTeste TipoTeste,
                           string? Objetivo,
                           DateOnly DataRealizacao,
                           string? Resultado,
                           string? EquipamentoUtilizado,
                           string? ConclusaoRecomendacao,
                           Guid LocalidadeId,
                           Guid EquipeId,
                           Guid PlataformaId,
                           Guid Id = default);
}
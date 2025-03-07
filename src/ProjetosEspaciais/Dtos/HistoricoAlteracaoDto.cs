namespace ProjetosEspaciais.Dtos;

public record HistoricoAlteracaoDto(TipoAlteracao TipoAlteracao, string Descricao, string Motivacao, NivelImpacto NivelImpacto, Guid EquipeId, Guid Id = default);
namespace ProjetosEspaciais.Dtos;

public record HistoricoAlteracaoDto(TipoAlteracao TipoAlteracao,
                                    string Descricao,
                                    string Motivacao,
                                    NivelImpactoAlteracao NivelImpactoAlteracao,
                                    Guid EquipeId,
                                    Guid Id = default);
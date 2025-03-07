namespace ProjetosEspaciais.Dtos;

public record MissaoDto(string Codinome,
                        string Descricao,
                        TipoMissao TipoMissao,
                        string Objetivo,
                        StatusMissao StatusMissao,
                        DuracaoEstimada DuracaoEstimada,
                        decimal CustoEstimado,
                        Guid ProjetoId,
                        Guid VeiculoId,
                        Guid PlataformaId,
                        Guid TesteId,
                        Guid DocumentoId,
                        Guid HistoricoAlteracaoId,
                        Guid LicencaId,
                        Guid EquipeId,
                        Guid Id = default);
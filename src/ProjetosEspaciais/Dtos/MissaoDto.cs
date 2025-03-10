namespace ProjetosEspaciais.Dtos;

public record MissaoDto(string Codinome,
                        string Descricao,
                        TipoMissao TipoMissao,
                        string Objetivo,
                        StatusMissao StatusMissao,
                        string DuracaoEstimada,
                        decimal CustoEstimado,
                        DateOnly DataInicio,
                        DateOnly DataTermino,
                        Guid VeiculoId,
                        Guid PlataformaId,
                        Guid EquipeId,
                        List<Guid> MissaoLicencas,
                        Guid Id = default);
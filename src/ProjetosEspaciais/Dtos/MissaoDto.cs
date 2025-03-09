namespace ProjetosEspaciais.Dtos;

public record MissaoDto(string Codinome,
                        string Descricao,
                        TipoMissao TipoMissao,
                        string Objetivo,
                        StatusMissao StatusMissao,
                        string DuracaoEstimada,
                        decimal CustoEstimado,
                        DateOnly DataInicio,
                        DateOnly? DataTermino,
                        Guid VeiculoId,
                        Guid PlataformaId,
                        Guid EquipeId,
                        List<Guid> TestesIds,
                        List<Guid> DocumentosIds,
                        List<Guid> LicencasIds,
                        Guid Id = default);
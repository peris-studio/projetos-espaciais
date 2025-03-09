namespace ProjetosEspaciais.Dtos;

public record ProjetoDto(string Nome,
                         string Descricao,
                         StatusProjeto StatusProjeto,
                         DateOnly DataInicio,
                         DateOnly DataTermino,
                         decimal Orcamento,
                         FaseAtual FaseAtual,
                         Guid GerenteTorreId,
                         List<Guid> MissoesIds,
                         Guid Id = default);
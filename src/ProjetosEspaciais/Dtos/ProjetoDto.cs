namespace ProjetosEspaciais.Dtos;

public record ProjetoDto(string Nome,
                         string Descricao,
                         StatusProjeto StatusProjetos,
                         DateOnly DataInicio,
                         DateOnly DataTermino,
                         decimal Orcamento,
                         FaseAtual FaseAtual,
                         Guid GerenteTorreId,
                         Guid Id = default);
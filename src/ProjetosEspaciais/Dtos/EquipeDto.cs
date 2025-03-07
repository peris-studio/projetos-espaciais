namespace ProjetosEspaciais.Dtos;

public record EquipeDto(string Codinome, string Funcao, DepartamentoEquipe DepartamentoEquipe, Guid MembroId, Guid ContatoId, Guid Id = default);
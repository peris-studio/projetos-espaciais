namespace ProjetosEspaciais.Dtos;

public record EquipeDto(string Codinome, string Funcao, Guid MembroId, Guid ContatoId, Guid Id = default);
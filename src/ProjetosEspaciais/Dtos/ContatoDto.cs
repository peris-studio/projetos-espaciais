namespace ProjetosEspaciais.Dtos;

public record ContatoDto(TipoContato TipoContato, string Contato, bool Principal, Guid Id = default);
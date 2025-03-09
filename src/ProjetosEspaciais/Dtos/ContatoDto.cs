namespace ProjetosEspaciais.Dtos;

public record ContatoDto(TipoContato TipoContato, string EnderecoContato, bool Principal, Guid Id = default);
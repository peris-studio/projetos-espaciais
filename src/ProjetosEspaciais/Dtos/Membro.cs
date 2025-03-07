namespace ProjetosEspaciais.Dtos;

public record MembroDto(string NomeCompleto, CargoMembro CargoMembro, string funcao, string especialidade, DepartamentoMembro DepartamentoMembro, string Identificador, string Senha, TipoGenero TipoGenero, Guid Id = default);
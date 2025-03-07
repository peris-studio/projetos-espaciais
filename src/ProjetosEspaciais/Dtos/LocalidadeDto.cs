namespace ProjetosEspaciais.Dtos;

public record LocalidadeDto(string Sede, string Cidade, string Estado, string Pais, string EnderecoCompleto, Guid Id = default);
namespace ProjetosEspaciais.Dtos;

public record ExperienciaDto(string Titulo, string Descricao, StatusExperiencia StatusExperiencia, Guid Id = default);
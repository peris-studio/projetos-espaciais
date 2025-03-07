namespace ProjetosEspaciais.Dtos;

public record ExperienciaDto(string Titulo, string Descricao, StatusExperiencia StatusExperiencia, DateOnly DataInicio, DateOnly DataTermino, Guid Id = default);
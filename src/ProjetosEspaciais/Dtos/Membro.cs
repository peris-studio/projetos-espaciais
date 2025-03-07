namespace ProjetosEspaciais.Dtos;

public record MembroDto(string NomeCompleto,
                        CargoMembro CargoMembro,
                        string Funcao,
                        string Especialidade,
                        string Identificador,
                        string Senha,
                        Genero Genero,
                        DateOnly DataNascimento,
                        Guid Id = default);
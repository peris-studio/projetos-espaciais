namespace ProjetosEspaciais.Dtos;

public record PlataformaDto(string Nome,
                            string Descricao,
                            TipoPlataforma TipoPlataforma,
                            decimal CoordenadaLatitude,
                            decimal CoordenadaAltitude,
                            StatusPlataforma StatusPlataforma,
                            Guid Id = default);
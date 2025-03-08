namespace ProjetosEspaciais.Enums;

public record VeiculoDto(string Nome,
                         string Placa,
                         string Marca,
                         string Modelo,
                         string Ano,
                         string Cor,
                         TipoVeiculo TipoVeiculo,
                         TipoCombustivel TipoCombustivel,
                         TipoTransmissao TipoTransmissao,
                         string Capacidade,
                         string EspecificacaoTecnicaExtra,
                         Guid Id = default);
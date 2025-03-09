namespace ProjetosEspaciais.Models;

using ProjetosEspaciais.Enums;
using System;

public class Plataforma
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public TipoPlataforma TipoPlataforma { get; set; }
    public decimal CoordenadaLatitude { get; set; }
    public decimal CoordenadaAltitude { get; set; }
    public StatusPlataforma StatusPlataforma { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public static Plataforma Inserir(string nome, string descricao, TipoPlataforma tipoPlataforma, decimal latitude, decimal altitude, StatusPlataforma statusPlataforma)
    {
        ValidarCamposObrigatorios(nome, nameof(nome));
        ValidarCamposObrigatorios(descricao, nameof(descricao));

        ValidarCoordenadas(latitude, altitude);

        ValidarEnum(tipoPlataforma, nameof(tipoPlataforma));
        ValidarEnum(statusPlataforma, nameof(statusPlataforma));

        return new Plataforma
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Descricao = descricao,
            TipoPlataforma = tipoPlataforma,
            CoordenadaLatitude = latitude,
            CoordenadaAltitude = altitude,
            StatusPlataforma = statusPlataforma,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public static Plataforma Atualizar(Plataforma plataforma, string nome, string descricao, TipoPlataforma tipoPlataforma, decimal latitude, decimal altitude, StatusPlataforma statusPlataforma)
    {
        ValidarCamposObrigatorios(nome, descricao);
        ValidarCoordenadas(latitude, altitude);

        plataforma.Nome = nome;
        plataforma.Descricao = descricao;
        plataforma.TipoPlataforma = tipoPlataforma;
        plataforma.CoordenadaLatitude = latitude;
        plataforma.CoordenadaAltitude = altitude;
        plataforma.StatusPlataforma = statusPlataforma;
        plataforma.DataAtualizacao = DateTime.UtcNow;

        return plataforma;
    }

    public static Plataforma Deletar(Plataforma plataforma)
    {
        plataforma.DataDelecao = DateTime.UtcNow;
        plataforma.Ativo = false;

        return plataforma;
    }

    // Método para validar campos obrigatórios
    public static void ValidarCamposObrigatorios(string valor, string nomeCampo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException($"O campo '{nomeCampo}' não pode ser vazio ou conter apenas espaços em branco.", nomeCampo);
    }

    // Método para validar enums
    public static void ValidarEnum<TEnum>(TEnum valor, string nomeCampo) where TEnum : Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), valor))
            throw new ArgumentException($"O valor '{valor}' não é válido para o campo '{nomeCampo}'.", nomeCampo);
    }

    // Método para validar coordenadas
    public static void ValidarCoordenadas(decimal latitude, decimal altitude)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentException("A latitude deve estar entre -90 e 90.", nameof(latitude));

        if (altitude < 0)
            throw new ArgumentException("A altitude não pode ser negativa.", nameof(altitude));
    }

    public override string ToString()
    {
        return $@"
            Id: {Id}
            Nome: {Nome}
            Descrição: {Descricao}
            Tipo de Plataforma: {TipoPlataforma}
            Coordenada Latitude: {CoordenadaLatitude}
            Coordenada Altitude: {CoordenadaAltitude}
            Status: {StatusPlataforma}
            -
            Data de Criação: {DataCriacao}
            Data de Atualização: {DataAtualizacao?.ToString() ?? "N/A"}
            Data de Deleção: {DataDelecao?.ToString() ?? "N/A"}
            Ativo: {Ativo}
        ";
    }
}
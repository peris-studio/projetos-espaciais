namespace ProjetosEspaciais.Models;

public class Plataforma
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public TipoPlataforma TipoPlataforma { get; set; }
    public decimal CoordenadaLatitude { get; set; }
    public decimal CoordenadaAltitude { get; set; }
    public StatusPlataforma Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        return $@"
            Id: {Id}
            Nome: {Nome}
            Descrição: {Descricao}
            Tipo de Plataforma: {TipoPlataforma}
            Coordenada Latitude: {CoordenadaLatitude}
            Coordenada Altitude: {CoordenadaAltitude}
            Status: {Status}
            Data de Criação: {DataCriacao}
            Data de Atualização: {DataAtualizacao?.ToString() ?? "N/A"}
            Data de Deleção: {DataDelecao?.ToString() ?? "N/A"}
            Ativo: {Ativo}
        ";
    }
}
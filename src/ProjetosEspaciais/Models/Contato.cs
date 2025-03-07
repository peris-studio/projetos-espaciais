namespace ProjetosEspaciais.Models;

public class Contato
{
    public Guid Id { get; set; }
    public TipoContato TipoContato { get; set; }
    public string Contato { get; set; }
    public bool Principal { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        string principal = Principal ? "Sim" : "Não";
        return $@"
                Tipo de Contato: {TipoContato}
                Contato: {Contato}
                Contato Principal: {Principal}
                ";
    }
}
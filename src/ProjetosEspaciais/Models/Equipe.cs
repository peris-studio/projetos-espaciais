namespace ProjetosEspaciais.Models;

public class Equipe
{
    public Guid Id { get; set; }
    public string Codinome { get; set; }
    public string Funcao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid ContatoId { get; set; }
    public Contato Contato { get; set; }

    // Lista de membros da equipe
    public ICollection<Membro> Membros { get; set; } = new List<Membro>();

    // Líder da equipe (um dos membros)
    public Guid? LiderId { get; set; }
    public Membro? Lider { get; set; }

    public override string ToString()
    {
        return $@"
            Id: {Id}
            Codinome: {Codinome}
            Funcao: {Funcao}
            Contato: {Contato}
            Data de Criação: {DataCriacao}
            Data de Atualização: {DataAtualizacao}
            Data de Deleção: {DataDelecao}
            Ativo: {Ativo}
            Líder: {(Lider != null ? Lider.NomeCompleto : "Sem líder")}
            Total de Membros: {Membros.Count}
        ";
    }
}
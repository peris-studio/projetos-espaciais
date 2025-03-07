namespace ProjetosEspaciais.Models;

public class Teste
{
    public Guid Id { get; set; }
    public TipoTeste TipoTeste { get; set; }
    public string Objetivo { get; set; }
    public DateOnly DataRealizacao { get; set; }
    public string Resultado { get; set; }
    public string EquipamentoUtilizado { get; set; }
    public string ConclusaoRecomendacao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid LocalidadeId { get; set; }
    public Guid EquipeId { get; set; }
    public Guid PlataformaId { get; set; }
    public Guid HistoricoAlteracaoId { get; set; }
}

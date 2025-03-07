namespace ProjetosEspaciais.Models;

public class Missao
{
    public Guid Id { get; set; }
    public string Codinome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public TipoMissao TipoMissao { get; set; }
    public string Objetivo { get; set; } = null!;
    public StatusMissao StatusMissao { get; set; }
    public string DuracaoEstimada { get; set; }
    public decimal CustoEstimado { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly? DataTermino { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid ProjetoId { get; set; }
    public Projeto Projeto { get; set; } = null!;
    public Guid VeiculoId { get; set; }
    public Veiculo Veiculo { get; set; } = null!;
    public Guid PlataformaId { get; set; }
    public Plataforma Plataforma { get; set; } = null!;
    public Guid EquipeId { get; set; }
    public Equipe Equipe { get; set; } = null!;

    // Listas de entidades relacionadas
    public ICollection<Teste> Testes { get; set; } = new List<Teste>();
    public ICollection<Documento> Documentos { get; set; } = new List<Documento>();
    public ICollection<HistoricoAlteracao> HistoricoAlteracoes { get; set; } = new List<HistoricoAlteracao>();
    public ICollection<Licenca> Licencas { get; set; } = new List<Licenca>();

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Codinome: {Codinome}
                Descrição: {Descricao}
                Tipo de Missão: {TipoMissao}
                Objetivo: {Objetivo}
                Status: {StatusMissao}
                Duração Estimada: {DuracaoEstimada}
                Custo Estimado: {CustoEstimado}
                Data de Início: {DataInicio}
                Data de Término: {DataTermino}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                Ativo: {Ativo}
                ProjetoId: {ProjetoId}
                VeiculoId: {VeiculoId}
                PlataformaId: {PlataformaId}
                EquipeId: {EquipeId}
                Testes: {Testes.Count}
                Documentos: {Documentos.Count}
                Histórico de Alterações: {HistoricoAlteracoes.Count}
                Licenças: {Licencas.Count}
            ";
    }
}
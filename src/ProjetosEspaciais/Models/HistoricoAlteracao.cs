namespace ProjetosEspaciais.Models;
public class HistoricoAlteracao
{
    public Guid Id { get; set; }
    public TipoAlteracao TipoAlteracao { get; set; }
    public string Descricao { get; set; }
    public string Motivacao { get; set; }
    public NivelImpactoAlteracao NivelImpactoAlteracao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid EquipeResponsavel { get; set; }
    public Equipe EquipeId { get; set; }

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Tipo de Alteração: {TipoAlteracao}
                Descrição: {Descricao}
                Motivação: {Motivacao}
                Nível de Impacto: {NivelImpactoAlteracao}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                Ativo: {Ativo}
                Equipe Responsável: {EquipeResponsavel}
            ";
    }
}

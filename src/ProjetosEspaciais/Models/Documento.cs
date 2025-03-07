namespace ProjetosEspaciais.Models;

public class Documento
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public string Versao { get; set; }
    public ClassificacaoSegurancaDocumento ClassificacaoSegurancaDocumento { get; set; }
    public StatusDocumento StatusDocumento { get; set; }
    public Guid EquipeId { get; set; }
    public Equipe Equipe { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }

    public override string ToString()
    {
        return $@"
                Título: {Titulo}
                Tipo de Documento: {TipoDocumento}
                Versão: {Versao}
                Classificação: {ClassificacaoSegurancaDocumento}
                Status: {StatusDocumento}
                Equipe Responsável:
                Data de Criação: {DataCriacao}
                Data da Última Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                ";
    }
}

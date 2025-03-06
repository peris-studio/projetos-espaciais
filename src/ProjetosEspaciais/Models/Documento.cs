namespace ProjetosEspaciais.Models;

public class Documento
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public string Versao { get; set; }
    public TipoArquivo TipoArquivo { get; set; }
    public Classificacao ClassificaoSeguranca { get; set; }
    public StatusDocumento Status { get; set; }
    public Guid EquipeId { get; set; }
    public Equipe Equipe { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }

    public override string ToString()
    {
        var status = status ? "Sim" : "Não";
        return $@"
                Título: {Titulo}
                Tipo de Documento: {TipoDocumento}
                Versão: {Versao}
                Tipo de Arquivo: {TipoArquivo}
                Classificação de Segurança: {ClassificaoSeguranca}
                Status: {Status}
                Equipe Responsável:
                Data de Criação: {DataCriacao}
                Data da Última Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                ";
    }
}

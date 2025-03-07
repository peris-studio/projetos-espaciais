namespace ProjetosEspaciais.Models;

public class Licenca
{
    public Guid Id { get; set; }
    public TipoLicenca TipoLicenca { get; set; }
    public string Nome { get; set; }
    public string NumeroLicenca { get; set; }
    public string OrgaoEmissor { get; set; }
    public DateOnly DataEmissao { get; set; }
    public DateOnly DataValidade { get; set; }
    public string RequisitoConformidade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Tipo: {Tipo}
                Nome: {Nome}
                Número da Licença: {NumeroLicenca}
                Órgão Emissor: {OrgaoEmissor}
                Data de Emissão: {DataEmissao}
                Data de Validade: {DataValidade}
                Requisito de Conformidade: {RequisitoConformidade}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                Ativo: {Ativo}
            ";
    }
}
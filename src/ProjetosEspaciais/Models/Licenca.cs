namespace ProjetosEspaciais.Models;

using ProjetosEspaciais.Enums;

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
    public List<Guid>? MissaoLicencas { get; set; }

    public static Licenca Inserir(TipoLicenca tipoLicenca,
                                   string nome,
                                   string numeroLicenca,
                                   string orgaoEmissor,
                                   DateOnly dataEmissao,
                                   DateOnly dataValidade,
                                   string requisitoConformidade,
                                   List<Guid>? missaoLicencas = null,
                                   Guid id = default)
    {
        if (string.IsNullOrEmpty(nome) ||
            string.IsNullOrEmpty(numeroLicenca) ||
            string.IsNullOrEmpty(orgaoEmissor) ||
            dataEmissao == DateOnly.MinValue ||
            dataValidade == DateOnly.MinValue ||
            string.IsNullOrEmpty(requisitoConformidade))
        {
            throw new ArgumentException("As entradas não podem ser nulas ou vazias.");
        }

        if (dataValidade < dataEmissao)
        {
            throw new ArgumentException("A data de validade não pode ser anterior à data de emissão.");
        }

        return new Licenca
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            TipoLicenca = tipoLicenca,
            Nome = nome,
            NumeroLicenca = numeroLicenca,
            OrgaoEmissor = orgaoEmissor,
            DataEmissao = dataEmissao,
            DataValidade = dataValidade,
            RequisitoConformidade = requisitoConformidade,
            DataCriacao = DateTime.UtcNow,
            Ativo = true,
            MissaoLicencas = missaoLicencas ?? []
        };
    }

    public static Licenca Atualizar(Licenca licenca,
                                    TipoLicenca tipoLicenca,
                                    string nome,
                                    string numeroLicenca,
                                    string orgaoEmissor,
                                    DateOnly dataEmissao,
                                    DateOnly dataValidade,
                                    string requisitoConformidade)
    {
        if (string.IsNullOrEmpty(nome) ||
            string.IsNullOrEmpty(numeroLicenca) ||
            string.IsNullOrEmpty(orgaoEmissor) ||
            dataEmissao == DateOnly.MinValue ||
            dataValidade == DateOnly.MinValue ||
            string.IsNullOrEmpty(requisitoConformidade))
        {
            throw new ArgumentException("As entradas não podem ser nulas ou vazias.");
        }

        if (dataValidade < dataEmissao)
        {
            throw new ArgumentException("A data de validade não pode ser anterior à data de emissão.");
        }

        licenca.TipoLicenca = tipoLicenca;
        licenca.Nome = nome;
        licenca.NumeroLicenca = numeroLicenca;
        licenca.OrgaoEmissor = orgaoEmissor;
        licenca.DataEmissao = dataEmissao;
        licenca.DataValidade = dataValidade;
        licenca.RequisitoConformidade = requisitoConformidade;
        licenca.DataAtualizacao = DateTime.UtcNow;

        return licenca;
    }

    public static Licenca Deletar(Licenca licenca)
    {
        if (licenca == null)
        {
            throw new ArgumentNullException(nameof(licenca), "Licença não pode ser nula");
        }

        licenca.DataDelecao = DateTime.UtcNow;
        licenca.Ativo = false;

        return licenca;
    }

    public override string ToString()
    {
        return $@"
                    Id: {Id}
                    Tipo de Licença: {TipoLicenca}
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
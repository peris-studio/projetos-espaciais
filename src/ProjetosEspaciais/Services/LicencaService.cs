namespace ProjetosEspaciais.Services;

public class LicencaService
{
    public Licenca Inserir(TipoLicenca tipoLicenca,
                           string nome,
                           string numeroLicenca,
                           string orgaoEmissor,
                           DateOnly dataEmissao,
                           DateOnly dataValidade,
                           string requisitoConformidade,
                           Guid id = default)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(numeroLicenca))
        {
            throw new ArgumentException("Nome e número da licença não podem ser nulos ou vazios.");
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
            Ativo = true
        };
    }

    public Licenca Atualizar(Licenca licenca,
                             TipoLicenca tipoLicenca,
                             string nome,
                             string numeroLicenca,
                             string orgaoEmissor,
                             DateOnly dataEmissao,
                             DateOnly dataValidade,
                             string requisitoConformidade)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(numeroLicenca))
        {
            throw new ArgumentException("Nome e número da licença não podem ser nulos ou vazios.");
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

    public Licenca Remover(Licenca licenca)
    {
        licenca.DataDelecao = DateTime.UtcNow;
        licenca.Ativo = false;

        return licenca;
    }

    // Método para listar todas as licenças (exemplo de retorno simples)
    public List<Licenca> Listar()
    {
        // Aqui, você buscaria as licenças de um banco de dados ou repositório
        return new List<Licenca>
        {
            new Licenca
            {
                Id = Guid.NewGuid(),
                TipoLicenca = TipoLicenca.LicencaTecnica,
                Nome = "Licença A",
                NumeroLicenca = "12345",
                OrgaoEmissor = "Agência Espacial",
                DataEmissao = new DateOnly(2021, 01, 01),
                DataValidade = new DateOnly(2023, 01, 01),
                RequisitoConformidade = "Conformidade A",
                DataCriacao = DateTime.UtcNow,
                Ativo = true
            }
        };
    }
}
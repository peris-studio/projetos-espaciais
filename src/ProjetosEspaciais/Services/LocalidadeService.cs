namespace ProjetosEspaciais.Services;
public class LocalidadeService
{
    // Inserir nova localidade
    public Localidade Inserir(string sede, string cidade, string estado, string pais, string enderecoCompleto, Guid id = default)
    {
        if (string.IsNullOrEmpty(sede) ||
            string.IsNullOrEmpty(cidade) ||
            string.IsNullOrEmpty(estado) ||
            string.IsNullOrEmpty(pais) ||
            string.IsNullOrEmpty(enderecoCompleto))
        {
            throw new ArgumentException("Os campos obrigatórios não podem ser nulos ou vazios.");
        }

        return new Localidade
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Sede = sede,
            Cidade = cidade,
            Estado = estado,
            Pais = pais,
            EnderecoCompleto = enderecoCompleto,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public Localidade Atualizar(Localidade localidade, string sede, string cidade, string estado, string pais, string enderecoCompleto)
    {
        if (string.IsNullOrEmpty(sede) ||
            string.IsNullOrEmpty(cidade) ||
            string.IsNullOrEmpty(estado) ||
            string.IsNullOrEmpty(pais) ||
            string.IsNullOrEmpty(enderecoCompleto))
        {
            throw new ArgumentException("Os campos obrigatórios não podem ser nulos ou vazios.");
        }

        localidade.Sede = sede;
        localidade.Cidade = cidade;
        localidade.Estado = estado;
        localidade.Pais = pais;
        localidade.EnderecoCompleto = enderecoCompleto;
        localidade.DataAtualizacao = DateTime.UtcNow;

        return localidade;
    }

    public Localidade Remover(Localidade localidade)
    {
        localidade.DataDelecao = DateTime.UtcNow;
        localidade.Ativo = false;

        return localidade;
    }
}
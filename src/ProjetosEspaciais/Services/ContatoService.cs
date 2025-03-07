namespace ProjetosEspaciais.Services;

public class ContatoService
{
    public Contato Inserir(TipoContato tipoContato, string contato, bool principal, Guid id = default)
    {
        if (string.IsNullOrEmpty(contato))
        {
            throw new ArgumentException("Contato não pode ser nulo ou vazio", nameof(contato));
        }

        return new Contato
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            TipoContato = tipoContato,
            Contato = contato,
            Principal = principal,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public Contato Atualizar(Contato contato, TipoContato tipoContato, string novoContato)
    {
        if (string.IsNullOrEmpty(novoContato))
        {
            throw new ArgumentException("Contato não pode ser nulo ou vazio", nameof(novoContato));
        }

        contato.TipoContato = tipoContato;
        contato.Contato = novoContato;
        contato.DataAtualizacao = DateTime.UtcNow;

        return contato;
    }

    public Contato Remover(Contato contato)
    {
        contato.DataDelecao = DateTime.UtcNow;
        contato.Ativo = false;

        return contato;
    }
}
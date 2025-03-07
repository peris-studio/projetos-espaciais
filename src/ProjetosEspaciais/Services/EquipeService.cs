namespace ProjetosEspaciais.Services;

public class EquipeService
{
    public Equipe Inserir(string codinome, string funcao, Guid contatoId, Guid? liderId = null, Guid id = default)
    {
        if (string.IsNullOrEmpty(codinome))
        {
            throw new ArgumentException("Codinome não pode ser nulo ou vazio", nameof(codinome));
        }

        if (string.IsNullOrEmpty(funcao))
        {
            throw new ArgumentException("Função não pode ser nula ou vazia", nameof(funcao));
        }

        var equipe = new Equipe
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Codinome = codinome,
            Funcao = funcao,
            ContatoId = contatoId,
            Contato = new Contato { Id = contatoId }, // Criando o contato
            DataCriacao = DateTime.UtcNow,
            Ativo = true,
            LiderId = liderId
        };

        return equipe;
    }

    public Equipe Atualizar(Equipe equipe, string codinome, string funcao, Guid contatoId, Guid? liderId = null)
    {
        if (string.IsNullOrEmpty(codinome))
        {
            throw new ArgumentException("Codinome não pode ser nulo ou vazio", nameof(codinome));
        }

        if (string.IsNullOrEmpty(funcao))
        {
            throw new ArgumentException("Função não pode ser nula ou vazia", nameof(funcao));
        }

        equipe.Codinome = codinome;
        equipe.Funcao = funcao;
        equipe.ContatoId = contatoId;
        equipe.Contato = new Contato { Id = contatoId }; // Atualiza o contato
        equipe.LiderId = liderId;
        equipe.DataAtualizacao = DateTime.UtcNow;

        return equipe;
    }

    public Equipe Remover(Equipe equipe)
    {
        equipe.DataDelecao = DateTime.UtcNow;
        equipe.Ativo = false;

        return equipe;
    }

    // Método para adicionar um membro a uma equipe
    public void AdicionarMembro(Equipe equipe, Membro membro)
    {
        if (equipe.Membros.Any(m => m.Id == membro.Id))
        {
            throw new InvalidOperationException("Membro já pertence à equipe.");
        }

        equipe.Membros.Add(membro);
        equipe.DataAtualizacao = DateTime.UtcNow;
    }

    // Método para remover um membro de uma equipe
    public void RemoverMembro(Equipe equipe, Membro membro)
    {
        if (!equipe.Membros.Any(m => m.Id == membro.Id))
        {
            throw new InvalidOperationException("Membro não encontrado na equipe.");
        }

        equipe.Membros.Remove(membro);
        equipe.DataAtualizacao = DateTime.UtcNow;
    }
}
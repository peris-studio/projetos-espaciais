namespace ProjetosEspaciais.Services;

public class ProjetoService
{
    public Projeto Inserir(string nome,
                           string descricao,
                           StatusProjeto statusProjeto,
                           DateOnly dataInicio,
                           DateOnly dataTermino,
                           decimal orcamento,
                           FaseAtual faseAtual,
                           Guid gerenteTorreId,
                           Guid id = default)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(descricao))
        {
            throw new ArgumentException("Nome e descrição são obrigatórios.");
        }

        if (orcamento <= 0)
        {
            throw new ArgumentException("Orçamento deve ser maior que zero.");
        }

        return new Projeto
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Nome = nome,
            Descricao = descricao,
            StatusProjeto = statusProjeto,
            DataInicio = dataInicio,
            DataTermino = dataTermino,
            Orcamento = orcamento,
            FaseAtual = faseAtual,
            GerenteTorreId = gerenteTorreId,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public Projeto Atualizar(Projeto projeto,
                             string nome,
                             string descricao,
                             StatusProjeto statusProjeto,
                             DateOnly dataInicio,
                             DateOnly dataTermino,
                             decimal orcamento,
                             FaseAtual faseAtual,
                             Guid gerenteTorreId)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(descricao))
        {
            throw new ArgumentException("Nome e descrição são obrigatórios.");
        }

        if (orcamento <= 0)
        {
            throw new ArgumentException("Orçamento deve ser maior que zero.");
        }

        projeto.Nome = nome;
        projeto.Descricao = descricao;
        projeto.StatusProjeto = statusProjeto;
        projeto.DataInicio = dataInicio;
        projeto.DataTermino = dataTermino;
        projeto.Orcamento = orcamento;
        projeto.FaseAtual = faseAtual;
        projeto.GerenteTorreId = gerenteTorreId;
        projeto.DataAtualizacao = DateTime.UtcNow;

        return projeto;
    }

    public Projeto Remover(Projeto projeto)
    {
        projeto.DataDelecao = DateTime.UtcNow;
        projeto.Ativo = false;

        return projeto;
    }

    public Projeto Ativar(Projeto projeto)
    {
        projeto.Ativo = true;
        projeto.DataDelecao = null;  // Limpa a data de deleção
        projeto.DataAtualizacao = DateTime.UtcNow;

        return projeto;
    }
}
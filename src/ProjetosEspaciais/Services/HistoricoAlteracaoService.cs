namespace ProjetosEspaciais.Services;

public class HistoricoAlteracaoService
{
    public HistoricoAlteracao Inserir(TipoAlteracao tipoAlteracao,
                                      string descricao,
                                      string motivacao,
                                      NivelImpactoAlteracao nivelImpactoAlteracao,
                                      Guid equipeId,
                                      Guid id = default)
    {
        if (string.IsNullOrEmpty(descricao))
        {
            throw new ArgumentException("Descrição não pode ser nula ou vazia", nameof(descricao));
        }

        return new HistoricoAlteracao
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            TipoAlteracao = tipoAlteracao,
            Descricao = descricao,
            Motivacao = motivacao,
            NivelImpactoAlteracao = nivelImpactoAlteracao,
            DataCriacao = DateTime.UtcNow,
            Ativo = true,
            EquipeId = equipeId
        };
    }

    public HistoricoAlteracao Atualizar(HistoricoAlteracao historicoAlteracao,
                                        TipoAlteracao tipoAlteracao,
                                        string descricao,
                                        string motivacao,
                                        NivelImpactoAlteracao nivelImpactoAlteracao,
                                        Guid equipeId)
    {
        if (string.IsNullOrEmpty(descricao))
        {
            throw new ArgumentException("Descrição não pode ser nula ou vazia", nameof(descricao));
        }

        historicoAlteracao.TipoAlteracao = tipoAlteracao;
        historicoAlteracao.Descricao = descricao;
        historicoAlteracao.Motivacao = motivacao;
        historicoAlteracao.NivelImpactoAlteracao = nivelImpactoAlteracao;
        historicoAlteracao.EquipeId = equipeId;
        historicoAlteracao.DataAtualizacao = DateTime.UtcNow;

        return historicoAlteracao;
    }

    public HistoricoAlteracao Remover(HistoricoAlteracao historicoAlteracao)
    {
        historicoAlteracao.DataDelecao = DateTime.UtcNow;
        historicoAlteracao.Ativo = false;

        return historicoAlteracao;
    }

    // Método para listar históricos de alteração
    public List<HistoricoAlteracao> Listar()
    {
        // Aqui você deve conectar com o repositório ou banco de dados para retornar os históricos de alteração
        return new List<HistoricoAlteracao>
        {
            new HistoricoAlteracao
            {
                Id = Guid.NewGuid(),
                TipoAlteracao = TipoAlteracao.Modificacao,
                Descricao = "Alteração na configuração do sistema",
                Motivacao = "Atualização de segurança",
                NivelImpactoAlteracao = NivelImpactoAlteracao.Alto,
                DataCriacao = DateTime.UtcNow,
                Ativo = true,
                EquipeId = Guid.NewGuid()
            }
        };
    }
}
namespace ProjetosEspaciais.Services;

public class MissaoService
{
    public Missao Inserir(string codinome,
                          string descricao,
                          TipoMissao tipoMissao,
                          string objetivo,
                          StatusMissao statusMissao,
                          string duracaoEstimada,
                          decimal custoEstimado,
                          DateOnly dataInicio,
                          Guid projetoId,
                          Guid veiculoId,
                          Guid plataformaId,
                          Guid equipeId,
                          Guid id = default)
    {
        if (string.IsNullOrEmpty(codinome) ||
            string.IsNullOrEmpty(descricao) ||
            string.IsNullOrEmpty(objetivo) ||
            string.IsNullOrEmpty(duracaoEstimada) ||
            custoEstimado <= 0)
        {
            throw new ArgumentException("Os campos obrigatórios não podem ser nulos ou vazios, e o custo estimado deve ser maior que zero.");
        }

        return new Missao
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Codinome = codinome,
            Descricao = descricao,
            TipoMissao = tipoMissao,
            Objetivo = objetivo,
            StatusMissao = statusMissao,
            DuracaoEstimada = duracaoEstimada,
            CustoEstimado = custoEstimado,
            DataInicio = dataInicio,
            DataCriacao = DateTime.UtcNow,
            Ativo = true,
            ProjetoId = projetoId,
            VeiculoId = veiculoId,
            PlataformaId = plataformaId,
            EquipeId = equipeId
        };
    }

    public Missao Atualizar(Missao missao,
                            string codinome,
                            string descricao,
                            TipoMissao tipoMissao,
                            string objetivo,
                            StatusMissao statusMissao,
                            string duracaoEstimada,
                            decimal custoEstimado,
                            DateOnly dataInicio,
                            DateOnly? dataTermino)
    {
        if (string.IsNullOrEmpty(codinome) ||
            string.IsNullOrEmpty(descricao) ||
            string.IsNullOrEmpty(objetivo) ||
            string.IsNullOrEmpty(duracaoEstimada) ||
            custoEstimado <= 0)
        {
            throw new ArgumentException("Os campos obrigatórios não podem ser nulos ou vazios, e o custo estimado deve ser maior que zero.");
        }

        missao.Codinome = codinome;
        missao.Descricao = descricao;
        missao.TipoMissao = tipoMissao;
        missao.Objetivo = objetivo;
        missao.StatusMissao = statusMissao;
        missao.DuracaoEstimada = duracaoEstimada;
        missao.CustoEstimado = custoEstimado;
        missao.DataInicio = dataInicio;
        missao.DataTermino = dataTermino;
        missao.DataAtualizacao = DateTime.UtcNow;

        return missao;
    }

    public Missao Remover(Missao missao)
    {
        missao.DataDelecao = DateTime.UtcNow;
        missao.Ativo = false;

        return missao;
    }

    // Ativar uma missão (restaurar uma missão inativa)
    public Missao Ativar(Missao missao)
    {
        missao.Ativo = true;
        missao.DataDelecao = null; // Remover a data de deleção
        missao.DataAtualizacao = DateTime.UtcNow;

        return missao;
    }

    public void AdicionarTeste(Missao missao, Teste teste)
    {
        missao.Testes.Add(teste);
        missao.DataAtualizacao = DateTime.UtcNow;
    }

    public void AdicionarDocumento(Missao missao, Documento documento)
    {
        missao.Documentos.Add(documento);
        missao.DataAtualizacao = DateTime.UtcNow;
    }

    public void AdicionarHistoricoAlteracao(Missao missao, HistoricoAlteracao historico)
    {
        missao.HistoricoAlteracoes.Add(historico);
        missao.DataAtualizacao = DateTime.UtcNow;
    }

    public void AdicionarLicenca(Missao missao, Licenca licenca)
    {
        missao.Licencas.Add(licenca);
        missao.DataAtualizacao = DateTime.UtcNow;
    }
}
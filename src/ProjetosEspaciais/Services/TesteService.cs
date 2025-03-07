namespace ProjetosEspaciais.Services;

public class TesteService
{
    public Teste Inserir(TipoTeste tipoTeste,
                         string objetivo,
                         DateOnly dataRealizacao,
                         string resultado,
                         string equipamentoUtilizado,
                         string conclusaoRecomendacao,
                         Guid localidadeId,
                         Guid equipeId,
                         Guid plataformaId,
                         Guid historicoAlteracaoId,
                         Guid id = default)
    {
        if (string.IsNullOrEmpty(objetivo) || string.IsNullOrEmpty(resultado))
        {
            throw new ArgumentException("Objetivo e resultado são obrigatórios.");
        }

        return new Teste
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            TipoTeste = tipoTeste,
            Objetivo = objetivo,
            DataRealizacao = dataRealizacao,
            Resultado = resultado,
            EquipamentoUtilizado = equipamentoUtilizado,
            ConclusaoRecomendacao = conclusaoRecomendacao,
            LocalidadeId = localidadeId,
            EquipeId = equipeId,
            PlataformaId = plataformaId,
            HistoricoAlteracaoId = historicoAlteracaoId,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public Teste Atualizar(Teste teste,
                           TipoTeste tipoTeste,
                           string objetivo,
                           DateOnly dataRealizacao,
                           string resultado,
                           string equipamentoUtilizado,
                           string conclusaoRecomendacao,
                           Guid localidadeId,
                           Guid equipeId,
                           Guid plataformaId,
                           Guid historicoAlteracaoId)
    {
        if (string.IsNullOrEmpty(objetivo) || string.IsNullOrEmpty(resultado))
        {
            throw new ArgumentException("Objetivo e resultado são obrigatórios.");
        }

        teste.TipoTeste = tipoTeste;
        teste.Objetivo = objetivo;
        teste.DataRealizacao = dataRealizacao;
        teste.Resultado = resultado;
        teste.EquipamentoUtilizado = equipamentoUtilizado;
        teste.ConclusaoRecomendacao = conclusaoRecomendacao;
        teste.LocalidadeId = localidadeId;
        teste.EquipeId = equipeId;
        teste.PlataformaId = plataformaId;
        teste.HistoricoAlteracaoId = historicoAlteracaoId;
        teste.DataAtualizacao = DateTime.UtcNow;

        return teste;
    }

    public Teste Remover(Teste teste)
    {
        teste.DataDelecao = DateTime.UtcNow;
        teste.Ativo = false;

        return teste;
    }
}
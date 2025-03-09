namespace ProjetosEspaciais.Models;

using ProjetosEspaciais.Enums;

public class Teste
{
    public Guid Id { get; set; }
    public TipoTeste TipoTeste { get; set; }
    public string? Objetivo { get; set; }
    public DateOnly DataRealizacao { get; set; }
    public string? Resultado { get; set; }
    public string? EquipamentoUtilizado { get; set; }
    public string? ConclusaoRecomendacao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid LocalidadeId { get; set; }
    public Localidade Localidade { get; set; }
    public Guid EquipeId { get; set; }
    public Equipe Equipe { get; set; }
    public Guid PlataformaId { get; set; }
    public Plataforma Plataforma { get; set; }

    public static Teste Criar(TipoTeste tipoTeste,
                              string objetivo,
                              DateOnly dataRealizacao,
                              string resultado,
                              string equipamentoUtilizado,
                              string conclusaoRecomendacao,
                              Guid localidadeId,
                              Guid equipeId,
                              Guid plataformaId)
    {
        ValidarCamposObrigatorios(objetivo, resultado, equipamentoUtilizado, conclusaoRecomendacao);
        ValidarEnum(tipoTeste);

        return new Teste
        {
            Id = Guid.NewGuid(),
            TipoTeste = tipoTeste,
            Objetivo = objetivo,
            DataRealizacao = dataRealizacao,
            Resultado = resultado,
            EquipamentoUtilizado = equipamentoUtilizado,
            ConclusaoRecomendacao = conclusaoRecomendacao,
            DataCriacao = DateTime.UtcNow,
            Ativo = true,
            LocalidadeId = localidadeId,
            EquipeId = equipeId,
            PlataformaId = plataformaId
        };
    }

    public void Atualizar(string objetivo,
                          string resultado,
                          string equipamentoUtilizado,
                          string conclusaoRecomendacao,
                          Guid equipeId,
                          Guid plataformaId)
    {
        if (!Ativo)
            throw new InvalidOperationException("Não é possível atualizar um teste desativado.");

        ValidarCamposObrigatorios(objetivo, resultado, equipamentoUtilizado, conclusaoRecomendacao);

        Objetivo = objetivo;
        Resultado = resultado;
        EquipamentoUtilizado = equipamentoUtilizado;
        ConclusaoRecomendacao = conclusaoRecomendacao;
        EquipeId = equipeId;
        PlataformaId = plataformaId;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void Deletar()
    {
        if (!Ativo)
            throw new InvalidOperationException("O teste já está desativado.");

        Ativo = false;
        DataDelecao = DateTime.UtcNow;
    }

    public void Restaurar()
    {
        if (Ativo)
            throw new InvalidOperationException("O teste já está ativo.");

        Ativo = true;
        DataDelecao = null;
        DataAtualizacao = DateTime.UtcNow;
    }

    private static void ValidarCamposObrigatorios(params string[] valores)
    {
        foreach (var valor in valores)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Os campos obrigatórios não podem ser vazios ou nulos.");
        }
    }

    private static void ValidarEnum(TipoTeste valor)
    {
        if (!Enum.IsDefined(typeof(TipoTeste), valor))
            throw new ArgumentException($"O valor '{valor}' não é válido para {nameof(TipoTeste)}.");
    }

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Tipo de Teste: {TipoTeste}
                Objetivo: {Objetivo}
                Data de Realização: {DataRealizacao}
                Resultado: {Resultado}
                Equipamento Utilizado: {EquipamentoUtilizado}
                Conclusão/Recomendação: {ConclusaoRecomendacao}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao?.ToString() ?? "N/A"}
                Data de Deleção: {DataDelecao?.ToString() ?? "N/A"}
                Ativo: {Ativo}
                Localidade: {LocalidadeId}
                Equipe: {EquipeId}
                Plataforma: {PlataformaId}
                ";
    }
}
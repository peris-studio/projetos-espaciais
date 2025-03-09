namespace ProjetosEspaciais.Models;

using ProjetosEspaciais.Enums;

public class Missao
{
    public Guid Id { get; set; }
    public required string Codinome { get; set; }
    public required string Descricao { get; set; }
    public TipoMissao TipoMissao { get; set; }
    public required string Objetivo { get; set; }
    public StatusMissao StatusMissao { get; set; }
    public required string DuracaoEstimada { get; set; }
    public decimal CustoEstimado { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly? DataTermino { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid VeiculoId { get; set; }
    public Veiculo Veiculo { get; set; } = null!;
    public Guid PlataformaId { get; set; }
    public Plataforma Plataforma { get; set; } = null!;
    public Guid EquipeId { get; set; }
    public Equipe Equipe { get; set; } = null!;

    // Listas de entidades relacionadas
    public ICollection<Teste> Testes { get; set; } = new List<Teste>();
    public ICollection<Documento> Documentos { get; set; } = new List<Documento>();
    public ICollection<Licenca> Licencas { get; set; } = new List<Licenca>();

    public static Missao Inserir(string codinome,
                                 string descricao,
                                 TipoMissao tipoMissao,
                                 string objetivo,
                                 StatusMissao statusMissao,
                                 string duracaoEstimada,
                                 decimal custoEstimado,
                                 DateOnly dataInicio,
                                 DateOnly dataTermino,
                                 Guid veiculoId,
                                 Guid plataformaId,
                                 Guid equipeId,
                                 List<Guid>? testesIds = null,
                                 List<Guid>? documentosIds = null,
                                 List<Guid>? licencasIds = null,
                                 Guid id = default)
    {
        ValidarCampoObrigatorio(codinome, nameof(codinome));
        ValidarCampoObrigatorio(descricao, nameof(descricao));
        ValidarCampoObrigatorio(objetivo, nameof(objetivo));
        ValidarCampoObrigatorio(duracaoEstimada, nameof(duracaoEstimada));

        ValidarEnumObrigatorio(tipoMissao, nameof(tipoMissao));
        ValidarEnumObrigatorio(statusMissao, nameof(statusMissao));

        return new Missao
        {
            Id = id == default ? Guid.NewGuid() : id,
            Codinome = codinome,
            Descricao = descricao,
            TipoMissao = tipoMissao,
            Objetivo = objetivo,
            StatusMissao = statusMissao,
            DuracaoEstimada = duracaoEstimada,
            CustoEstimado = custoEstimado,
            DataInicio = dataInicio,
            DataTermino = dataTermino,
            DataCriacao = DateTime.UtcNow,
            Ativo = true,
            VeiculoId = veiculoId,
            PlataformaId = plataformaId,
            EquipeId = equipeId,
            Testes = testesIds?.Select(tid => new Teste { Id = tid }).ToList() ?? new List<Teste>(),
            Documentos = documentosIds?.Select(did => new Documento { Id = did }).ToList() ?? new List<Documento>(),
            Licencas = licencasIds?.Select(lid => new Licenca { Id = lid }).ToList() ?? new List<Licenca>()
        };
    }

    public static Missao Atualizar(Missao missao,
                                   string codinome,
                                   string descricao,
                                   TipoMissao tipoMissao,
                                   string objetivo,
                                   StatusMissao statusMissao,
                                   string duracaoEstimada,
                                   decimal custoEstimado,
                                   DateOnly dataInicio,
                                   DateOnly? dataTermino,
                                   List<Guid>? testesIds,
                                   List<Guid>? documentosIds,
                                   List<Guid>? licencasIds)
    {
        ValidarCampoObrigatorio(codinome, nameof(codinome));
        ValidarCampoObrigatorio(descricao, nameof(descricao));
        ValidarCampoObrigatorio(objetivo, nameof(objetivo));
        ValidarCampoObrigatorio(duracaoEstimada, nameof(duracaoEstimada));

        ValidarEnumObrigatorio(tipoMissao, nameof(tipoMissao));
        ValidarEnumObrigatorio(statusMissao, nameof(statusMissao));

        missao.Codinome = codinome;
        missao.Descricao = descricao;
        missao.TipoMissao = tipoMissao;
        missao.Objetivo = objetivo;
        missao.StatusMissao = statusMissao;
        missao.DuracaoEstimada = duracaoEstimada;
        missao.CustoEstimado = custoEstimado;
        missao.DataInicio = dataInicio;
        missao.DataTermino = dataTermino;
        missao.DataTermino = dataTermino;
        missao.DataAtualizacao = DateTime.UtcNow;

        // Atualiza as listas de IDs
        missao.Testes = testesIds?.Select(tid => new Teste { Id = tid }).ToList() ?? new List<Teste>();
        missao.Documentos = documentosIds?.Select(did => new Documento { Id = did }).ToList() ?? new List<Documento>();
        missao.Licencas = licencasIds?.Select(lid => new Licenca { Id = lid }).ToList() ?? new List<Licenca>();

        return missao;
    }


    public static Missao Deletar(Missao missao)
    {
        if (missao == null)
        {
            throw new ArgumentNullException(nameof(missao), "Missão não pode ser nula.");
        }

        missao.DataDelecao = DateTime.UtcNow;
        missao.Ativo = false;

        return missao;
    }

    public static Missao Restaurar(Missao missao)
    {
        if (missao == null)
        {
            throw new ArgumentNullException(nameof(missao), "Missão não pode ser nula.");
        }

        missao.Ativo = true;
        missao.DataDelecao = null; // Limpa a data de deleção
        missao.DataAtualizacao = DateTime.UtcNow; // Atualiza a data de atualização

        return missao;
    }

    // Método para validar campos obrigatórios
    public static void ValidarCampoObrigatorio(string valor, string nomeCampo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException($"O campo '{nomeCampo}' não pode ser vazio ou conter apenas espaços em branco.", nomeCampo);
        }
    }

    // Método para validar enums
    public static void ValidarEnumObrigatorio<TEnum>(TEnum valor, string nomeCampo)
        where TEnum : Enum
    {
        if (valor == null || !Enum.IsDefined(typeof(TEnum), valor))
        {
            throw new ArgumentException($"O valor do campo '{nomeCampo}' não é válido para o enum {typeof(TEnum).Name}.");
        }
    }

    public override string ToString()
    {
        return $@"
            Id: {Id}
            Codinome: {Codinome}
            Descrição: {Descricao}
            Tipo de Missão: {TipoMissao}
            Objetivo: {Objetivo}
            Status: {StatusMissao}
            Veículo: {VeiculoId}
            Plataforma: {PlataformaId}
            Equipe Responsável: {EquipeId}
            Testes: [{string.Join(", ", Testes.Select(t => t.Id))}]
            Documentos: [{string.Join(", ", Documentos.Select(d => d.Id))}]
            Licenças: [{string.Join(", ", Licencas.Select(l => l.Id))}]
            Duração Estimada: {DuracaoEstimada}
            Custo Estimado: {CustoEstimado}
            Data de Início: {DataInicio}
            Data de Término: {DataTermino}
            -
            Data de Criação: {DataCriacao}
            Data de Atualização: {DataAtualizacao}
            Data de Deleção: {DataDelecao}
            Ativo: {Ativo}
        ";
    }
}
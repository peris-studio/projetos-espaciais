namespace ProjetosEspaciais.Models;

using Microsoft.EntityFrameworkCore.Storage;
using ProjetosEspaciais.Enums;

public class Projeto
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public StatusProjeto StatusProjeto { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly DataTermino { get; set; }
    public decimal Orcamento { get; set; }
    public FaseAtual FaseAtual { get; set; }
    public Guid GerenteTorreId { get; set; }
    public Guid MissaoId { get; set; }
    public Missao? Missao { get; set; }
    public List<Missao> Missoes { get; set; } = new List<Missao>();
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public static Projeto Inserir(string nome,
                                  string descricao,
                                  StatusProjeto statusProjeto,
                                  DateOnly dataInicio,
                                  DateOnly dataTermino,
                                  decimal orcamento,
                                  FaseAtual faseAtual,
                                  Guid gerenteTorreId,
                                  List<Missao> missoes)
    {
        ValidarCamposObrigatorios(nome, nameof(nome));
        ValidarCamposObrigatorios(descricao, nameof(descricao));
        ValidarEnums(statusProjeto, faseAtual);

        return new Projeto
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Descricao = descricao,
            StatusProjeto = statusProjeto,
            DataInicio = dataInicio,
            DataTermino = dataTermino,
            Orcamento = orcamento,
            FaseAtual = faseAtual,
            GerenteTorreId = gerenteTorreId,
            Missoes = missoes,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public static Projeto Atualizar(Projeto projeto,
                                            string nome,
                                            string descricao,
                                            StatusProjeto statusProjeto,
                                            DateOnly dataInicio,
                                            DateOnly dataTermino,
                                            decimal orcamento,
                                            FaseAtual faseAtual,
                                            Guid gerenteTorreId,
                                            List<Missao> missoes)
    {
        if (!projeto.Ativo)
            throw new InvalidOperationException("Não é possível atualizar um projeto desativado.");

        ValidarCamposObrigatorios(nome, nameof(nome));
        ValidarCamposObrigatorios(descricao, nameof(descricao));
        ValidarEnums(statusProjeto, faseAtual);

        projeto.Nome = nome;
        projeto.Descricao = descricao;
        projeto.StatusProjeto = statusProjeto;
        projeto.DataInicio = dataInicio;
        projeto.DataTermino = dataTermino;
        projeto.Orcamento = orcamento;
        projeto.FaseAtual = faseAtual;
        projeto.GerenteTorreId = gerenteTorreId;
        projeto.Missoes = missoes;
        projeto.DataAtualizacao = DateTime.UtcNow;

        return projeto;
    }

    public static Projeto Deletar(Projeto projeto)
    {
        if (projeto == null)
            throw new ArgumentNullException(nameof(projeto), "O projeto não pode ser nulo.");

        projeto.Ativo = false;
        projeto.DataDelecao = DateTime.UtcNow;

        return projeto;
    }

    public static Projeto Restaurar(Projeto projeto)
    {
        if (projeto.Ativo)
            throw new InvalidOperationException("O projeto já está ativo.");

        projeto.Ativo = true;
        projeto.DataDelecao = null;
        projeto.DataAtualizacao = DateTime.UtcNow;

        return projeto;
    }

    public static void ValidarCamposObrigatorios(params string[] valores)
    {
        foreach (var valor in valores)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Os campos obrigatórios não podem ser vazios ou nulos.");
        }
    }

    public static void ValidarEnums(params Enum[] valoresEnums)
    {
        foreach (var valorEnum in valoresEnums)
        {
            if (!Enum.IsDefined(valorEnum.GetType(), valorEnum))
                throw new ArgumentException($"O valor '{valorEnum}' não é válido para {valorEnum.GetType().Name}.");
        }
    }

    public override string ToString()
    {
        return $@"
                Nome: {Nome}
                Descrição: {Descricao}
                Status: {StatusProjeto}
                Orçamento: {Orcamento}
                Fase Atual: {FaseAtual}
                Gerente de Torre ID: {GerenteTorreId}
                Missões: {(Missoes.Any() ? string.Join(", ", Missoes.Select(m => m.Codinome)) : "Nenhuma")}
                Data de Início: {DataInicio}
                Data Prevista de Término: {DataTermino}
                -
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao?.ToString() ?? "N/A"}
                Data de Deleção: {DataDelecao?.ToString() ?? "N/A"}
                Ativo: {Ativo}
                ";
    }
}
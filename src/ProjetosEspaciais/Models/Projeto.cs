namespace ProjetosEspaciais.Models;

public class Projeto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public StatusProjeto StatusProjeto { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly DataTermino { get; set; }
    public decimal Orcamento { get; set; }
    public FaseAtual FaseAtual { get; set; }
    public Guid GerenteTorreId { get; set; } // Referência ao ID do membro
    public Membro Membro { get; set; } // Propriedade de navegação opcional
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }

    public override string ToString()
    {
        return $@"
                Nome: {Nome}
                Descricao: {Descricao}
                Status: {StatusProjeto}
                Orçamento: {Orcamento}
                Fase Atual: {FaseAtual}
                Gerente de Torre: {GerenteTorreId}
                Data de Início: {DataInicio}
                Data Prevista de Término: {DataTermino}
                -
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                ";
    }
}
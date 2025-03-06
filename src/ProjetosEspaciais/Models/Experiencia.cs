namespace ProjetosEspaciais.Models;

public class Experiencia
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; }
    public StatusExperiencia Status { get; set; } = null!;
    public DateOnly DataInicio { get; set; } = null!;
    public DateOnly DataTermino { get; set; }
    public DateTime DataCriacao { get; set; } = null!;
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        string status = Ativo ? "Sim" : "Não"
        return $@"
                Título: {TipoContato}
                Descrição: {Contato}
                Status: {Status}
                Data de Início: {DataInicio}
                Data de Previsao e/ou Término: {DataTermino}
                Data de Criação: {DataCriacao}
                Data da Última Atualização {DataAtualizacao}
                Data de Delecao: {DataDelecao}
                ";
    }
}
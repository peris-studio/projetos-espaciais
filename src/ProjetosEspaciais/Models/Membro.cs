namespace ProjetosEspaciais.Models;

public class Membro
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public CargoMembro CargoMembro { get; set; }
    public string Funcao { get; set; }
    public string Especialidade { get; set; }
    public string Identificador { get; set; }
    public string Senha { get; set; }
    public Genero Genero { get; set; }
    public DateOnly DataNascimento { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Nome Completo: {NomeCompleto}
                Cargo: {CargoMembro}
                Função: {Funcao}
                Especialidade: {Especialidade}
                Identificador: {Identificador}
                Senha: {Senha}
                Gênero: {Genero}
                Data de Nascimento: {DataNascimento}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                Ativo: {Ativo}
            ";
    }
}

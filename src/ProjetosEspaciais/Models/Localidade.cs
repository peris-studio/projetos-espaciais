namespace ProjetosEspaciais.Models;

public class Localidade
{
    public Guid Id { get; set; }
    public string Sede { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public string EnderecoCompleto { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Sede: {Sede}
                Cidade: {Cidade}
                Estado: {Estado}
                País: {Pais}
                Endereço Completo: {EnderecoCompleto}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                Ativo: {Ativo}
            ";
    }
}
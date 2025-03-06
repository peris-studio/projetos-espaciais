namespace ProjetosEspaciais.Models;

public class Veiculo
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Marca { get; set; }
    public string Ano { get; set; }
    public string Cor { get; set; }
    public TipoVeiculo TipoVeiculo { get; set; }
    public TipoCombustivel TipoCombustivel { get; set; }
    public TipoTransmissao TipoTransmissao { get; set; }
    public string Capacidade { get; set; }
    public string EspecificacaoTecnicaExtra { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Nome: {Nome}
                Placa: {Placa}
                Marca: {Marca}
                Ano: {Ano}
                Cor: {Cor}
                Tipo de Veículo: {TipoVeiculo}
                Tipo de Combustível: {TipoCombustivel}
                Tipo de Transmissão: {TipoTransmissao}
                Capacidade: {Capacidade}
                Especificação Técnica Extra: {EspecificacaoTecnicaExtra}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                Ativo: {(Ativo ? "Sim" : "Não")}
                ";
    }
}
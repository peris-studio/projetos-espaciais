namespace ProjetosEspaciais.Services;

public class VeiculoService
{
    public Veiculo Inserir(string nome,
                           string placa,
                           string marca,
                           string modelo,
                           string ano,
                           string cor,
                           TipoVeiculo tipoVeiculo,
                           TipoCombustivel tipoCombustivel,
                           TipoTransmissao tipoTransmissao,
                           string capacidade,
                           string especificacaoTecnicaExtra,
                           Guid id = default)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(placa))
        {
            throw new ArgumentException("Nome e placa são obrigatórios.");
        }

        return new Veiculo
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Nome = nome,
            Placa = placa,
            Marca = marca,
            Modelo = modelo,
            Ano = ano,
            Cor = cor,
            TipoVeiculo = tipoVeiculo,
            TipoCombustivel = tipoCombustivel,
            TipoTransmissao = tipoTransmissao,
            Capacidade = capacidade,
            EspecificacaoTecnicaExtra = especificacaoTecnicaExtra,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public Veiculo Atualizar(Veiculo veiculo,
                             string nome,
                             string placa,
                             string marca,
                             string modelo,
                             string ano,
                             string cor,
                             TipoVeiculo tipoVeiculo,
                             TipoCombustivel tipoCombustivel,
                             TipoTransmissao tipoTransmissao,
                             string capacidade,
                             string especificacaoTecnicaExtra)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(placa))
        {
            throw new ArgumentException("Nome e placa são obrigatórios.");
        }

        veiculo.Nome = nome;
        veiculo.Placa = placa;
        veiculo.Marca = marca;
        veiculo.Modelo = modelo;
        veiculo.Ano = ano;
        veiculo.Cor = cor;
        veiculo.TipoVeiculo = tipoVeiculo;
        veiculo.TipoCombustivel = tipoCombustivel;
        veiculo.TipoTransmissao = tipoTransmissao;
        veiculo.Capacidade = capacidade;
        veiculo.EspecificacaoTecnicaExtra = especificacaoTecnicaExtra;
        veiculo.DataAtualizacao = DateTime.UtcNow;

        return veiculo;
    }

    public Veiculo Remover(Veiculo veiculo)
    {
        veiculo.DataDelecao = DateTime.UtcNow;
        veiculo.Ativo = false;

        return veiculo;
    }
}
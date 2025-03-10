namespace ProjetosEspaciais.Models;

using ProjetosEspaciais.Enums;
using System;

public class Veiculo
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Ano { get; set; }
    public string Cor { get; set; }
    public TipoVeiculo TipoVeiculo { get; set; }
    public TipoCombustivel TipoCombustivel { get; set; }
    public TipoTransmissao TipoTransmissao { get; set; }
    public StatusVeiculo StatusVeiculo { get; set; }
    public string Capacidade { get; set; }
    public string EspecificacaoTecnicaExtra { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    // Método para inserir um novo veículo
    public static Veiculo Inserir(string nome,
                                  string placa,
                                  string marca,
                                  string modelo,
                                  string ano,
                                  string cor,
                                  TipoVeiculo tipoVeiculo,
                                  TipoCombustivel tipoCombustivel,
                                  TipoTransmissao tipoTransmissao,
                                  StatusVeiculo statusVeiculo,
                                  string capacidade,
                                  string especificacaoTecnicaExtra)
    {
        // Valida os campos obrigatórios
        ValidarCamposObrigatorios(nome, placa, marca, modelo, ano, cor, capacidade);
        ValidarEnums(tipoVeiculo, tipoCombustivel, tipoTransmissao, statusVeiculo);

        return new Veiculo
        {
            Id = Guid.NewGuid(),
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

    // Método para atualizar um veículo existente
    public static Veiculo Atualizar(Veiculo veiculo,
                                    string nome,
                                    string placa,
                                    string marca,
                                    string modelo,
                                    string ano,
                                    string cor,
                                    TipoVeiculo tipoVeiculo,
                                    TipoCombustivel tipoCombustivel,
                                    TipoTransmissao tipoTransmissao,
                                    StatusVeiculo statusVeiculo,
                                    string capacidade,
                                    string especificacaoTecnicaExtra)
    {
        // Valida os campos obrigatórios
        ValidarCamposObrigatorios(nome, placa, marca, modelo, ano, cor, capacidade);
        ValidarEnums(tipoCombustivel, tipoTransmissao, statusVeiculo);

        // Atualiza os valores do veículo
        veiculo.Nome = nome;
        veiculo.Placa = placa;
        veiculo.Marca = marca;
        veiculo.Modelo = modelo;
        veiculo.Ano = ano;
        veiculo.Cor = cor;
        veiculo.TipoVeiculo = tipoVeiculo;
        veiculo.TipoCombustivel = tipoCombustivel;
        veiculo.TipoTransmissao = tipoTransmissao;
        veiculo.StatusVeiculo = statusVeiculo;
        veiculo.Capacidade = capacidade;
        veiculo.EspecificacaoTecnicaExtra = especificacaoTecnicaExtra;
        veiculo.DataAtualizacao = DateTime.UtcNow;

        return veiculo;
    }

    // Método para deletar (desativar) um veículo
    public static Veiculo Deletar(Veiculo veiculo)
    {
        if (!veiculo.Ativo)
            throw new InvalidOperationException("O veículo já está desativado.");

        veiculo.Ativo = false;
        veiculo.DataDelecao = DateTime.UtcNow;

        return veiculo;
    }

    // Método para restaurar (reativar) um veículo excluído
    public void Restaurar(Veiculo veiculo)
    {
        if (veiculo.Ativo)
            throw new InvalidOperationException("O veículo já está ativo.");

        veiculo.Ativo = true;
        veiculo.DataDelecao = null;
        veiculo.DataAtualizacao = DateTime.UtcNow;
    }

    // Validação de campos obrigatórios
    public static void ValidarCamposObrigatorios(params string[] valores)
    {
        foreach (var valor in valores)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Os campos obrigatórios não podem ser vazios.");
        }
    }

    // Validação de enums
    public static void ValidarEnums(params Enum[] valores)
    {
        foreach (var valor in valores)
        {
            if (!Enum.IsDefined(valor.GetType(), valor))
                throw new ArgumentException($"O valor '{valor}' não é válido para o tipo {valor.GetType().Name}.");
        }
    }

    // Método para representar o veículo como string
    public override string ToString()
    {
        return $@"
                Id: {Id}
                Nome: {Nome}
                Placa: {Placa}
                Marca: {Marca}
                Modelo: {Modelo}
                Ano: {Ano}
                Cor: {Cor}
                Tipo de Veículo: {TipoVeiculo}
                Tipo de Combustível: {TipoCombustivel}
                Tipo de Transmissão: {TipoTransmissao}
                Status do Veículo: {StatusVeiculo}
                Capacidade: {Capacidade}
                Especificação Técnica Extra: {EspecificacaoTecnicaExtra}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao?.ToString() ?? "N/A"}
                Data de Deleção: {DataDelecao?.ToString() ?? "N/A"}
                Ativo: {(Ativo ? "Sim" : "Não")}
                ";
    }
}
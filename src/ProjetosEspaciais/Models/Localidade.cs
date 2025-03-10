using System.Runtime.CompilerServices;
using YamlDotNet.Serialization;

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

    public static Localidade Inserir(string sede, string cidade, string estado, string pais, string enderecoCompleto, Guid id = default)
    {
        ValidarCampoObrigatorio(sede, nameof(sede));
        ValidarCampoObrigatorio(cidade, nameof(cidade));
        ValidarCampoObrigatorio(estado, nameof(estado));
        ValidarCampoObrigatorio(pais, nameof(pais));
        ValidarCampoObrigatorio(enderecoCompleto, nameof(enderecoCompleto));

        return new Localidade
        {
            Sede = sede,
            Cidade = cidade,
            Estado = estado,
            Pais = pais,
            EnderecoCompleto = enderecoCompleto,
            Id = id == default ? Guid.NewGuid() : id
        };
    }
    public static Localidade Atualizar(Localidade localidade,
                                    string sede,
                                    string cidade,
                                    string estado,
                                    string pais,
                                    string enderecoCompleto)
    {
        ValidarCampoObrigatorio(sede, nameof(sede));
        ValidarCampoObrigatorio(cidade, nameof(cidade));
        ValidarCampoObrigatorio(estado, nameof(estado));
        ValidarCampoObrigatorio(pais, nameof(pais));
        ValidarCampoObrigatorio(enderecoCompleto, nameof(enderecoCompleto));

        localidade.Sede = sede;
        localidade.Cidade = cidade;
        localidade.Estado = estado;
        localidade.Pais = pais;
        localidade.EnderecoCompleto = enderecoCompleto;
        localidade.DataAtualizacao = DateTime.UtcNow;

        return localidade;
    }

    public static Localidade Deletar(Localidade localidade)
    {
        if (localidade == null)
        {
            throw new ArgumentNullException(nameof(localidade), "Licença não pode ser nula");
        }

        localidade.DataDelecao = DateTime.UtcNow;
        localidade.Ativo = false;

        return localidade;
    }

    public static void ValidarCampoObrigatorio(string valor, string nomeCampo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException($"O campo '{nomeCampo}' não pode ser vazio ou conter apenas espaços em branco.", nomeCampo);
    }

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
namespace ProjetosEspaciais.Models;

using ProjetosEspaciais.Enums;

public class Membro
{
    public Guid Id { get; set; }
    public required string NomeCompleto { get; set; }
    public required string Funcao { get; set; }
    public required string Especialidade { get; set; }
    public required string Identificador { get; set; }
    public required string Senha { get; set; }
    public Genero Genero { get; set; }
    public DateOnly DataNascimento { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public static Membro Inserir(string nomeCompleto, string funcao, string especialidade, string identificador, string senha, Genero genero, DateOnly dataNascimento, Guid id = default)
    {
        ValidarCampoObrigatorio(nomeCompleto, nameof(nomeCompleto));
        ValidarCampoObrigatorio(funcao, nameof(funcao));
        ValidarCampoObrigatorio(especialidade, nameof(especialidade));
        ValidarCampoObrigatorio(identificador, nameof(identificador));
        ValidarCampoObrigatorio(senha, nameof(senha));
        ValidarCampoObrigatorio(genero.ToString(), nameof(genero));
        ValidarCampoObrigatorio(dataNascimento.ToString(), nameof(dataNascimento));

        return new Membro
        {
            Id = id == default ? Guid.NewGuid() : id,
            NomeCompleto = nomeCompleto,
            Funcao = funcao,
            Especialidade = especialidade,
            Identificador = identificador,
            Senha = senha,
            Genero = genero,
            DataNascimento = dataNascimento,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public static Membro Atualizar(Membro membro,
                                   string nomeCompleto,
                                   string funcao,
                                   string especialidade,
                                   string identificador,
                                   string senha,
                                   Genero genero,
                                   DateOnly dataNascimento)
    {
        ValidarCampoObrigatorio(nomeCompleto, nameof(nomeCompleto));
        ValidarCampoObrigatorio(funcao, nameof(funcao));
        ValidarCampoObrigatorio(especialidade, nameof(especialidade));
        ValidarCampoObrigatorio(identificador, nameof(identificador));
        ValidarCampoObrigatorio(senha, nameof(senha));
        ValidarCampoObrigatorio(genero.ToString(), nameof(genero));
        ValidarCampoObrigatorio(dataNascimento.ToString(), nameof(dataNascimento));

        membro.NomeCompleto = nomeCompleto;
        membro.Funcao = funcao;
        membro.Especialidade = especialidade;
        membro.Identificador = identificador;
        membro.Senha = senha;
        membro.Genero = genero;
        membro.DataNascimento = dataNascimento;
        membro.DataAtualizacao = DateTime.UtcNow;

        return membro;
    }

    public static Membro Deletar(Membro membro)
    {
        if (membro == null)
        {
            throw new ArgumentNullException(nameof(membro), "Membro não pode ser nulo.");
        }

        membro.DataDelecao = DateTime.UtcNow;
        membro.Ativo = false;

        return membro;
    }

    // Método para validar campos obrigatórios
    public static void ValidarCampoObrigatorio(string valor, string nomeCampo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException($"O campo '{nomeCampo}' não pode ser vazio ou conter apenas espaços em branco.", nomeCampo);
        }
    }

    // método para validar enum obrigatório
    public static void ValidarEnums(params Enum[] valores)
    {
        foreach (var valor in valores)
        {
            if (!Enum.IsDefined(valor.GetType(), valor))
                throw new ArgumentException($"O valor '{valor}' não é válido para o tipo {valor.GetType().Name}.");
        }
    }

    // Método ToString para exibir os detalhes do membro
    public override string ToString()
    {
        return $@"
                Id: {Id}
                Nome Completo: {NomeCompleto}
                Função: {Funcao}
                Especialidade: {Especialidade}
                Identificador: {Identificador}
                Senha: {"*".PadLeft(Senha.Length, '*')}
                Gênero: {Genero}
                Data de Nascimento: {DataNascimento}
                -
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao}
                Data de Deleção: {DataDelecao}
                Ativo: {Ativo}
            ";
    }
}

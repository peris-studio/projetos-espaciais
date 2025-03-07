namespace ProjetosEspaciais.Services;

public class MembroService
{
    // Inserir um novo membro
    public Membro Inserir(string nomeCompleto,
                          CargoMembro cargoMembro,
                          string funcao,
                          string especialidade,
                          string identificador,
                          string senha,
                          Genero genero,
                          DateOnly dataNascimento,
                          Guid id = default)
    {
        if (string.IsNullOrEmpty(nomeCompleto) ||
            string.IsNullOrEmpty(funcao) ||
            string.IsNullOrEmpty(especialidade) ||
            string.IsNullOrEmpty(identificador) ||
            string.IsNullOrEmpty(senha))
        {
            throw new ArgumentException("Os campos obrigatórios não podem ser nulos ou vazios.");
        }

        // Aqui você deveria aplicar uma técnica de hashing para a senha, como bcrypt.
        string senhaHash = HashSenha(senha);

        return new Membro
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            NomeCompleto = nomeCompleto,
            CargoMembro = cargoMembro,
            Funcao = funcao,
            Especialidade = especialidade,
            Identificador = identificador,
            Senha = senhaHash, // Senha deve ser salva de forma segura (hash)
            Genero = genero,
            DataNascimento = dataNascimento,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    // Atualizar os dados de um membro
    public Membro Atualizar(Membro membro,
                            string nomeCompleto,
                            CargoMembro cargoMembro,
                            string funcao,
                            string especialidade,
                            string identificador,
                            string senha,
                            Genero genero,
                            DateOnly dataNascimento)
    {
        if (string.IsNullOrEmpty(nomeCompleto) ||
            string.IsNullOrEmpty(funcao) ||
            string.IsNullOrEmpty(especialidade) ||
            string.IsNullOrEmpty(identificador) ||
            string.IsNullOrEmpty(senha))
        {
            throw new ArgumentException("Os campos obrigatórios não podem ser nulos ou vazios.");
        }

        membro.NomeCompleto = nomeCompleto;
        membro.CargoMembro = cargoMembro;
        membro.Funcao = funcao;
        membro.Especialidade = especialidade;
        membro.Identificador = identificador;
        membro.Senha = senhaHash;
        membro.Genero = genero;
        membro.DataNascimento = dataNascimento;
        membro.DataAtualizacao = DateTime.UtcNow;

        return membro;
    }

    public Membro Remover(Membro membro)
    {
        membro.DataDelecao = DateTime.UtcNow;
        membro.Ativo = false;

        return membro;
    }
}
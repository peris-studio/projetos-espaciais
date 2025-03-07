namespace ProjetosEspaciais.Services;

public class PlataformaService
{
    public Plataforma Inserir(string nome,
                              string descricao,
                              TipoPlataforma tipoPlataforma,
                              decimal coordenadaLatitude,
                              decimal coordenadaAltitude,
                              StatusPlataforma statusPlataforma,
                              Guid id = default)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(descricao))
        {
            throw new ArgumentException("Nome e descrição são obrigatórios.");
        }

        if (coordenadaLatitude == 0 || coordenadaAltitude == 0)
        {
            throw new ArgumentException("As coordenadas de latitude e altitude devem ser válidas.");
        }

        return new Plataforma
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Nome = nome,
            Descricao = descricao,
            TipoPlataforma = tipoPlataforma,
            CoordenadaLatitude = coordenadaLatitude,
            CoordenadaAltitude = coordenadaAltitude,
            StatusPlataforma = statusPlataforma,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public Plataforma Atualizar(Plataforma plataforma,
                                string nome,
                                string descricao,
                                TipoPlataforma tipoPlataforma,
                                decimal coordenadaLatitude,
                                decimal coordenadaAltitude,
                                StatusPlataforma statusPlataforma)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(descricao))
        {
            throw new ArgumentException("Nome e descrição são obrigatórios.");
        }

        if (coordenadaLatitude == 0 || coordenadaAltitude == 0)
        {
            throw new ArgumentException("As coordenadas de latitude e altitude devem ser válidas.");
        }

        plataforma.Nome = nome;
        plataforma.Descricao = descricao;
        plataforma.TipoPlataforma = tipoPlataforma;
        plataforma.CoordenadaLatitude = coordenadaLatitude;
        plataforma.CoordenadaAltitude = coordenadaAltitude;
        plataforma.StatusPlataforma = statusPlataforma;
        plataforma.DataAtualizacao = DateTime.UtcNow;

        return plataforma;
    }

    public Plataforma Remover(Plataforma plataforma)
    {
        plataforma.DataDelecao = DateTime.UtcNow;
        plataforma.Ativo = false;

        return plataforma;
    }

    // Ativar uma plataforma (restaurar uma plataforma inativa)
    public Plataforma Ativar(Plataforma plataforma)
    {
        plataforma.Ativo = true;
        plataforma.DataDelecao = null; // Remover a data de deleção
        plataforma.DataAtualizacao = DateTime.UtcNow;

        return plataforma;
    }
}
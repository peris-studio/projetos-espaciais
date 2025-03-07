namespace ProjetosEspaciais.Services;

public class ExperienciaService
{
    public Experiencia Inserir(string titulo, string descricao, StatusExperiencia statusExperiencia, DateOnly dataInicio, DateOnly? dataTermino = null, Guid id = default)
    {
        if (string.IsNullOrEmpty(titulo))
        {
            throw new ArgumentException("Título não pode ser nulo ou vazio", nameof(titulo));
        }

        return new Experiencia
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Titulo = titulo,
            Descricao = descricao,
            StatusExperiencia = statusExperiencia,
            DataInicio = dataInicio,
            DataTermino = dataTermino,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public Experiencia Atualizar(Experiencia experiencia, string novoTitulo, string novaDescricao, StatusExperiencia novoStatus, DateOnly novaDataInicio, DateOnly? novaDataTermino = null)
    {
        if (string.IsNullOrEmpty(novoTitulo))
        {
            throw new ArgumentException("Título não pode ser nulo ou vazio", nameof(novoTitulo));
        }

        experiencia.Titulo = novoTitulo;
        experiencia.Descricao = novaDescricao;
        experiencia.StatusExperiencia = novoStatus;
        experiencia.DataInicio = novaDataInicio;
        experiencia.DataTermino = novaDataTermino;
        experiencia.DataAtualizacao = DateTime.UtcNow;

        return experiencia;
    }

    public Experiencia Remover(Experiencia experiencia)
    {
        experiencia.DataDelecao = DateTime.UtcNow;  // Define a data de deleção
        experiencia.Ativo = false;  // Marca como inativo

        return experiencia;
    }
}
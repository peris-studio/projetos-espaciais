namespace ProjetosEspaciais.Models;

public class MissaoLicencas
{
    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Ativo { get; set; }
    public Guid MissaoId { get; set; }
    public Missao Missao { get; set; } = null!;
    public Guid LicencaId { get; set; }
    public Licenca Licenca { get; set; } = null!;

    public static MissaoLicencas Inserir(Guid missaoId, Guid licencaId, Guid id = default)
    {
        return new MissaoLicencas
        {
            Id = id == default ? Guid.NewGuid() : id,
            DataCriacao = DateTime.UtcNow,
            Ativo = true,
            MissaoId = missaoId,
            LicencaId = licencaId,
        };
    }
}

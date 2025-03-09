using ProjetosEspaciais.Mappings;

namespace ProjetosEspaciais.Context;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Contato> Contatos { get; set; } = null!;
    public DbSet<Licenca> Licencas { get; set; } = null!;
    public DbSet<Localidade> Localidades { get; set; } = null!;
    public DbSet<Membro> Membros { get; set; } = null!;
    public DbSet<Plataforma> Plataformas { get; set; } = null!;
    public DbSet<Veiculo> Veiculos { get; set; } = null!;
    public DbSet<Equipe> Equipes { get; set; } = null!;
    public DbSet<Documento> Documentos { get; set; } = null!;
    public DbSet<Teste> Testes { get; set; } = null!;
    public DbSet<Missao> Missoes { get; set; } = null!;
    public DbSet<Projeto> Projetos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // mapeamentos
        modelBuilder.ApplyConfiguration(new ContatoMap());
        modelBuilder.ApplyConfiguration(new LicencaMap());
        modelBuilder.ApplyConfiguration(new LocalidadeMap());
        modelBuilder.ApplyConfiguration(new MembroMap());
        modelBuilder.ApplyConfiguration(new PlataformaMap());
        modelBuilder.ApplyConfiguration(new VeiculoMap());
        modelBuilder.ApplyConfiguration(new EquipeMap());
        modelBuilder.ApplyConfiguration(new DocumentoMap());
        modelBuilder.ApplyConfiguration(new TesteMap());
        modelBuilder.ApplyConfiguration(new MissaoMap());
        modelBuilder.ApplyConfiguration(new ProjetoMap());

        // Filtro automático para só trazer registros ativos
        modelBuilder.Entity<Contato>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Licenca>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Localidade>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Membro>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Plataforma>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Veiculo>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Equipe>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Documento>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Teste>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Missao>().HasQueryFilter(x => x.Ativo);
        modelBuilder.Entity<Projeto>().HasQueryFilter(x => x.Ativo);

        // para buscar inativos, use .IgnoreQueryFilters()
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    public new async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}
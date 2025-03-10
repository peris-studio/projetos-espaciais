namespace ProjetosEspaciais.Mappings;

public class MissaoLicencasMap : IEntityTypeConfiguration<MissaoLicencas>
{
    public void Configure(EntityTypeBuilder<MissaoLicencas> builder)
    {
        builder.HasKey(m => m.Id);

        // Propriedades
        builder.Property(m => m.Id)
               .IsRequired()
               .ValueGeneratedNever();

        // Relacionamentos com outras entidades
        builder.HasOne(m => m.Missao)
               .WithMany()
               .HasForeignKey(m => m.MissaoId)
               .IsRequired();

        builder.HasOne(m => m.Licenca)
               .WithMany()
               .HasForeignKey(m => m.LicencaId)
               .IsRequired();
    }
}
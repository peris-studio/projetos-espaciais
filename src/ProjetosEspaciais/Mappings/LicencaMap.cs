namespace ProjetosEspaciais.Mappings;

public class LicencaMap : IEntityTypeConfiguration<Licenca>
{
    public void Configure(EntityTypeBuilder<Licenca> builder)
    {
        builder.HasKey(l => l.Id);

        // propriedades
        builder.Property(l => l.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
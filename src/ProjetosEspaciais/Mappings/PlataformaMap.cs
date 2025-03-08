namespace ProjetosEspaciais.Mappings;

public class PlataformaMap : IEntityTypeConfiguration<Plataforma>
{
    public void Configure(EntityTypeBuilder<Plataforma> builder)
    {
        builder.HasKey(p => p.Id);

        // propriedades
        builder.Property(p => p.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
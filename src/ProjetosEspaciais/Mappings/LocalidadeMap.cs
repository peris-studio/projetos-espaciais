namespace ProjetosEspaciais.Mappings;

public class LocalidadeMap : IEntityTypeConfiguration<Localidade>
{
    public void Configure(EntityTypeBuilder<Localidade> builder)
    {
        builder.HasKey(l => l.Id);

        // propriedades
        builder.Property(l => l.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
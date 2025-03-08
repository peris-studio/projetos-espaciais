namespace ProjetosEspaciais.Mappings;

public class DocumentoMap : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.HasKey(d => d.Id);

        // propriedades
        builder.Property(d => d.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
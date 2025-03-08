namespace ProjetosEspaciais.Mappings;

public class ContatoMap : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.HasKey(c => c.Id);

        // propriedades
        builder.Property(c => c.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
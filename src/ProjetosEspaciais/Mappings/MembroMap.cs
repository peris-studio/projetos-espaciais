namespace ProjetosEspaciais.Mappings;

public class MembroMap : IEntityTypeConfiguration<Membro>
{
    public void Configure(EntityTypeBuilder<Membro> builder)
    {
        builder.HasKey(m => m.Id);

        // propriedades
        builder.Property(m => m.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
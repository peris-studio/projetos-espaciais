namespace ProjetosEspaciais.Mappings;

public class EquipeMap : IEntityTypeConfiguration<Equipe>
{
    public void Configure(EntityTypeBuilder<Equipe> builder)
    {
        builder.HasKey(e => e.Id);

        // propriedades
        builder.Property(e => e.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
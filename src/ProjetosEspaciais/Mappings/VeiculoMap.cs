namespace ProjetosEspaciais.Mappings;

public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.HasKey(v => v.Id);

        // propriedades
        builder.Property(v => v.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável
    }
}
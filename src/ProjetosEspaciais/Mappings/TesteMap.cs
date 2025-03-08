namespace ProjetosEspaciais.Mappings;

public class TesteMap : IEntityTypeConfiguration<Teste>
{
       public void Configure(EntityTypeBuilder<Teste> builder)
       {
              builder.HasKey(t => t.Id);

              // propriedades
              builder.Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedNever();  // chave autoincrementável

              // relacionamento-entidade
              builder.HasOne(id => id.Localidade)
                     .WithMany()
                     .HasForeignKey(id => id.LocalidadeId);

              builder.HasOne(id => id.Plataforma)
                     .WithMany()
                     .HasOne(id => id.PlataformaId);

              builder.HasOne(id => id.Equipe)
                     .WithMany()
                     .HasOne(id => id.EquipeId);
       }
}
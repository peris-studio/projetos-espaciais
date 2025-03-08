namespace ProjetosEspaciais.Mappings;

public class ProjetoMap : IEntityTypeConfiguration<Projeto>
{
       public void Configure(EntityTypeBuilder<Projeto> builder)
       {
              builder.HasKey(p => p.Id);

              // propriedades
              builder.Property(p => p.Id)
                     .IsRequired()
                     .ValueGeneratedNever();  // chave autoincrementável

              // relacionamento-entidade
              builder.HasOne(id => id.Missao)
                     .WithMany()
                     .HasForeignKey(id => id.MissaoId);

              builder.HasOne(id => id.Membro)
                     .WithMany()
                     .HasOne(id => id.MembroId);
       }
}
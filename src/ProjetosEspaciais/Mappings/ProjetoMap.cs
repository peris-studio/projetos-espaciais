namespace ProjetosEspaciais.Mappings;


public class ProjetoMap : IEntityTypeConfiguration<Projeto>
{
       public void Configure(EntityTypeBuilder<Projeto> builder)
       {
              builder.HasKey(p => p.Id);

              // Propriedades
              builder.Property(p => p.Id)
                     .IsRequired()
                     .ValueGeneratedNever();  // Chave autoincrementável

              // Relacionamento com Missao
              builder.HasOne(p => p.Missao)
                     .WithMany()
                     .HasForeignKey(p => p.MissaoId);
       }
}
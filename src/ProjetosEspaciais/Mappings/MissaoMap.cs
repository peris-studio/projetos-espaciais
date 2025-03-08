namespace ProjetosEspaciais.Mappings;

public class MissaoMap : IEntityTypeConfiguration<Missao>
{
       public void Configure(EntityTypeBuilder<Missao> builder)
       {
              builder.HasKey(m => m.Id);

              // propriedades
              builder.Property(m => m.Id)
                     .IsRequired()
                     .ValueGeneratedNever();  // chave autoincrementável

              // relacionamento-entidade
              builder.HasOne(id => id.Projeto)
                     .WithMany()
                     .HasForeignKey(id => id.ProjetoId);

              builder.HasOne(id => id.Veiculo)
                     .WithMany()
                     .HasForeignKey(id => id.VeiculoId);

              builder.HasOne(id => id.Plataforma)
                     .WithMany()
                     .HasOne(id => id.PlataformaId);

              builder.HasOne(id => id.Teste)
                     .WithMany()
                     .HasOne(id => id.TesteId);

              builder.HasOne(id => id.Documento)
                     .WithMany()
                     .HasOne(id => id.DocumentoId);

              builder.HasOne(id => id.Teste)
                     .WithMany()
                     .HasOne(id => id.TesteId);

              builder.HasOne(id => id.Licenca)
                     .WithMany()
                     .HasOne(id => id.LicencaId);

              builder.HasOne(id => id.Equipe)
                     .WithMany()
                     .HasOne(id => id.EquipeId);
       }
}
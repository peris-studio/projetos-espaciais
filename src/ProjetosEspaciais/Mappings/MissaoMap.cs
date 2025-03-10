namespace ProjetosEspaciais.Mappings;

public class MissaoMap : IEntityTypeConfiguration<Missao>
{
       public void Configure(EntityTypeBuilder<Missao> builder)
       {
              builder.HasKey(m => m.Id);

              // Propriedades
              builder.Property(m => m.Id)
                     .IsRequired()
                     .ValueGeneratedNever();  // Chave autoincrementável (não gerada automaticamente)


              // Relacionamentos com outras entidades
              builder.HasOne(m => m.Veiculo)
                     .WithMany()  // Um veículo pode estar associado a várias missões
                     .HasForeignKey(m => m.VeiculoId)
                     .IsRequired();

              builder.HasOne(m => m.Plataforma)
                     .WithMany()  // Uma plataforma pode estar associada a várias missões
                     .HasForeignKey(m => m.PlataformaId)
                     .IsRequired();

              builder.HasOne(m => m.Equipe)
                     .WithMany()  // Uma equipe pode estar associada a várias missões
                     .HasForeignKey(m => m.EquipeId)
                     .IsRequired();

              builder.Ignore(m => m.MissaoLicencas);

              // // Relacionamento com MissaoLicencas (muitos para muitos)
              // builder.HasMany(m => m.MissaoLicencas)
              //        .WithOne()  // A tabela de junção vai se referir tanto a Missao quanto a Licenca
              //        .HasForeignKey(ml => ml.MissaoId)  // Definindo a chave estrangeira para Missao
              //        .OnDelete(DeleteBehavior.Cascade);  // Apaga as entradas na tabela de junção ao deletar Missao
       }
}
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

              builder.Property(m => m.Codinome)
                     .IsRequired();

              builder.Property(m => m.Descricao)
                     .IsRequired();

              builder.Property(m => m.Objetivo)
                     .IsRequired();

              builder.Property(m => m.DuracaoEstimada)
                     .IsRequired();

              builder.Property(m => m.StatusMissao)
                     .IsRequired();

              builder.Property(m => m.TipoMissao)
                     .IsRequired();

              builder.Property(m => m.DataCriacao)
                     .IsRequired();

              builder.Property(m => m.Ativo)
                     .IsRequired();

              // Relacionamentos com outras entidades
              builder.HasOne(m => m.Veiculo)  // Relacionamento com Veiculo
                     .WithMany()  // Supondo que Veiculo tenha uma lista de Missao
                     .HasForeignKey(m => m.VeiculoId)
                     .OnDelete(DeleteBehavior.Restrict);  // Define o comportamento de exclusão

              builder.HasOne(m => m.Plataforma)  // Relacionamento com Plataforma
                     .WithMany()  // Supondo que Plataforma tenha uma lista de Missao
                     .HasForeignKey(m => m.PlataformaId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(m => m.Equipe)  // Relacionamento com Equipe
                     .WithMany()  // Supondo que Equipe tenha uma lista de Missao
                     .HasForeignKey(m => m.EquipeId)
                     .OnDelete(DeleteBehavior.Restrict);

              // Relacionamentos com listas de entidades
              builder.HasMany(m => m.Testes)  // Relacionamento com Testes
                     .WithMany()  // Supondo que Teste tenha uma lista de Missao
                     .UsingEntity<Dictionary<string, object>>(
                         "MissaoTeste",  // Nome da tabela de junção
                         j => j.HasOne<Teste>().WithMany().HasForeignKey("TesteId"),
                         j => j.HasOne<Missao>().WithMany().HasForeignKey("MissaoId")
                     );

              builder.HasMany(m => m.Documentos)  // Relacionamento com Documentos
                     .WithMany()  // Supondo que Documento tenha uma lista de Missao
                     .UsingEntity<Dictionary<string, object>>(
                         "MissaoDocumento",  // Nome da tabela de junção
                         j => j.HasOne<Documento>().WithMany().HasForeignKey("DocumentoId"),
                         j => j.HasOne<Missao>().WithMany().HasForeignKey("MissaoId")
                     );

              builder.HasMany(m => m.Licencas)  // Relacionamento com Licencas
                     .WithMany()  // Supondo que Licenca tenha uma lista de Missao
                     .UsingEntity<Dictionary<string, object>>(
                         "MissaoLicenca",  // Nome da tabela de junção
                         j => j.HasOne<Licenca>().WithMany().HasForeignKey("LicencaId"),
                         j => j.HasOne<Missao>().WithMany().HasForeignKey("MissaoId")
                     );

              // Configuração para o filtro de registros ativos
              builder.HasQueryFilter(m => m.Ativo);
       }
}
namespace ProjetosEspaciais.Mappings;

public class LicencaMap : IEntityTypeConfiguration<Licenca>
{
    public void Configure(EntityTypeBuilder<Licenca> builder)
    {
        builder.HasKey(l => l.Id);

        // propriedades
        builder.Property(l => l.Id)
               .IsRequired()
               .ValueGeneratedNever();  // chave autoincrementável

        builder.Ignore(l => l.MissaoLicencas);

        // builder.HasMany(l => l.MissaoLicencas)
        //        .WithOne()  // A tabela de junção vai se referir tanto a Licenca quanto a Missao
        //        .HasForeignKey(ml => ml.LicencaId)  // Chave estrangeira para Licenca
        //        .OnDelete(DeleteBehavior.Cascade);  // Apaga as entradas na tabela de junção ao deletar Licenca
    }
}
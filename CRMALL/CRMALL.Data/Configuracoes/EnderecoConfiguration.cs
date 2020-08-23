using CRMALL.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMALL.Data.Configuracoes
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(x => x.Cep)
               .IsRequired()
               .HasMaxLength(8);

            builder.Property(x => x.Logradouro)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.Bairro)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.Estado)
               .IsRequired()
               .HasMaxLength(2);

            builder.Property(x => x.Cidade)
               .IsRequired()
               .HasMaxLength(50);

            builder.HasOne(x => x.Cliente);


            builder.ToTable(nameof(Endereco));
        }
    }
}

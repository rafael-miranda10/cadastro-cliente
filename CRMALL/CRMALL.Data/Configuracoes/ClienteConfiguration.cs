using CRMALL.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMALL.Data.Configuracoes
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Sexo)
                .IsRequired();

            builder.Property(x => x.DataDeNascimento)
                .IsRequired();

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(nameof(Cliente));
        }
    }
}

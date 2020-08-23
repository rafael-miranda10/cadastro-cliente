using CRMALL.Data.Configuracoes;
using CRMALL.Domain.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CRMALL.Data.Contexto
{
    public class CrmallContext : DbContext
    {
        public CrmallContext(DbContextOptions<CrmallContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        }
    }
}

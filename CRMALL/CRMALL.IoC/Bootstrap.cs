using CRMALL.Data.Repositorios;
using CRMALL.Domain.Interfaces.Repositorios;
using CRMALL.Domain.Interfaces.Servicos;
using CRMALL.Domain.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace CRMALL.IoC
{
    public class Bootstrap
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            svcCollection.AddScoped<IClienteService, ClienteService>();
            svcCollection.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            svcCollection.AddScoped<IEnderecoReposirotio, EnderecoRepositorio>();
            svcCollection.AddScoped<IConsultaCepService, ConsultaCepService>();
        }
    }
}

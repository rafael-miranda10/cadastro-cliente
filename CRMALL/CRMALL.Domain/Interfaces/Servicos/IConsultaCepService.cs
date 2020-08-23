using CRMALL.Domain.Dto;

namespace CRMALL.Domain.Interfaces.Servicos
{
    public interface IConsultaCepService
    {
        ViaCepDto Consultar(string cep);
    }
}

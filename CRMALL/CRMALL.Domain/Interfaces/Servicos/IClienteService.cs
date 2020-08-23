using CRMALL.Domain.Dto;
using CRMALL.Domain.Entidades;

namespace CRMALL.Domain.Interfaces.Servicos
{
    public interface IClienteService
    {
        Cliente Adicionar(ClienteDto dto);
        Cliente Alterar(ClienteDto dto);
        void Remover(int id);
    }
}

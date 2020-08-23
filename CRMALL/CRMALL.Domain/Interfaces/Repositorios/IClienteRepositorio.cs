using CRMALL.Domain.Entidades;
using System.Collections.Generic;

namespace CRMALL.Domain.Interfaces.Repositorios
{
    public interface IClienteRepositorio
    {
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
        IEnumerable<Cliente> ObterTodosClientes();
        Cliente ObterPorId(int id);

    }
}

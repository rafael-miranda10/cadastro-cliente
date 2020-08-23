using CRMALL.Data.Contexto;
using CRMALL.Domain.Entidades;
using CRMALL.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRMALL.Data.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly CrmallContext _crmallContext;

        public ClienteRepositorio(CrmallContext crmallContext)
        {
            _crmallContext = crmallContext;
        }

        public void Adicionar(Cliente cliente)
        {
            _crmallContext.Cliente.Add(cliente);
            _crmallContext.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
            _crmallContext.Cliente.Update(cliente);
            _crmallContext.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            return _crmallContext.Cliente
                .AsNoTracking()
                .Include(x => x.Endereco)
                .Where(x => x.Id == id)
                .FirstOrDefault();

        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            return _crmallContext.Cliente
                 .Include(x => x.Endereco)
                 .AsEnumerable();
        }

        public void Remover(Cliente cliente)
        {
            _crmallContext.Cliente.Remove(cliente);
            _crmallContext.SaveChanges();
        }
    }
}

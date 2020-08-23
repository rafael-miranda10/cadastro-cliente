using CRMALL.Data.Contexto;
using CRMALL.Domain.Entidades;
using CRMALL.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRMALL.Data.Repositorios
{
    public class EnderecoRepositorio : IEnderecoReposirotio
    {
        private readonly CrmallContext _crmallContext;

        public EnderecoRepositorio(CrmallContext crmallContext)
        {
            _crmallContext = crmallContext;
        }
        public void Adicionar(Endereco endereco)
        {
            _crmallContext.Endereco.Add(endereco);
            _crmallContext.SaveChanges();
        }

        public void Atualizar(Endereco endereco)
        {
            _crmallContext.Endereco.Update(endereco);
            _crmallContext.SaveChanges();
        }

        public Endereco ObterPorId(int id)
        {
            return _crmallContext.Endereco
                .AsNoTracking()
                .Include(x => x.Cliente)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Endereco> ObterTodosEnderecos()
        {
            return _crmallContext.Endereco
                 .Include(x => x.Cliente)
                 .AsEnumerable();
        }

        public void Remover(Endereco endereco)
        {
            _crmallContext.Endereco.Remove(endereco);
            _crmallContext.SaveChanges();
        }
    }
}

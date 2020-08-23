using CRMALL.Domain.Entidades;
using System.Collections.Generic;

namespace CRMALL.Domain.Interfaces.Repositorios

{
    public interface IEnderecoReposirotio
    {
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        void Remover(Endereco endereco);
        IEnumerable<Endereco> ObterTodosEnderecos();
        Endereco ObterPorId(int id);
    }
}

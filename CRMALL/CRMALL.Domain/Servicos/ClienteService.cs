using CRMALL.Domain.Dto;
using CRMALL.Domain.Entidades;
using CRMALL.Domain.Interfaces.Repositorios;
using CRMALL.Domain.Interfaces.Servicos;

namespace CRMALL.Domain.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IEnderecoReposirotio _enderecoReposirotio;

        public ClienteService(IClienteRepositorio clienteRepositorio, IEnderecoReposirotio enderecoReposirotio)
        {
            _clienteRepositorio = clienteRepositorio;
            _enderecoReposirotio = enderecoReposirotio;
        }
        public Cliente Adicionar(ClienteDto dto)
        {
            var endereco = NovoEndereco(dto.Endereco);
            var cliente = new Cliente(dto.Nome, (Sexo)dto.Sexo, dto.DataDeNascimento, endereco);
            cliente.Validar();
            if (cliente.Valid)
            {
                _clienteRepositorio.Adicionar(cliente);
            }
            return cliente;
        }

        private Endereco NovoEndereco(EnderecoDto dto)
        {
            return new Endereco(
               dto.Cep,
               dto.Logradouro,
               dto.Numero,
               dto.Complemento,
               dto.Bairro,
               dto.Estado,
               dto.Cidade);
        }

        public Cliente Alterar(ClienteDto dto)
        {
            var cliente = _clienteRepositorio.ObterPorId(dto.Id);
            cliente.AlterarNome(dto.Nome);
            cliente.AlterarSexo((Sexo) dto.Sexo);
            cliente.AlterarDataNascimento(dto.DataDeNascimento);
            AlterarEnderecoDoCliente(cliente, dto.Endereco);
            cliente.Validar();

            if (cliente.Valid)
            {
                _clienteRepositorio.Atualizar(cliente);
            }
            return cliente;
        }

        private void AlterarEnderecoDoCliente(Cliente cliente, EnderecoDto dto)
        {
            cliente.Endereco.AlterarBairro(dto.Bairro);
            cliente.Endereco.AlterarCep(dto.Cep);
            cliente.Endereco.AlterarCidade(dto.Cidade);
            cliente.Endereco.AlterarComplemento(dto.Complemento);
            cliente.Endereco.AlterarEstado(dto.Estado);
            cliente.Endereco.AlterarLogradouro(dto.Logradouro);
            cliente.Endereco.AlterarNumero(dto.Numero);
        }

        public void Remover(int id)
        {
            var cliente = _clienteRepositorio.ObterPorId(id);
            if(cliente != null)
            {
                _enderecoReposirotio.Remover(cliente.Endereco);
                _clienteRepositorio.Remover(cliente);
            }
        }
    }
}

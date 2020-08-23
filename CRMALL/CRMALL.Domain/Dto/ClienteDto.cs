using CRMALL.Domain.Entidades;
using System;

namespace CRMALL.Domain.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public EnderecoDto Endereco { get; set; }

        public static ClienteDto ConverterParaDto(Cliente cliente)
        {
            if (cliente != null)
            {
                return new ClienteDto()
                {
                    Id = cliente.Id,
                    DataDeNascimento = cliente.DataDeNascimento,
                    Nome = cliente.Nome,
                    Sexo = (int)cliente.Sexo,
                    Endereco = EnderecoDto.ConverterParaDto(cliente.Endereco)
                };
            }
            return null;
        }
    }
}

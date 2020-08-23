using CRMALL.Domain.Entidades;

namespace CRMALL.Domain.Dto
{
    public class EnderecoDto
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int ClienteId { get; set; }

        public static EnderecoDto ConverterParaDto(Endereco endereco)
        {
            if (endereco != null)
            {
                return new EnderecoDto()
                {
                    Id = endereco.Id,
                    Cep = endereco.Cep,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Complemento = endereco.Complemento,
                    Estado = endereco.Estado,
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero,
                    ClienteId = endereco.ClienteId
                };
            }
            return null;
        }
    }
}

using CRMALL.Domain.Base;
using Flunt.Validations;

namespace CRMALL.Domain.Entidades
{
    public class Endereco : Entity
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public int ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        protected Endereco() { }

        public Endereco(
            string cep,
            string logradouro,
            int numero,
            string complemento,
            string bairro,
            string estado,
            string cidade
            )
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Estado = estado;
            Cidade = cidade;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMaxLen(Cep, 8, "Cep", "O Cep deve conter 8 caracteres")
               .HasMaxLen(Logradouro, 50, "Logradouro", "O logradouro deve conter no máximo 50 caracteres")
               .IsGreaterThan(Numero, 0, "Numero", "O número deve ser maior que zero")
               .HasMaxLen(Estado, 2, "Estado", "O estado deve conter no máximo 2 caracteres")
               .HasMaxLen(Complemento, 50, "Complemento", "O complemento deve conter no máximo 50 caracteres")
               .HasMaxLen(Bairro, 50, "Bairro", "O bairro deve conter no máximo 50 caracteres")
               .HasMaxLen(Cidade, 50, "Cidade", "O cidade deve conter no máximo 50 caracteres")
           );
        }

        public void AlterarCliente(Cliente cliente)
        {
            if (cliente == null) return;
            Cliente = cliente;
        }

        public void AlterarCep(string cep)
        {
            Cep = cep;
        }

        public void AlterarLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }

        public void AlterarNumero(int numero)
        {
            Numero = numero;
        }

        public void AlterarComplemento(string complemento)
        {
            Complemento = complemento;
        }

        public void AlterarBairro(string bairro)
        {
            Bairro = bairro;
        }

        public void AlterarEstado(string estado)
        {
            Estado = estado;
        }

        public void AlterarCidade(string cidade)
        {
            Cidade = cidade;
        }

        public void AlterarClienteId(int clienteId)
        {
            ClienteId = clienteId;
        }
    }
}

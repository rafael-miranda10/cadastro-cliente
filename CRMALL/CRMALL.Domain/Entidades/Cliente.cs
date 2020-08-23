using CRMALL.Domain.Base;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CRMALL.Domain.Entidades
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public Sexo Sexo { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Endereco Endereco { get; private set; }

        protected Cliente() { }

        public Cliente(string nome, Sexo sexo, DateTime dataDeNascimento, Endereco endereco)
        {
            Nome = nome;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
            Endereco = endereco;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMaxLen(Nome, 50, "Nome", "O nome deve conter no máximo 50 caracteres")
               .IsNotNull(Endereco, "Endereco", "O cliente deve possuir um endereço")
               .IsNotNull(DataDeNascimento, "DataDeNascimento", "O cliente deve possuir uma data de nascimento")
               );

            if ((int)Sexo > 1)
            {
                AddNotification(new Notification("Sexo", "informe masculino ou feminino para o sexo"));
            }
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarSexo(Sexo sexo)
        {
            Sexo = sexo;
        }

        public void AlterarDataNascimento(DateTime dataNascimento)
        {
            DataDeNascimento = dataNascimento;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            if (endereco == null) return;
            Endereco = endereco;
        }
    }
}

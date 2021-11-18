namespace AmericanosDoValeEmbelezado
{
    public class Cliente : Usuario
    {
        public Cliente(string nome, string telefone, string endereco, string email, string tipo_conta, string cpf_cnpj):base(nome, telefone, endereco, email, tipo_pessoa, cpf_cnpj)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
            this.tipo_conta = tipo_conta;
            this.cpf_cnpj = cpf_cnpj;
        }
        private double saldo = 0.00;

    }
}
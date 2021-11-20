namespace AmericanosDoValeEmbelezado
{
    public class Cliente : Usuario
    {
        public Cliente(string nome, string telefone, string endereco, string email, string tipo_conta, string cpf_cnpj, string senha):base(nome, telefone, endereco, email, tipo_conta, cpf_cnpj, senha)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
            this.tipo_conta = tipo_conta;
            this.cpf_cnpj = cpf_cnpj;
            this.senha = senha;
        }
        private double saldo = 0.00;

    }
}
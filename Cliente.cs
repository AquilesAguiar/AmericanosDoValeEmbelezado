namespace AmericanosDoValeEmbelezado
{
    public class Cliente : Usuario
    {
        public Cliente(string nome, string telefone, string endereco, string email, string tipo_pessoa, string cpf_cnpj):base(nome, telefone, endereco, email, tipo_pessoa, cpf_cnpj)
        {

        }
        private double saldo;

    }
}
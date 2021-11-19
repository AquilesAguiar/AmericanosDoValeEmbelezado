namespace AmericanosDoValeEmbelezado
{
    public abstract class Usuario 
    {
        protected string nome;
        protected string telefone;
        protected string endereco;
        protected string email;
        protected string tipo_conta;
        protected string cpf_cnpj;
        // CPF = 11
        // CNPJ = 14
        
        public Usuario(string nome, string telefone, string endereco, string email, string tipo_conta, string cpf_cnpj){
            
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
            this.tipo_conta = tipo_conta;
            this.cpf_cnpj = cpf_cnpj;

        }


    
        
    }
}
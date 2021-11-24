namespace AmericanosDoValeEmbelezado
{
    public abstract class Usuario 
    {   

        public string nome{get;protected set;}
        // protected string nome;

        public string telefone{get;protected set;}
        // protected string telefone;
        public string endereco{get; protected set;}
        // protected string enderec{get; protected set;};
        
        public string email{get;protected set;}
        //protected string email;

        public string tipo_conta{get;protected set;}
       //protected string tipo_conta;
        public string cpf_cnpj{get; protected set;}
        // CPF = 11
        // CNPJ = 14
        public string senha{get; protected set;}

        public string cod{get; protected set;}
        
        public Usuario(string nome, string telefone, string endereco, string email, string tipo_conta, string cpf_cnpj, string senha, string cod){
            
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
            this.tipo_conta = tipo_conta;
            this.cpf_cnpj = cpf_cnpj;
            this.senha = senha;
            this.cod = cod;
        }


    
        
    }
}
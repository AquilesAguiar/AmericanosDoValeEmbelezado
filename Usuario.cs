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

            //Faz uma verificação do tipo da pessoa    
            if(tipo_pessoa == "f" || tipo_pessoa == "F"){

                this.tipo_pessoa = "Fisica";

            }else if(tipo_pessoa == "j" || tipo_pessoa == "J"){

                this.tipo_pessoa = "Juridica";

            }

            //Verifica se a pessoa é fisica e se o cpf possui 11 caracteres
            if(this.tipo_pessoa == "Fisica" && cpf_cnpj.Length == 11){

                this.cpf_cnpj = cpf_cnpj; 

            }else if(this.tipo_pessoa == "Juridica" && cpf_cnpj.Length == 14){

                this.cpf_cnpj = cpf_cnpj;

            }

        }


    
        
    }
}
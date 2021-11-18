namespace AmericanosDoValeEmbelezado
{
    public class Cadastro
    {   
        
        //Método de inicialização dos atriutos de um usuario
        public bool initUsu(string nome, string telefone, string endereco, string email){

            if(nome != "" || telefone != "" || endereco != ""){
                return true;
            }
            return false;
            
        }

    }
}
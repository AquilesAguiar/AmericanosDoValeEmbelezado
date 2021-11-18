using System.Collections.Generic;

namespace AmericanosDoValeEmbelezado
{
    public class CadastroCliente
    {   
        private List<Usuario> cadastrados = new List<Usuario>();
        //Método de inicialização dos atriutos de um usuario
        public bool initUsu(string nome, string telefone, string endereco, string email, string tipo_conta, int cpf_cnpj){

            if(nome != "" && telefone != "" && endereco != "" && tipo_conta != "" && validaCpf_Cnpj(cpf_cnpj)){
                if((tipo_conta == "c" || tipo_conta == "C") && tipoCpf_Cnpj(cpf_cnpj) == "F"){
                    Cliente user = new Cliente(nome, telefone, endereco, email, tipo_conta, cpf_cnpj);
                    cadastrados.Add(user);
                }
                else if(tipoCpf_Cnpj(cpf_cnpj) == "J") {
                    Prestador user = new Prestador(nome, telefone, endereco, email, tipo_conta, cpf_cnpj);
                    cadastrados.Add(user);
                }
                else {
                    return false;
                }
                return true;
            }
            return false;
            
        }

        private bool validaCpf_Cnpj(int cpf_cnpj) {
            if(cpf_cnpj.ToString().Length == 11 || cpf_cnpj.ToString().Length == 14){
                return true;
            }
            return false;
        }

        private char tipoCpf_Cnpj(int cpf_cnpj) {
            if(cpf_cnpj.ToString().Length == 11) {
                return "F";
            }
            return "J";
        }

    }
}
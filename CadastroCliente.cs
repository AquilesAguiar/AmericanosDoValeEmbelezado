using System;
using System.Collections.Generic;

namespace AmericanosDoValeEmbelezado
{
    public class CadastroCliente
    {   
        private List<Usuario> cadastrados = new List<Usuario>();

        public void recolheCadastro(){
            try{
                bool sentinela = false;
                while(!sentinela) {
                    Console.WriteLine("Olá Bem-vindo(a), ao cadastro de usuario!");
                    Console.Write("Digite o seu nome de usuario (Obrigatório) >> ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite o seu telefone (Obrigatório) >> ");
                    string telefone = Console.ReadLine();

                    Console.Write("Digite o seu endereço (Obrigatório) >> ");
                    string endereco = Console.ReadLine();

                    Console.Write("Digite o seu email (Opcional) >> ");
                    string email = Console.ReadLine();

                    Console.Write("Digite o tipo conta(C para cliente e P para prestador) (Obrigatório) >> ");
                    string tipo_conta = Console.ReadLine().ToUpper();
                    if(tipo_conta != "C" && tipo_conta != "P"){
                        throw new Exception("O valor do tipo da conta só pode ser C ou P !");
                    }

                    Console.Write("Digite o seu CPF ou CNPJ (Obrigatório) >> ");
                    int cpf_cnpj = int.Parse(Console.ReadLine());
                    if(!validaCpf_Cnpj(cpf_cnpj)) {
                        throw new Exception("O CPF deve conter 11 digitos e o CNPJ deve conter 14 digitos!");
                    }
                    if(tipo_conta == "P" && tipoCpf_Cnpj(cpf_cnpj) == "F"){
                        throw new Exception("Prestadores só podem ser cadastrados com um CNPJ!");
                    }

                    if(verificaDados(nome, telefone, endereco)) {
                        if(!initUsu(nome, telefone, endereco, email, tipo_conta, cpf_cnpj)){
                            Console.WriteLine("Usuario criado com sucesso!");
                        }
                        sentinela = true;
                    }
                }

                
            
            }

            catch (FormatException) {
                Console.WriteLine("Você digitou algum valor inválido!");
                recolheCadastro();
            }
        }
        //Método de inicialização dos atriutos de um usuario
        public bool initUsu(string nome, string telefone, string endereco, string email, string tipo_conta, int cpf_cnpj){

            if(tipo_conta == "C"){
                Cliente user = new Cliente(nome, telefone, endereco, email, tipo_conta, Convert.ToString(cpf_cnpj));
                cadastrados.Add(user);
            }
            else if(tipo_conta == "P") {
                Prestador user = new Prestador(nome, telefone, endereco, email, tipo_conta, Convert.ToString(cpf_cnpj));
                cadastrados.Add(user);
            }
            return true;
        }

        private bool verificaDados(string nome, string telefone, string endereco){
            if(nome != "" && telefone != "" && endereco != "") {
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

        private string tipoCpf_Cnpj(int cpf_cnpj) {
            if(cpf_cnpj.ToString().Length == 11) {
                return "F";
            }
            return "J";
        }

    }
}
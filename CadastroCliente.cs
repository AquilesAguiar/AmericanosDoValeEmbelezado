using System;
using System.Collections.Generic;
using System.IO;

//Terminar o logar
//criar tela prestador
//criar o marketplace cliente
//agenda

namespace AmericanosDoValeEmbelezado
{
    public class CadastroCliente
    {   
        public List<Usuario> cadastrados = new List<Usuario>();

        public void recolheCadastro(){

            Console.Clear();
            Console.WriteLine("Olá Bem-vindo(a), ao cadastro de usuario!");
            bool sentinela = false;
            while(!sentinela) {
                try{
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
                        throw new ArgumentException("O valor do tipo da conta só pode ser C ou P !", "ecess");
                    }

                    Console.Write("Digite o seu CPF ou CNPJ (Obrigatório) >> ");
                    long cpf_cnpj = long.Parse(Console.ReadLine());
                    if(!validaCpf_Cnpj(cpf_cnpj)) {
                        throw new ArgumentOutOfRangeException("O CPF deve conter 11 digitos e o CNPJ deve conter 14 digitos!");
                    }
                    if(tipo_conta == "P" && tipoCpf_Cnpj(cpf_cnpj) == "F"){
                        throw new ArgumentException("Prestadores só podem ser cadastrados com um CNPJ!");
                    }
                    Console.Write("Digite uma senha para a sua conta (Obrigatório) >> ");
                    string senha = Console.ReadLine();

                    if(verificaDados(nome, telefone, endereco, senha)) {
                        if(initUsu(nome, telefone, endereco, email, tipo_conta, cpf_cnpj, senha)){
                            Console.WriteLine("Usuario criado com sucesso!");
                        }
                        sentinela = true;
                    }
                    
                }

                catch(ArgumentOutOfRangeException){
                    Console.Clear();
                    Console.WriteLine("Valores com tamanho não aceitavel!");
                }

                catch (ArgumentException) {
                    Console.Clear();
                    Console.WriteLine("Você digitou algum valor inválido!");

                }
            }
        }

        public Usuario logar(string nomeUsu, string senhaUsu) {
            if(verificaLogin(nomeUsu, senhaUsu) == -1) {
                //
            }
        }

        private int verificaLogin(string nomeUsu, string senhaUsu) {
            int encontrado = -1;
            for(int i = 0; i < cadastrados.Count; i++)
            {
                if(cadastrados[i].nome == nomeUsu && cadastrados[i].senha == senhaUsu) {
                    encontrado = i;
                }
            }
            return encontrado;
        }

        //Método de inicialização dos atriutos de um usuario
        public bool initUsu(string nome, string telefone, string endereco, string email, string tipo_conta, long cpf_cnpj, string senha){

            try
                {
                    using (StreamWriter sw = File.AppendText("C:\\Users\\bielp\\Documents\\GitHub\\AmericanosDoValeEmbelezado\\pessoas.txt"))
                    {
                        sw.WriteLine($"{nome},{telefone},{endereco},{email},{tipo_conta},{cpf_cnpj},{senha}", true);
                    }
            
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

            return true;
        }

        private bool verificaDados(string nome, string telefone, string endereco, string senha){
            if(nome != "" && telefone != "" && endereco != "" && senha != "") {
                return true;
            }
            return false;
        }

        private bool validaCpf_Cnpj(long cpf_cnpj) {
            if(cpf_cnpj.ToString().Length == 11 || cpf_cnpj.ToString().Length == 14){
                return true;
            }
            return false;
        }

        private string tipoCpf_Cnpj(long cpf_cnpj) {
            if(cpf_cnpj.ToString().Length == 11) {
                return "F";
            }
            return "J";
        }


        // public int Logar(){
            

        //     return sent;
        // }

        public void leitor() {
            StreamReader sr = new StreamReader("C:\\Users\\bielp\\Documents\\GitHub\\AmericanosDoValeEmbelezado\\pessoas.txt");

            string linha = sr.ReadLine();

            /*while(linha != null) {
                Console.WriteLine(linha);
                linha = sr.ReadLine();
            }*/
            
            String[] temp;
            while(linha != null) {
                temp = linha.Split(",");
                if(temp[4] == "C"){
                    Cliente user = new Cliente(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
                    cadastrados.Add(user);
                }
                else if(temp[4] == "P") {
                    Prestador user = new Prestador(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
                    cadastrados.Add(user);
                }

                linha = sr.ReadLine();
            }
        }
    }
}
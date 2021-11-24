using System;
using System.Collections.Generic;
using System.IO;

//Terminar o logar - Iniciado
//criar o marketplace cliente
//criar tela prestador
//agenda

namespace AmericanosDoValeEmbelezado
{
    public class CadastroCliente
    {   
        private Cliente clienteLogado = null;
        public Cliente ClienteLogado {
            get {
                return this.clienteLogado;
            }
            private set {
                this.clienteLogado = value;
            }
        }
        public Prestador prestadorLogado = null;
        public Prestador PrestadorLogado {
            get {
                return this.prestadorLogado;
            }
            private set {
                this.prestadorLogado = value;
            }
        }
        public List<Cliente> clientes = new List<Cliente>();
        public List<Prestador> prestadores = new List<Prestador>();

        public void recolheCadastro(){

            Console.Clear();
            Console.WriteLine("Olá Bem-vindo(a), ao cadastro de usuario!");
            bool sentinela = false;
            string nome = null;
            string telefone = null;
            string endereco = null;
            string email = null;
            string tipo_conta = null;
            long cpf_cnpj = 0;
            string senha = null;

            while(!sentinela) {
                try{

                    if(nome == null || nome == "") {
                        Console.Write("Digite o seu nome de usuario (Obrigatório) >> ");
                        nome = Console.ReadLine();
                        if(nome == null || nome == "") {
                            throw new Exception("O campo nome é obrigatório!");
                        }
                    }

                    if(telefone == null || telefone == "") {
                        Console.Write("Digite o seu telefone (Obrigatório) >> ");
                        telefone = Console.ReadLine();
                        if(telefone == null || telefone == "") {
                            throw new Exception("O campo telefone é obrigatório!");
                        }
                    }

                    if(endereco == null || endereco == "") {
                        Console.Write("Digite o seu endereço (Obrigatório) >> ");
                        endereco = Console.ReadLine();
                        if(endereco == null || endereco == "") {
                            throw new Exception("O campo endereco é obrigatório!");
                        }
                    }

                    if(email == null) {
                        Console.Write("Digite o seu email (Opcional) >> ");
                        email = Console.ReadLine();
                    }

                    if(tipo_conta == null || (tipo_conta != "C" && tipo_conta != "P")) {
                        Console.Write("Digite o tipo conta(C para cliente e P para prestador) (Obrigatório) >> ");
                        tipo_conta = Console.ReadLine().ToUpper();
                        if(tipo_conta != "C" && tipo_conta != "P"){
                            throw new Exception("O valor do tipo da conta só pode ser C ou P !");
                        }
                    }

                    if(cpf_cnpj == 0) {
                        Console.Write("Digite o seu CPF ou CNPJ (Obrigatório) >> ");
                        cpf_cnpj = long.Parse(Console.ReadLine());
                        if(!validaCpf_Cnpj(cpf_cnpj)) {
                            cpf_cnpj = 0;
                            throw new Exception("O CPF deve conter 11 digitos e o CNPJ deve conter 14 digitos!");
                        }
                        if(tipo_conta == "P" && tipoCpf_Cnpj(cpf_cnpj) == "F"){
                            cpf_cnpj = 0;
                            throw new Exception("Prestadores só podem ser cadastrados com um CNPJ!");
                        }
                    }

                    if(senha == "" || senha == null) {
                        Console.Write("Digite uma senha para a sua conta (Obrigatório) >> ");
                        senha = Console.ReadLine();
                        if(senha == "" || senha == null) {
                            throw new Exception("A senha é obrigatória!");
                        }
                    }

                    if(verificaDados(nome, telefone, endereco, senha)) {
                        if(initUsu(nome, telefone, endereco, email, tipo_conta, cpf_cnpj, senha)){
                            Console.WriteLine("Usuario criado com sucesso!");
                        }
                        sentinela = true;
                    }
                    
                }

                catch(Exception ex){
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //Método de inicialização dos atriutos de um usuario
        public bool initUsu(string nome, string telefone, string endereco, string email, string tipo_conta, long cpf_cnpj, string senha){

            try
                {
                    if(clientes.Count < 1 && prestadores.Count < 1) {
                        leitor();
                    }
                    using (StreamWriter sw = File.AppendText("pessoas.txt"))
                    {
                        sw.WriteLine($"{nome},{telefone},{endereco},{email},{tipo_conta},{cpf_cnpj},{senha},{clientes.Count + prestadores.Count}", true);
                        sw.Close();
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

        public void leitor() {
            StreamReader sr = new StreamReader("pessoas.txt");

            string linha = sr.ReadLine();
            
            String[] temp;
            while(linha != null) {
                temp = linha.Split(",");
                if(temp[4] == "C"){
                    Cliente user = new Cliente(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7]);
                    clientes.Add(user);
                }
                else if(temp[4] == "P") {
                    Prestador user = new Prestador(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7]);
                    prestadores.Add(user);
                }

                linha = sr.ReadLine();
            }
            sr.Close();
        }


        //--------------------------------------------------

        public bool logar(string nomeUsu, string senhaUsu) {
            List<String> user = verificaLogin(nomeUsu, senhaUsu);
            if(user.Count != 0) {
                if(user[0] == "C"){
                    clienteLogado = clientes[int.Parse(user[1])];
                }
                else {
                    prestadorLogado = prestadores[int.Parse(user[1])];
                }
                return true;
            }
            return false;
        }

        public List<String> verificaLogin(string nomeUsu, string senhaUsu) {
            List<String> encontrado = new List<string>(){};
            for(int i = 0; i < clientes.Count; i++)
            {
                if(clientes[i].nome == nomeUsu && clientes[i].senha == senhaUsu) {
                    encontrado.Add("C");
                    encontrado.Add(i.ToString());
                }
            }

            for(int i = 0; i < prestadores.Count; i++)
            {
                if(prestadores[i].nome == nomeUsu && prestadores[i].senha == senhaUsu) {
                    encontrado.Add("P");
                    encontrado.Add(i.ToString());
                }
            }
            return encontrado;
        }

        //---------------------------------------------------------
    }
}
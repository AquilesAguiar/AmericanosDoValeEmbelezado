using System;
using System.Collections.Generic;
using System.IO;

namespace AmericanosDoValeEmbelezado
{
    public class Prestador : Usuario, IVerificado
    {
        public Prestador(string nome, string telefone, string endereco, string email, string tipo_conta, string cpf_cnpj, string senha, string cod):base(nome, telefone, endereco, email, tipo_conta, cpf_cnpj, senha, cod)
        {

            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
            this.tipo_conta = tipo_conta;
            this.cpf_cnpj = cpf_cnpj;
            this.senha = senha;
            this.cod = cod;

        }
        
        private List<Servico> servicos = new List<Servico>();
        private List<Produto> produtos = new List<Produto>();
        public static Dictionary<DateTime, string> agenda = new Dictionary<DateTime, string>();
        Dictionary<DateTime, string>.ValueCollection pessoa = agenda.Values;

        
        public int qtd_pessoa{
            get{
                return qtd_pessoa;
            }
            set{
                int cont = 0;
                foreach(string x in pessoa){
                cont ++;
                }
                qtd_pessoa = cont;
            }
        }

        public int qtd_produtos{
            get{
                return qtd_produtos;
            }
            set{
                int cont = 0;
                foreach (Produto x  in produtos)
                {
                    cont++;
                }
                qtd_produtos = cont;
            }
        }

        public bool is_email{
            get{
                return is_email;
            }
            set{
                if(email == ""){
                    is_email = false;
                }
                is_email = true;
            }
        }
        
        public bool Cadastro(int tipo, string codigoPrestador){
            
            if(servicos.Count == 0 && produtos.Count == 0){
                carregaEstoque(codigoPrestador);
            }
            
            Edicao(tipo, codigoPrestador);
            return true;
        }

        public bool Remocao(){
            return true;
        }

        public bool Edicao(int tipo, string codigoPrestador){
            
            bool senti = false;
            while(!senti){
                Console.WriteLine("Digite o nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o preço: ");
                double preco = Double.Parse(Console.ReadLine());
                
                Console.WriteLine("Digite a descrição: ");
                string desc = Console.ReadLine();
            
                if(tipo == 1) {
                    Console.WriteLine("Digite a quantidade:");
                    int qtd = int.Parse(Console.ReadLine());
                    
                    Produto produto = new Produto(nome, preco, desc, qtd);
                    produtos.Add(produto);
                    escreveArquivo(codigoPrestador, nome, preco, desc, qtd.ToString());
                    senti = true;
                    Console.WriteLine("Produto Cadastrado!");
                    Console.ReadLine();
                }
                else {
                    Servico servico = new Servico(nome, desc, preco);
                    servicos.Add(servico);
                    escreveArquivo(codigoPrestador, nome, preco, desc);
                    senti = true;
                    Console.WriteLine("Serviço Cadastrado!");
                    Console.ReadLine();
                }
                
                
            }

            return true;
            
        }

        public bool isVerified(){
            if(qtd_pessoa > 10 && qtd_produtos > 5 && email != ""){
                return true;
            }
            return false;
        }
        public bool isTrend(){
            if((qtd_pessoa > 5 && qtd_pessoa < 10) && (qtd_produtos > 2 && qtd_produtos < 5)){
                return true;
            }
            return false;  
        }

        public bool isComum(){
            if(((qtd_pessoa > 0 && qtd_pessoa < 5) && (qtd_produtos > 0 && qtd_produtos < 2))){
                return true;
            }
            return false;
        }

        public void carregaEstoque(String codPrestador){
            StreamReader sr = new StreamReader("estoque.txt");
            string linha = sr.ReadLine();

            while(linha != null) {
                String[] temp = linha.Split("+");
                
                if(codPrestador == temp[0]){
                    if(temp[2] == "Produto"){
                        temp = temp[1].Split(",");
                        Produto produto = new Produto(temp[0], double.Parse(temp[1]), temp[2], int.Parse(temp[3]));
                        produtos.Add(produto);                    
                    }
                    else{
                        temp = temp[1].Split(",");
                        Servico servico = new Servico(temp[0], temp[2], Double.Parse(temp[1]));
                        servicos.Add(servico);
                    }
                }
                linha = sr.ReadLine();
            }
            sr.Close();
        }
        

        // Criar método de escrita no arquivo
        private void escreveArquivo(string codigo, string nome, double preco, string desc, string qtd = ""){
            try
                {
                    using (StreamWriter sw = File.AppendText("estoque.txt"))
                    {
                        if(qtd !=""){
                            sw.WriteLine($"{codigo}+{nome},{preco},{desc},{qtd}+Produto", true);
                            sw.Close();
                        }
                        else {
                            sw.WriteLine($"{codigo}+{nome},{preco},{desc}+Servico", true);
                            sw.Close();
                        }
                        
                    }
            
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
        }

    }
}
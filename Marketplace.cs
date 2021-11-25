using System;
using System.IO;

namespace AmericanosDoValeEmbelezado
{
    public class Marketplace
    {
        public void marketLoja(int opcao, Cliente clienteLogado){
            StreamReader sr = new StreamReader("estoque.txt");
            string linha = sr.ReadLine();
            Console.Clear();
            if(opcao == 1){

                while(linha != null) {
                    string[] temp = linha.Split("+");

                    if(temp[2] == "Produto"){
                        string[] divide = temp[1].Split(",");
                        Console.WriteLine($@"Informações do Produto
Nome: {divide[0]}
Preço: {divide[1]}
Descrição: {divide[2]}
Quantidade: {divide[3]}
=========================");

                    }
                
                    linha = sr.ReadLine();
                }
                Console.Write(@"Digite o nome do produto que deseja comprar (caso não for comprar digite 0)?
>> ");
                string compra = Console.ReadLine();

                if(compra != "0") {
                    double result = retornaPreco(compra);
                    if(result == 0){
                        Console.WriteLine("Você digitou o nome de um produto inválido!");
                    }
                    else {
                        if(result <= clienteLogado.Saldo){
                            Console.WriteLine("Compra finalizada com sucesso!");
                        }
                        else {
                            Console.WriteLine(@"Compra cancelada!
Motivo: Saldo insulficiente!");
                        }
                    }
                }
            }else{
                while(linha != null) {
                    string[] temp = linha.Split("+");

                    if(temp[2] == "Servico"){
                        string[] divide = temp[1].Split(",");
                        Console.WriteLine($@"Informações do Serviço
Nome: {divide[0]}
Preço: {divide[1]}
Descrição: {divide[2]}
=========================");
                    }
                    linha = sr.ReadLine();
                }
            }
            
        }

        public string adcionaPessoa(Cliente clienteLogado, string nome_servico, string data){
            StreamReader sr = new StreamReader("estoque.txt");
            string linha = sr.ReadLine();
            int cont = 0;
            while(linha != null){
                string temp = linha.Split("+")[1].Split(",")[0];
                if(temp == nome_servico){
                    try
                    {
                        using (StreamWriter sw = File.AppendText("agenda.txt"))
                        {
                        sw.WriteLine($"{clienteLogado.nome},{nome_servico},{data}", true);
                        }
            
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    cont ++;
                }
                linha = sr.ReadLine();
            }
            if(cont == 0){
               return "Erro no Agendamento"; 
            }else{
                return "Agendado!";
            }
            
        }

        private double retornaPreco(string prodName){
            double retorno = 0;
            //try
                //{
                    using (StreamReader sr = new StreamReader("estoque.txt"))
                    {
                        string linhaAtual = sr.ReadLine();
                        while(linhaAtual != null){
                            String[] estoqueAtual = linhaAtual.Split("+");
                            estoqueAtual = estoqueAtual[1].Split(",");
                            if(prodName == estoqueAtual[0]){
                                retorno = double.Parse(estoqueAtual[1]);
                            }
                            linhaAtual = sr.ReadLine();
                        }
                    }
            
                //}
                /*catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }*/
            return retorno;
        }

    }
}
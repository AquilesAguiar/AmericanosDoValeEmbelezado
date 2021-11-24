using System;
using System.IO;

namespace AmericanosDoValeEmbelezado
{
    public class Marketplace
    {
        public void marketLoja(int opcao){
            StreamReader sr = new StreamReader("estoque.txt");
            string linha = sr.ReadLine();
            
            if(opcao == 1){

                while(linha != null) {
                    string[] temp = linha.Split("+");

                    if(temp[2] == "Produto"){
                        string[] divide = temp[1].Split(",");
                        Console.WriteLine($@"Informações da conta
Nome: {divide[0]}
Preço: {divide[1]}
Descrição: {divide[2]}
Quantidade: {divide[3]}
=========================");

                    }
                
                    linha = sr.ReadLine();
                }
            }else{

                while(linha != null) {
                    string[] temp = linha.Split("+");

                    if(temp[2] == "Servico"){
                        string[] divide = temp[1].Split(",");
                        Console.WriteLine($@"Informações da conta
Nome: {divide[0]}
Preço: {divide[1]}
Descrição: {divide[2]}
Quantidade: {divide[3]}
=========================");
                    }
                    linha = sr.ReadLine();
                }
            }
            
        }

        

    }
}
using System;

namespace AmericanosDoValeEmbelezado
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastroCliente CadastroUsuarios = new CadastroCliente();

            bool sentinela = false;
            while(!sentinela) {
                Console.Write(@"Digite:
1 - para Logar
2 - para Cadastrar
3 - para sair 
>> ");
                                        
                int sent = int.Parse(Console.ReadLine());

                switch(sent) {
                    case 1:
                        CadastroUsuarios.leitor();
                        Console.Write("Digite o nome do usuario >> ");
                        string n = Console.ReadLine();

                        Console.Write("Digite o nome do usuario >> ");
                        string pass = Console.ReadLine();

                        break;
                    case 2:
                        CadastroUsuarios.recolheCadastro();
                        break;
                    case 3:
                        sentinela = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Opção inválida, tente novamente!");
                        Console.WriteLine("-------------------------");
                        break;
                }
            }
        }
    }

}

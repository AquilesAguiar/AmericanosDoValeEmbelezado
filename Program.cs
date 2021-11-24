using System;

namespace AmericanosDoValeEmbelezado
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastroCliente CadastroUsuarios = new CadastroCliente();
            Home home = new Home();

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
                        bool sentinelaCase1 = false;
                        while(!sentinelaCase1) {
                            CadastroUsuarios.leitor();
                            Console.Write("Digite o nome do usuario >> ");
                            string n = Console.ReadLine();

                            Console.Write("Digite a senha do usuario >> ");
                            string pass = Console.ReadLine();

                            if(CadastroUsuarios.logar(n, pass)){
                                home.iniciaHome(CadastroUsuarios.cadastrados[CadastroUsuarios.verificaLogin(n, pass)]);
                            }
                            else {
                                Console.Clear();
                                Console.WriteLine("Alguma informação está incorreta!");
                            }
                        }

                        break;
                    case 2:
                        CadastroUsuarios.recolheCadastro();
                        break;
                    case 3:
                        sentinela = true;
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0);
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

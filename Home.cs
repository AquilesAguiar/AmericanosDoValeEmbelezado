using System;

namespace AmericanosDoValeEmbelezado
{
    public class Home
    {
        public string tipoHome{get; private set;}
        private Prestador prestadorAtual;

        Marketplace loja = new Marketplace();


        public void homeCliente(Cliente usuarioLogado){
            int resp = -1;
            bool sentinelaHome = false;
            while(!sentinelaHome) {
                Console.Clear();
                Console.WriteLine($"Olá {usuarioLogado.nome}!");
                Console.WriteLine(@"Oque deseja fazer?
1 - Procurar produtos
2 - Procurar serviços
3 - Ver perfil
4 - Sair");
                resp = int.Parse(Console.ReadLine());
                switch (resp){
                    case 1:
                        loja.marketLoja(resp, usuarioLogado);
                        Console.ReadLine();
                        break;

                    case 2:
                        loja.marketLoja(resp, usuarioLogado);
                        Console.Write("Digite 1 para agendar um serviço ou 0 para sair >> ");
                        int aguarda = int.Parse(Console.ReadLine());

                        if(aguarda == 0){
                            return;
                        }else{
                            Console.Write("Digite o nome do serviço >> ");
                            string nome_serv = Console.ReadLine();
                            DateTime data = DateTime.Today;
                            Console.WriteLine(loja.adcionaPessoa(usuarioLogado, nome_serv, data.ToString("D")));
                            Console.ReadLine();
                        }

                        // switch(aguarda){
                        //    case 0:
                        //         break;
                            
                        //     case 1:
                        //         Console.Write("Digite o nome do serviço >> ");
                        //         string nome_serv = Console.ReadLine();
                        //         DateTime data = DateTime.Today;
                        //         loja.adcionaPessoa(usuarioLogado, nome_serv, data.ToString("D"));
                        //         Console.ReadLine();
                        //         break;
                            
                        //     default:
                        //         break;
                        // }
                        
                        break;    
                        
                    case 3:
                        mostraPerfil(usuarioLogado);
                        break;

                    case 4:
                        sentinelaHome = true;
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }
        }

        public void homePrestador(Prestador usuarioLogado){
            Console.Clear();
            int resp;
            bool sentinelaHome = false;
            while(!sentinelaHome) {
                Console.WriteLine($"Olá {usuarioLogado.nome}!");
                Console.WriteLine(@"Oque deseja fazer?
1 - Cadastrar Produto
2 - Cadastrar Serviço
3 - Ver perfil
4 - Sair");
                resp = int.Parse(Console.ReadLine());

                switch(resp){
                    case 1:
                        usuarioLogado.Cadastro(resp, usuarioLogado.cod);
                        Console.Clear();
                        break;

                    case 2:
                        usuarioLogado.Cadastro(resp, usuarioLogado.cod);
                        Console.Clear();
                        break;
                    
                    case 3:
                        mostraPerfil(usuarioLogado);
                        Console.Clear();
                        break;

                    case 4:
                        sentinelaHome = true;
                        Console.Clear();
                        break;
                        

                }
            }
        }

        private void mostraPerfil(Usuario usuarioLogado){
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Bem-vindo(a) {usuarioLogado.nome}");
            Console.WriteLine("---------------------------");
            Console.WriteLine($@"Informações da conta
Nome: {usuarioLogado.nome}
Telefone: {usuarioLogado.telefone}
Endereço: {usuarioLogado.endereco}
Email: {usuarioLogado.email}");
            if(usuarioLogado.tipo_conta == "C"){
                Console.WriteLine("Tipo da conta: Cliente");
                if(usuarioLogado.cpf_cnpj.ToString().Length == 11){
                    Console.WriteLine($"CPF: {usuarioLogado.cpf_cnpj}");
                }
                else{
                    Console.WriteLine($"CNPJ: {usuarioLogado.cpf_cnpj}");
                }
            }
            else{
                Console.WriteLine("Tipo da conta: Prestador");
                Console.WriteLine($"CNPJ: {usuarioLogado.cpf_cnpj}");
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("Aperte enter para continuar!");
            Console.ReadLine();
        }
        public void cadastroProdutoServico(int tipoCadastro){
            
        }
    }
}
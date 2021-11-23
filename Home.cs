using System;

namespace AmericanosDoValeEmbelezado
{
    public class Home
    {
        public string tipoHome{get; private set;}
        private Usuario usuarioLogado;


        public void iniciaHome(Usuario usuarioLogado){

            this.usuarioLogado = usuarioLogado;
            if(usuarioLogado.tipo_conta == "C"){
                tipoHome = "C";
                homeCliente();
            }
            else{
                tipoHome = "P";
                homePrestador();
            }
        }


        private void homeCliente(){
            int resp = -1;
            bool sentinelaHome = false;
            while(!sentinelaHome) {
                Console.Clear();
                Console.WriteLine($"Olá {usuarioLogado.nome}!");
                Console.WriteLine(@"Oque deseja fazer?
1 - Procurar produtos/serviços
2 - Ver perfil
3 - Sair");
                resp = int.Parse(Console.ReadLine());
                switch (resp){
                    case 1:
                        break;

                    case 2:
                        mostraPerfil(usuarioLogado);
                        break;

                    case 3:
                        sentinelaHome = true;
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }
        }

        private void homePrestador(){
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
                        break;

                    case 2:
                        break;
                    
                    case 3:
                        mostraPerfil(usuarioLogado);
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
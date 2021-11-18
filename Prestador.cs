using System.Collections.Generic;

namespace AmericanosDoValeEmbelezado
{
    public class Prestador : Usuario, ICadastro
    {
        public Prestador(string nome, string telefone, string endereco, string email, string tipo_pessoa, string cpf_cnpj):base(nome, telefone, endereco, email, tipo_pessoa, cpf_cnpj)
        {

        }

         private List<Servico> servicos = new List<Servico>();
         private List<Produto> produtos = new List<Produto>();

        
        //TODO
        public bool Cadastro(){
            return true;
        }

        public bool Remocao(){
            return true;
        }

        public bool Edicao(){
            return true;
        }

    }
}
using System;
using System.Collections.Generic;

namespace AmericanosDoValeEmbelezado
{
    public class Prestador : Usuario, IVerificado
    {
        public Prestador(string nome, string telefone, string endereco, string email, string tipo_conta, string cpf_cnpj):base(nome, telefone, endereco, email, tipo_conta, cpf_cnpj)
        {

            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
            this.tipo_conta = tipo_conta;
            this.cpf_cnpj = cpf_cnpj;

        }

        private List<Servico> servicos = new List<Servico>();
        private List<Produto> produtos = new List<Produto>();
        Dictionary<DateTime, string> agenda = new Dictionary<DateTime, string>();
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

    }
}
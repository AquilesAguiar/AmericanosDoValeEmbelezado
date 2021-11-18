using System.Collections.Generic;
using System;

namespace AmericanosDoValeEmbelezado
{
    public class Prestador : Usuario, IVerificado
    {
        public Prestador(string nome, string telefone, string endereco, string email, string tipo_pessoa, string cpf_cnpj):base(nome, telefone, endereco, email, tipo_pessoa, cpf_cnpj)
        {

        }

        private List<Servico> servicos = new List<Servico>();
        private List<Produto> produtos = new List<Produto>();
        Dictionary<DateTime, string> agenda = new Dictionary<DateTime, string>();
        Dictionary<DateTime, string>.ValueCollection pessoa = agenda;


        public int RetornaTamanhoLista(){

            int cont = 0;
            foreach(string x in pessoa){
                cont ++;
            }
            return cont;
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
           
            return true;
        }

        public bool isTrend(){
            return true;
        }

        public bool isComum(){
            return true;
        }

    }
}
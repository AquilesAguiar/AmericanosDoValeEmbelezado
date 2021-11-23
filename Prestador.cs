using System;
using System.Collections.Generic;
using System.IO;

namespace AmericanosDoValeEmbelezado
{
    public class Prestador : Usuario, IVerificado
    {
        public Prestador(string nome, string telefone, string endereco, string email, string tipo_conta, string cpf_cnpj, string senha):base(nome, telefone, endereco, email, tipo_conta, cpf_cnpj, senha)
        {

            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
            this.tipo_conta = tipo_conta;
            this.cpf_cnpj = cpf_cnpj;
            this.senha = senha;

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

        public void carregaEstoque(String codPrestador){
            StreamReader sr = new StreamReader("estoque.txt");
            string linha = sr.ReadLine();
    
            if(codPrestador == linha.Split("+")[0]){
                while(linha != null) {
                temp = linha.Split(",");
                if(temp[4] == "C"){
                    Cliente user = new Cliente(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
                    cadastrados.Add(user);
                }
                else if(temp[4] == "P") {
                    Prestador user = new Prestador(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
                    cadastrados.Add(user);
                }

                linha = sr.ReadLine();
            }
            }
        }
        public void adicionaProduto(){
            //
        }

        public void adcionaServiço(){

        }

    }
}
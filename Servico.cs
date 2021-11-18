using System;
using System.Collections.Generic;

namespace AmericanosDoValeEmbelezado
{
    public class Servico
    {
        public string nome;

        public string descricao;

        public double preco;

        // public Dictionary<DateTime, string> agenda;

        public Servico(string nome, string descricao, double preco){
            
            this.nome = nome;

            this.descricao =  descricao;

            this.preco = preco;
            
            // agenda = new Dictionary<DateTime, string>();
            
        }

    
    }
}
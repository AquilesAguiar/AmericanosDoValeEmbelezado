namespace AmericanosDoValeEmbelezado
{
    public class Produto
    {
        public string nome;

        public double preco;

        public string descricao;
        
        public int quantidade;

        public Produto(string nome, double preco, string descricao, int quantidade){
            
            this.nome = nome;

            this.preco = preco;

            this.descricao = descricao;

            this.quantidade = quantidade;
        }

    }
}
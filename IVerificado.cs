namespace AmericanosDoValeEmbelezado
{
    public interface IVerificado
    {        
        int qtd_pessoa{get;set;}
        int qtd_produtos{get;set;}    
        bool is_email{get;set;}

        bool isVerified();

        bool isTrend();

        bool isComum();

        

    }
}
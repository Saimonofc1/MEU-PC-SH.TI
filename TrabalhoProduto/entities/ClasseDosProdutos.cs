using System;
using System.Globalization;
namespace funcoesProdutos.entities
{
    public class ClasseDosProdutos
    {
        public string NomeProduto { get; set; }
        public int CodigoProduto { get; set; }
        public double CustoProduto { get; set; }
        public double VendaProduto { get; set; }
        public override string ToString()
        {
            //faz a formatação
            return String.Format("{0,10}{1,25}{2,25}{3,22}", NomeProduto, CodigoProduto, CustoProduto.ToString("F2", CultureInfo.InvariantCulture), VendaProduto.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
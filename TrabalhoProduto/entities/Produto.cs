using System;
using funcoesProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace funcoesProdutos.entities
{
    public class Produtos
    {
        public List<ClasseDosProdutos> ListaDeProdutos { get; set; }
        public void AddProduto(ClasseDosProdutos p)
        {
            ListaDeProdutos.Add(p);
        }
        public int DeleteProduto(int CodigoRemover)
        {
            string NomeArquivo = RetornaNomeArquivo();
            string xml = File.ReadAllText(NomeArquivo);
            int ContaProduto = 1;
            string TagProd = "Prod" + ContaProduto;
            string TagProduto = LerTag(TagProd, xml);
            int IndexCodigo = 0;

            while (TagProduto != "")
            {
                ClasseDosProdutos prod = new ClasseDosProdutos();
                prod.CodigoProduto = int.Parse(LerTag("Codigo", TagProduto));
                if (prod.CodigoProduto == CodigoRemover)
                {
                    IndexCodigo = ContaProduto;
                }
                ContaProduto++;
                TagProd = "Prod" + ContaProduto;
                TagProduto = LerTag(TagProd, xml);
            }
            return IndexCodigo;
        }
        public Produtos()
        {
            ListaDeProdutos = new List<ClasseDosProdutos>();
        }
        public string RetornaNomeArquivo()
        {
            string NomeArquivo = "dados";
            string Diretorio = Directory.GetCurrentDirectory();

            string ArquivoComCaminho = Diretorio + @"\" + NomeArquivo + ".xml";
            return ArquivoComCaminho;
        }
        public string SalvarProduto()
        {
            string NomeArquivo = RetornaNomeArquivo();

            if (File.Exists(NomeArquivo) == true)
            {
                File.Delete(NomeArquivo);
            }

            StreamWriter sw = new StreamWriter(NomeArquivo);
            sw.WriteLine("<XML>");
            sw.WriteLine("    <Produtos>");

            int contaproduto = 1;

            foreach (ClasseDosProdutos prod in ListaDeProdutos)
            {
                sw.WriteLine("        <Prod" + contaproduto + ">");
                sw.WriteLine("            <Nome>" + prod.NomeProduto + "</Nome>");
                sw.WriteLine("            <Codigo>" + prod.CodigoProduto + "</Codigo>");
                sw.WriteLine("            <Custo>" + prod.CustoProduto.ToString("F2") + "</Custo>");
                sw.WriteLine("            <Venda>" + prod.VendaProduto.ToString("F2") + "</Venda>");
                sw.WriteLine("        </Prod" + contaproduto + ">");
                contaproduto++;
            }
            sw.WriteLine("    </Produtos>");
            sw.WriteLine("</XML>");
            sw.Close();
            return "";
        }
        public void CarregarXml(string xmls)
        {
            string xml = File.ReadAllText(xmls);
            int ContaProduto = 1;
            string TagProd = "Prod" + ContaProduto;
            string TagProduto = LerTag(TagProd, xml);

            while (TagProduto != "")
            {
                ClasseDosProdutos prod = new ClasseDosProdutos();
                prod.NomeProduto = LerTag("Nome", TagProduto);
                prod.CodigoProduto = int.Parse(LerTag("Codigo", TagProduto));
                prod.CustoProduto = double.Parse(LerTag("Custo", TagProduto));
                prod.VendaProduto = double.Parse(LerTag("Venda", TagProduto));

                AddProduto(prod);

                ContaProduto++;
                TagProd = "Prod" + ContaProduto;
                TagProduto = LerTag(TagProd, xml);
            }
        }
        private string LerTag(string Tag, string xml)
        {
            int piTag = xml.IndexOf(Tag);
            int pfTag = xml.IndexOf("/" + Tag);
            piTag += Tag.Length + 1;
            pfTag = pfTag - 1;
            int comprimento = pfTag - piTag;
            string retorno = "";
            if (comprimento > 0)
            {
                retorno = xml.Substring(piTag, comprimento);
            }
            else
            {
                retorno = "";
            }
            return retorno;
        }
    }
}
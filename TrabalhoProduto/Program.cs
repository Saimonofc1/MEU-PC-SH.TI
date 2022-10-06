using System;
using funcoesProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace funcoesProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Produtos produto = new Produtos();
            string NomeArquivo = produto.RetornaNomeArquivo();

            if (File.Exists(NomeArquivo) == true)
            {
                produto.CarregarXml(NomeArquivo);
            }
            int itemMenu = 0;
            while (itemMenu != 4)
            {
                switch (itemMenu)
                {
                    case 0:
                        Tela.Menu();
                        itemMenu = int.Parse(System.Console.ReadLine());
                        break;
                    case 1:
                        ClasseDosProdutos prod = Tela.CadastrarProduto();
                        produto.AddProduto(prod);
                        Console.Write("Deseja Cadastrar outro produto? S -> (Sim) e N -> (Não) : ");
                        string NovoProduto = Console.ReadLine();
                        if (NovoProduto == "s" || NovoProduto == "S")
                        {
                            itemMenu = 1;
                        }
                        else
                        {
                            itemMenu = 0;
                        }
                        break;
                    case 2:
                        Tela.RemoverProduto(produto);
                        itemMenu = 0;
                        break;
                    case 3:
                        Tela.ListaProdutos(produto);
                        itemMenu = 0;
                        break;
                }
            }
            string retorno = produto.SalvarProduto();

            if (retorno != "")
            {
                Console.WriteLine(retorno);
                Console.WriteLine("Cuidado -> O sistema encerrará e você perderá suas informações");
                Console.ReadLine();
            }
        }
    }
}

using System;
using funcoesProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace funcoesProdutos
{
    class Tela
    {

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("(--------------------------------)");
            Console.WriteLine("(            MENU                )");
            Console.WriteLine("(--------------------------------)");
            Console.WriteLine("(1) - Lançar Produto             )");
            Console.WriteLine("(2) - Deletar Produto            )");
            Console.WriteLine("(3)- Listar Produtos             )");
            Console.WriteLine("(4)- Sair                        )");
            Console.WriteLine("(--------------------------------)");
        }
        public static ClasseDosProdutos CadastrarProduto()
        {
            Console.Clear();
            ClasseDosProdutos prod = new ClasseDosProdutos();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("(            Cadastrar Produtos              )");
            Console.WriteLine("---------------------------------------------");
            Console.Write(" Digite o Nome: ");
            prod.NomeProduto = Console.ReadLine();
            Console.Write("Digite o Codigo: ");
            prod.CodigoProduto = int.Parse(Console.ReadLine());
            Console.Write("Digite o Custo: ");
            prod.CustoProduto = double.Parse(Console.ReadLine());
            Console.Write("Digite a Venda: ");
            prod.VendaProduto = double.Parse(Console.ReadLine());
            Console.WriteLine("\nO Produto foi adicionado!\n");

            return prod;
        }
        public static void RemoverProduto(Produtos p)
        {
            Console.Clear();
            int i = 0;
            Console.WriteLine("      Nome          |        Código       |        Custo        |            Venda       ");
            foreach (ClasseDosProdutos prod in p.ListaDeProdutos)
            {
                Console.WriteLine(prod.ToString());
                i++;
            }
            if (i >= 1)
            {
                Console.WriteLine("\nDigite o codigo do produto que deseja Deletar: ");
                int CodigoRemover = int.Parse(Console.ReadLine());
                int RetornoRemover = p.DeleteProduto(CodigoRemover);
                if (RetornoRemover > 0)
                {
                    p.ListaDeProdutos.RemoveAt(RetornoRemover - 1);
                    Console.WriteLine("Produto Removido!");
                }
                else
                {
                    Console.WriteLine("\nCodigo não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("\n Produto não encontrado");
            }
            Console.WriteLine("Precione ENTER para ir ao Menu");
            Console.ReadLine();

        }
        public static void ListaProdutos(Produtos p)
        {
            Console.Clear();
            Console.WriteLine("      Nome          |         Código       |          Custo      |           Venda       ");
            foreach (ClasseDosProdutos prod in p.ListaDeProdutos)
            {
                Console.WriteLine(prod.ToString());
            }
            Console.WriteLine("\n\nPrecione ENTER para ir ao Menu");
            Console.ReadLine();
        }
    }
}
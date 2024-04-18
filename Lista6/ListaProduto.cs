using System;

namespace Lista6
{
    public class Produto
    {
        private string nome;
        private int quant;
        private double preco;

        public Produto(string nome, int quant, double preco)
        {
            this.nome = nome;
            this.quant = quant;
            this.preco = preco;
        }

        public string Nome
        {
            get { return nome; }
        }

        public int Quantidade
        {
            get { return quant; }
            set { quant = value; }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public override string ToString()
        {
            return $"[nome: {nome}, quantidade: {quant}, preco: {preco}]";
        }
    }

    public class ListaProduto
    {
        private Produto[] produtos;
        private int contador;

        public ListaProduto()
        {
            produtos = new Produto[100];
            contador = 0;
        }

        public void AdicionarProduto(Produto produto)
        {
            if (contador < produtos.Length)
            {
                produtos[contador] = produto;
                contador++;
            }
            else
            {
                Console.WriteLine("Lista cheia.");
            }
        }

        public Produto RemoverProduto(string nome)
        {
            for (int i = 0; i < contador; i++)
            {
                if (produtos[i].Nome == nome)
                {
                    Produto removido = produtos[i];
                    // Desloca todos os produtos uma posição para trás
                    for (int j = i; j < contador - 1; j++)
                    {
                        produtos[j] = produtos[j + 1];
                    }

                    contador--;
                    return removido;
                }
            }

            return null;
        }

        public bool PesquisarProduto(string nome)
        {
            for (int i = 0; i < contador; i++)
            {
                if (produtos[i].Nome == nome)
                {
                    return true;
                }
            }

            return false;
        }

        public void ListarProdutos()
        {
            Console.WriteLine("Lista de Produtos:");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine(produtos[i].ToString());
            }
        }

        public static void Exe()
        {
            ListaProduto listaDeProdutos = new ListaProduto();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1) Inserir um produto no final da lista.");
                Console.WriteLine("2) Remover um produto especifico da lista.");
                Console.WriteLine("3) Listar os dados de todos os produtos da lista.");
                Console.WriteLine("4) Pesquisar se um produto ja consta na lista.");
                Console.WriteLine("5) Sair");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do produto:");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite a quantidade:");
                        int quant = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o preco:");
                        double preco = Convert.ToDouble(Console.ReadLine());
                        listaDeProdutos.AdicionarProduto(new Produto(nome, quant, preco));
                        break;

                    case 2:
                        Console.WriteLine("Digite o nome do produto a remover:");
                        nome = Console.ReadLine();
                        Produto produtoRemovido = listaDeProdutos.RemoverProduto(nome);
                        if (produtoRemovido == null)
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }

                        break;

                    case 3:
                        listaDeProdutos.ListarProdutos();
                        break;

                    case 4:
                        Console.WriteLine("Digite o nome que deseja pesquisar:");
                        nome = Console.ReadLine();
                        bool encontrado = listaDeProdutos.PesquisarProduto(nome);
                        if (encontrado)
                        {
                            Console.WriteLine("Produto Cadastrado.");
                        }
                        else
                        {
                            Console.WriteLine("Produto não Cadastrado.");
                        }

                        break;

                    case 5:
                        Console.WriteLine("O programa sera encerrado.");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
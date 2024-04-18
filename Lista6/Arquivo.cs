using System;

namespace Lista6
{
    public class Arquivo
    {
        public string Nome { get; private set; }
        public int NumeroPaginas { get; private set; }

        public Arquivo(string nome, int numeroPaginas)
        {
            Nome = nome;
            NumeroPaginas = numeroPaginas;
        }

        public override string ToString()
        {
            return $"nome: {Nome}, numero paginas: {NumeroPaginas}";
        }
    }

    public class Fila
    {
        private Arquivo[] elementos;
        private int contador;

        public Fila()
        {
            elementos = new Arquivo[100];
            contador = 0;
        }

        public void Enfileirar(Arquivo arquivo)
        {
            if (contador < elementos.Length)
            {
                elementos[contador++] = arquivo;
            }
            else
            {
                Console.WriteLine("Fila cheia.");
            }
        }

        public Arquivo Desenfileirar()
        {
            if (contador == 0)
            {
                Console.WriteLine("Fila de impressão vazia.");
                return null;
            }

            Arquivo arquivo = elementos[0];
            for (int i = 1; i < contador; i++)
            {
                elementos[i - 1] = elementos[i];
            }

            elementos[--contador] = null;
            return arquivo;
        }

        public void Exibir()
        {
            if (contador == 0)
            {
                Console.WriteLine("Fila de impressão vazia.");
            }
            else
            {
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine(elementos[i]);
                }
            }
        }

        public static void Exe()
        {
            Fila filaDeImpressao = new Fila();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1. Inserir arquivo na fila de impressao");
                Console.WriteLine("2. Executar impressao");
                Console.WriteLine("3. Exibir fila de impressao");
                Console.WriteLine("4. Sair");

                Console.Write("Escolha uma opção: ");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o nome do arquivo: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a quantidade de paginas: ");
                        int paginas = Convert.ToInt32(Console.ReadLine());
                        filaDeImpressao.Enfileirar(new Arquivo(nome, paginas));
                        break;
                    case 2:
                        Arquivo arquivo = filaDeImpressao.Desenfileirar();
                        if (arquivo != null)
                        {
                            Console.WriteLine($"O arquivo {arquivo.Nome} foi impresso.");
                        }

                        break;
                    case 3:
                        filaDeImpressao.Exibir();
                        break;
                    case 4:
                        Console.WriteLine("O programa será encerrado.");
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
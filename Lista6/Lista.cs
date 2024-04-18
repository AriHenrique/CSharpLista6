using System;

namespace Lista6
{
    public class Lista
    {
        private double[] itens;
        private int contador;

        public Lista(int capacidade)
        {
            itens = new double[capacidade];
            contador = 0;
        }

        public void InserirInicio(double item)
        {
            if (contador == itens.Length) throw new InvalidOperationException("Lista cheia.");
            for (int i = contador; i > 0; i--)
            {
                itens[i] = itens[i - 1];
            }

            itens[0] = item;
            contador++;
        }

        public void InserirFinal(double item)
        {
            if (contador == itens.Length) throw new InvalidOperationException("Lista cheia.");
            itens[contador] = item;
            contador++;
        }

        public void InserirPosicao(double item, int posicao)
        {
            if (contador == itens.Length) throw new InvalidOperationException("Lista cheia.");
            if (posicao < 0 || posicao > contador) throw new IndexOutOfRangeException("Posição inválida.");
            for (int i = contador; i > posicao; i--)
            {
                itens[i] = itens[i - 1];
            }

            itens[posicao] = item;
            contador++;
        }

        public double RemoverInicio()
        {
            if (contador == 0) throw new InvalidOperationException("Lista vazia.");
            double removido = itens[0];
            for (int i = 0; i < contador - 1; i++)
            {
                itens[i] = itens[i + 1];
            }

            contador--;
            return removido;
        }

        public double RemoverFinal()
        {
            if (contador == 0) throw new InvalidOperationException("Lista vazia.");
            double removido = itens[contador - 1];
            contador--;
            return removido;
        }

        public double RemoverPosicao(int posicao)
        {
            if (posicao < 0 || posicao >= contador) throw new IndexOutOfRangeException("Posição inválida.");
            double removido = itens[posicao];
            for (int i = posicao; i < contador - 1; i++)
            {
                itens[i] = itens[i + 1];
            }

            contador--;
            return removido;
        }

        public double RemoverItem(double item)
        {
            int indice = -1;
            for (int i = 0; i < contador; i++)
            {
                if (itens[i] == item)
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1) throw new InvalidOperationException("Item não encontrado.");

            return RemoverPosicao(indice);
        }

        public int Contar(double item)
        {
            int quantidade = 0;
            for (int i = 0; i < contador; i++)
            {
                if (itens[i] == item)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }

        public void Mostrar()
        {
            Console.Write("[ ");
            for (int i = 0; i < contador; i++)
            {
                Console.Write(itens[i] + " ");
            }

            Console.WriteLine("]");
        }

        public static void Exe()
        {
            Lista tempos = new Lista(100);
            bool encerrar = false;

            while (!encerrar)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Inserir um tempo no inicio da lista.");
                Console.WriteLine("2) Inserir um tempo no final da lista.");
                Console.WriteLine("3) Inserir um tempo numa posicao especifica da lista.");
                Console.WriteLine("4) Remover o primeiro tempo da lista.");
                Console.WriteLine("5) Remover o ultimo tempo da lista.");
                Console.WriteLine("6) Remover um tempo de uma posicao especifica na lista.");
                Console.WriteLine("7) Remover um tempo especifico da lista.");
                Console.WriteLine("8) Pesquisar quantas vezes um determinado tempo consta na lista.");
                Console.WriteLine("9) Mostrar todos os tempos da lista.");
                Console.WriteLine("10) Encerrar o programa.");
                int opcao = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Informe o tempo:");
                            tempos.InserirInicio(Convert.ToDouble(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Informe o tempo:");
                            tempos.InserirFinal(Convert.ToDouble(Console.ReadLine()));
                            break;
                        case 3:
                            Console.WriteLine("Informe o tempo:");
                            double tempo = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Informe a posicao:");
                            int posicao = Convert.ToInt32(Console.ReadLine());
                            tempos.InserirPosicao(tempo, posicao);
                            break;
                        case 4:
                            Console.WriteLine("Tempo removido: " + tempos.RemoverInicio() + ".");
                            break;
                        case 5:
                            Console.WriteLine("Tempo removido: " + tempos.RemoverFinal() + ".");
                            break;
                        case 6:
                            Console.WriteLine("Informe a posicao:");
                            posicao = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Tempo removido: " + tempos.RemoverPosicao(posicao) + ".");
                            break;
                        case 7:
                            Console.WriteLine("Informe o tempo a remover:");
                            tempo = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Tempo removido: " + tempos.RemoverItem(tempo) + ".");
                            break;
                        case 8:
                            Console.WriteLine("Informe o tempo:");
                            tempo = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Quantidade: " + tempos.Contar(tempo));
                            break;
                        case 9:
                            tempos.Mostrar();
                            break;
                        case 10:
                            Console.WriteLine("O programa sera encerrado.");
                            encerrar = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }
            }
        }
    }
}
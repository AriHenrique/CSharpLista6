using System;

namespace Lista6
{
    public class Aviao
    {
        private string[] elementos;
        private int frente;
        private int tras;
        private int contador;

        public Aviao(int tamanho)
        {
            elementos = new string[tamanho];
            frente = 0;
            tras = -1;
            contador = 0;
        }

        public void Enfileirar(string id)
        {
            if (contador < elementos.Length)
            {
                tras = (tras + 1) % elementos.Length;
                elementos[tras] = id;
                contador++;
            }
            else
            {
                Console.WriteLine("Fila cheia. Não é possível adicionar mais aviões.");
            }
        }

        public string Desenfileirar()
        {
            if (contador > 0)
            {
                string temp = elementos[frente];
                elementos[frente] = null;
                frente = (frente + 1) % elementos.Length;
                contador--;
                return temp;
            }
            else
            {
                return null;
            }
        }

        public string ObterPrimeiro()
        {
            return contador > 0 ? elementos[frente] : null;
        }

        public int ObterTamanho()
        {
            return contador;
        }

        public void Listar()
        {
            if (contador > 0)
            {
                int index = frente;
                Console.Write("[ ");
                for (int i = 0; i < contador; i++)
                {
                    Console.Write(elementos[index] + " ");
                    index = (index + 1) % elementos.Length;
                }
                Console.WriteLine("]");
            }
            else
            {
                Console.WriteLine("[ ]");
            }
        }
    


        public static void Exe()
        {
            Aviao filaDeDecolagem = new Aviao(5);
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Listar a quantidade de avioes que estao aguardando na fila de decolagem.");
                Console.WriteLine("2.Autorizar a decolagem do primeiro aviao da fila de decolagem.");
                Console.WriteLine("3.Adicionar um aviao na fila de colagem.");
                Console.WriteLine("4.Listar todos os avioes que estao na fila de colagem.");
                Console.WriteLine("5.Exibir o primeiro aviao da fila de colagem.");
                Console.WriteLine("6.Sair");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine($"Quantidade de avioes: {filaDeDecolagem.ObterTamanho()}.");
                        break;
                    case 2:
                        string aviao = filaDeDecolagem.Desenfileirar();
                        if (aviao != null)
                            Console.WriteLine($"O aviao {aviao} decolou.");
                        else
                            Console.WriteLine("Nenhum aviao na fila.");
                        break;
                    case 3:
                        if (filaDeDecolagem.ObterTamanho() < 5)
                        {
                            Console.WriteLine("Digite o identificador do aviao:");
                            string id = Console.ReadLine();
                            filaDeDecolagem.Enfileirar(id);
                        }
                        else
                        {
                            Console.WriteLine("Fila cheia. Nao e possível adicionar mais avioes.");
                        }

                        break;
                    case 4:
                        filaDeDecolagem.Listar();
                        break;
                    case 5:
                        aviao = filaDeDecolagem.ObterPrimeiro();
                        if (aviao != null)
                            Console.WriteLine($"Primeiro aviao da fila: {aviao}");
                        else
                            Console.WriteLine("Nenhum aviao na fila.");
                        break;
                    case 6:
                        Console.Write("O programa sera encerrado!");
                        continuar = false;
                        break;
                }
            }
        }
    }
}
using System;

namespace Lista6
{
    public class Pilha
    {
        private char[] elementos;
        private int topo;

        public Pilha(int tamanhoMaximo)
        {
            elementos = new char[tamanhoMaximo];
            topo = -1;
        }

        public void Push(char elemento)
        {
            if (topo == elementos.Length - 1)
            {
                throw new InvalidOperationException("Pilha cheia");
            }
            elementos[++topo] = elemento;
        }

        public char Pop()
        {
            if (EstaVazia())
            {
                throw new InvalidOperationException("Pilha vazia");
            }
            return elementos[topo--];
        }

        public bool EstaVazia()
        {
            return topo == -1;
        }

        public int ObterTamanho()
        {
            return topo + 1;
        }
        
        public static bool VerificarSequencia(string sequencia)
        {
            Pilha pilha = new Pilha(100);
            foreach (char c in sequencia)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                        pilha.Push(c);
                        break;
                    case ')':
                        if (pilha.EstaVazia() || pilha.Pop() != '(')
                            return false;
                        break;
                    case ']':
                        if (pilha.EstaVazia() || pilha.Pop() != '[')
                            return false;
                        break;
                }
            }

            return pilha.EstaVazia();
        }

        public static void Exe()
        {
            
                Console.WriteLine("Informe a sequencia:");
                string sequencia = Console.ReadLine();
                if (string.IsNullOrEmpty(sequencia))
                {
                    Console.WriteLine("Vazio...");
                }

                bool resultado = VerificarSequencia(sequencia);
                if (resultado)
                    Console.WriteLine("Sequencia bem formada!");
                else
                    Console.WriteLine("Sequencia mal formada!");
            
        }
    }

}
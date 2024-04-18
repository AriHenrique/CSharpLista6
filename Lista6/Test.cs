using System;
using System.IO;
using System.Text;

class Test
{
    
    public static void Verificar(Action methodToExecute)
    {
        TextReader originalStdIn = Console.In;
        TextWriter originalStdOut = Console.Out;

        try
        {
            using (FileStream fileStreamIn = new FileStream("../../pub.in", FileMode.Open, FileAccess.Read))
            using (StreamReader streamReader = new StreamReader(fileStreamIn))
            {
                Console.SetIn(streamReader);

                using (MemoryStream memoryStream = new MemoryStream())
                using (StreamWriter streamWriter = new StreamWriter(memoryStream))
                {
                    Console.SetOut(streamWriter);

                    methodToExecute();

                    streamWriter.Flush();
                    memoryStream.Position = 0;
                    Console.SetOut(originalStdOut);

                    string saidaEsperada;
                    using (StreamReader readerOut = new StreamReader("../../pub.out"))
                    {
                        saidaEsperada = readerOut.ReadToEnd();
                    }

                    string saidaProduzida = Encoding.UTF8.GetString(memoryStream.ToArray());
                    CompararSaidas(saidaEsperada, saidaProduzida);
                }
            }
        }
        finally
        {
            Console.SetIn(originalStdIn);
            Console.SetOut(originalStdOut);
        }
    }

    private static void CompararSaidas(string esperada, string produzida)
    {
        string[] linhasEsperadas = esperada.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        string[] linhasProduzidas = produzida.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        int menorQuantidadeLinhas = Math.Min(linhasEsperadas.Length, linhasProduzidas.Length);

        for (int i = 0; i < menorQuantidadeLinhas; i++)
        {
            if (linhasEsperadas[i] != linhasProduzidas[i])
            {
                
                Diferenca(linhasEsperadas[i], linhasProduzidas[i], i + 1);
            }
        }

        if (linhasEsperadas.Length != linhasProduzidas.Length)
        {
            Console.WriteLine("O número de linhas é diferente.");
            Console.WriteLine($"Esperado (total de linhas): {linhasEsperadas.Length}");
            Console.WriteLine($"Obtido (total de linhas): {linhasProduzidas.Length}");
            if (linhasEsperadas.Length > linhasProduzidas.Length)
            {
                Console.WriteLine("Linhas faltantes a partir da linha: " + (linhasProduzidas.Length + 1));
                for (int i = linhasProduzidas.Length; i < linhasEsperadas.Length; i++)
                {
                    Console.WriteLine($"Faltando: {linhasEsperadas[i]}");
                }
            }
            else
            {
                Console.WriteLine("Linhas extras a partir da linha: " + (linhasEsperadas.Length + 1));
                for (int i = linhasEsperadas.Length; i < linhasProduzidas.Length; i++)
                {
                    Console.WriteLine($"Extra: {linhasProduzidas[i]}");
                }
            }
        }
        else
        {
            Console.WriteLine("A saída do programa é idêntica ao conteúdo do arquivo .out.");
        }
    }

    private static void Diferenca(string esperado, string obtido, int linha)
    {
        Console.WriteLine("--------------------------------");
        int menorTamanho = Math.Min(esperado.Length, obtido.Length);
        StringBuilder resultado = new StringBuilder();

        int posicaoDiferenca = -1;
        for (int j = 0; j < menorTamanho; j++)
        {
            if (esperado[j] != obtido[j])
            {
                posicaoDiferenca = j;
                break;
            }
        }

        if (posicaoDiferenca != -1)
        {
            resultado.Append(obtido.Substring(0, posicaoDiferenca));
            resultado.Append('>');
            resultado.Append(obtido[posicaoDiferenca]);
            resultado.Append('<');
            if (posicaoDiferenca + 1 < obtido.Length)
            {
                resultado.Append(obtido.Substring(posicaoDiferenca + 1));
            }
            
            Console.WriteLine($"Diferença encontrada na linha {linha}, posição {posicaoDiferenca + 1}: '{esperado[posicaoDiferenca]}' vs '{obtido[posicaoDiferenca]}'");
            Console.WriteLine($"Correto: {esperado}");
            Console.WriteLine($"Errado:  {resultado}");
        }
        else if (esperado.Length != obtido.Length)
        {
            Console.WriteLine("\nO comprimento das linhas é diferente.");
            Console.WriteLine($"Esperado (comprimento da linha): {esperado.Length}");
            Console.WriteLine($"Obtido (comprimento da linha): {obtido.Length}");
        }
        else
        {
            Console.WriteLine("As linhas são idênticas.");
        }
    }
}


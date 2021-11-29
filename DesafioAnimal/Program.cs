using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioAnimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inciando a importação do arquivo 1 - Animais...");

            Relatorio relatorio = new Relatorio(DateTime.Now);

            try
            {
                var sr = Arquivo.ImportarArquivo((int)ETipoArquivo.Racas);

                string s = "";
                int row = 0;

                while ((s = sr.ReadLine()) != null)
                {
                    row++;
                    if (row == 1)
                        continue;

                    string str;
                    string[] strArray;
                    str = s;

                    strArray = str.Split(';');

                    relatorio.CadastrarRaca(strArray[0], decimal.Parse(strArray[1]));

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Inciando a importação do arquivo 2 - Racas...");

            try
            {
                var sr = Arquivo.ImportarArquivo((int)ETipoArquivo.Animais);

                string s = "";
                int row = 0;

                while ((s = sr.ReadLine()) != null)
                {
                    row++;
                    if (row == 1)
                        continue;

                    string str;
                    string[] strArray;
                    str = s;

                    strArray = str.Split(';');

                    List<Raca> fooBorItems = (from a in relatorio.Racas
                                           where a.NomeRaca == strArray[1]
                                              select a).ToList();

                    if(fooBorItems.Count == 0)
                        throw new Exception("Valor da arroba não encontrado para a raca: " + strArray[1]);

                    relatorio.CadastrarAnimal(strArray[1], decimal.Parse(strArray[2]), int.Parse(strArray[0]), decimal.Parse(strArray[3]),fooBorItems[0].PrecoArroba);

                }
                               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Iniciando calculo do valor do animal...");

            Arquivo.GerarRelatorio(relatorio);


        }
    }
}
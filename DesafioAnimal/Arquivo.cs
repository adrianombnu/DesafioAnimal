using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAnimal
{
    public class Arquivo
    {
       
        public static StreamReader ImportarArquivo(int tipoArquivo)
        {
            if (tipoArquivo != (int)ETipoArquivo.Animais && tipoArquivo != (int)ETipoArquivo.Racas)
            {
                throw new Exception("Tipo do arquivo é inválido.");
                
            }

            string fullPath = "";

            if (tipoArquivo == (int)ETipoArquivo.Animais)
            {
                fullPath = @"C:\Users\PremierSoft\Documents\adriano\animais.txt";

            }
            else
            {
                fullPath = @"C:\Users\PremierSoft\Documents\adriano\raca.txt";

            }

            FileInfo fi = new FileInfo(fullPath);
            StreamReader sr = fi.OpenText();

            return sr;

        }


        public static void GerarRelatorio(Relatorio relatorio)
        {

            string fileName = @"C:\Users\PremierSoft\Documents\adriano\relatorio.txt";

            using (FileStream fs = File.Create(fileName))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(@"Data de geração do arquivo: " + relatorio.DataRelatorio.ToString("dd/MM/yyyy") + "\n");
                fs.Write(title, 0, title.Length);

                var maxZ = relatorio.Animais.Max(obj => obj.ValorAnimal);
                var maxObj = relatorio.Animais.Where(obj => obj.ValorAnimal == maxZ);

                title = new UTF8Encoding(true).GetBytes(@"O animal de maior valor é o " + maxObj.First().Raca + " no valor de: " + maxObj.First().ValorAnimal + " \n");
                fs.Write(title, 0, title.Length);

                List <Animal> usersByAge = relatorio.Animais.OrderByDescending(user => user.ValorAnimal).ToList();
                foreach (Animal user in usersByAge)
                {
                    title = new UTF8Encoding(true).GetBytes(@"Codigo do animal:" + user.CodigoAnimal +
                                      "\nRaca: " + user.Raca +
                                      "\nPesagem: " + user.Pesagem +
                                      "\nFator multiplicacao: " + user.FatorMultiplicacao +
                                      "\nValor animal: " + user.ValorAnimal + "\n");

                    fs.Write(title, 0, title.Length);

                }


            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAnimal
{
    public class Animal
    {
        public Animal(string raca,
                      decimal pesagem,
                      int codigoAnimal,                      
                      decimal fatorMultiplicacao,
                      decimal valorAnimal)
        {
            Raca = raca;
            Pesagem = pesagem;
            CodigoAnimal = codigoAnimal;
            FatorMultiplicacao = fatorMultiplicacao;
            ValorAnimal = valorAnimal;
        }

        public string Raca { get; private set; }
        public decimal Pesagem { get; private set; }
        public int CodigoAnimal { get; private set; }
        public decimal ValorAnimal { get; private set; }
        public decimal FatorMultiplicacao { get; private set; }

       


    }
}



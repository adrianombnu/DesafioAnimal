using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAnimal
{
    public class Raca
    {
        public Raca(string nomeRaca,
                    decimal precoArroba)
        {
            NomeRaca = nomeRaca;
            PrecoArroba = precoArroba;
        }

        public string NomeRaca { get; private set; }
        public decimal PrecoArroba { get; private set; }

    }
}

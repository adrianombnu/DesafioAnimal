using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAnimal
{
    public class Relatorio
    {
       
        private List<Animal> _animais;  
        private List<Raca> _racas;  

        public DateTime DataRelatorio { get; private set; }
        public IReadOnlyList<Animal> Animais => _animais;
        public IReadOnlyList<Raca> Racas => _racas;

        public Relatorio(DateTime dataRelatorio)
        {
            _animais ??= new List<Animal>();
            _racas   ??= new List<Raca>();
            DataRelatorio = dataRelatorio;
        }

        public void CadastrarAnimal(string raca, decimal pesagem, int codigoAnimal, decimal fatorMultiplicacao, decimal valorArroba)
        {
            var valorAnimal = (pesagem * valorArroba * fatorMultiplicacao);

            var animal = new Animal(raca, pesagem, codigoAnimal, fatorMultiplicacao, valorAnimal);

            if (animal is null)
                throw new Exception("Animal deve ser informado");
            if (animal.CodigoAnimal <= 0)
                throw new Exception("Código do animal deve ser informado");
            if (animal.Pesagem <= 0)
                throw new Exception("Pesagem deve ser informada");
            if (animal.Raca.Length == 0)
                throw new Exception("Raca deve ser informada");
            if (animal.FatorMultiplicacao <= 0)
                throw new Exception("Fator de multiplicacao deve ser informada");
    
            _animais.Add(animal);

        }

        public void CadastrarRaca(string nomeRaca, decimal precoArroba)
        {
            var raca = new Raca(nomeRaca, precoArroba);

            if (raca is null)
                throw new Exception("Raca deve ser informado");
            if (raca.NomeRaca.Length == 0)
                throw new Exception("Nome da raca deve ser informada");
            if (raca.PrecoArroba <= 0)
                throw new Exception("Preco da arroba deve ser informada");
            
            _racas.Add(raca);

        }
    }
}

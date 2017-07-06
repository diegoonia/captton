using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02
{
    class Program
    {
        static void Main(string[] args)
        {

            Azafata aza = new Azafata("Julieta", "Prandi", 734829, 23);

            Pasajero pas = new Pasajero("Diego", "Oña", 37677212, 24, true);

            pas.Viajar(20);
            pas.Viajar(100);

            aza.Viajar(20);

            aza.Viajar(12);
            aza.Viajar(40);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    class Ejercicio02
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero a continuacion y se mostrara escrito");
            int num = int.Parse(Console.ReadLine());
            string numEscrito = "cero";

            switch ( num )
            {
                case 1:
                    numEscrito = "uno";
                    break;
                case 2:
                    numEscrito = "dos";
                    break;
                case 3:
                    numEscrito = "tres";
                    break;
                case 4:
                    numEscrito = "cuatro";
                    break;
                case 5:
                    numEscrito = "cinco";
                    break;
                case 6:
                    numEscrito = "seis";
                    break;
                case 7:
                    numEscrito = "siete";
                    break;
                case 8:
                    numEscrito = "ocho";
                    break;
                case 9:
                    numEscrito = "nueve";
                    break;
                default:
                    break;
            }

            Console.WriteLine("El numero es " + numEscrito);
            Console.ReadKey();
        }
    }
}

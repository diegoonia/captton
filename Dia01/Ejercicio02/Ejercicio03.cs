using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingrese un nro: ");
            int num = int.Parse(Console.ReadLine());

            switch ( num )
            {
                case 1:
                    Console.WriteLine("uno");
                    break;
                case 2:
                    Console.WriteLine("dos");
                    break;
                case 3:
                    Console.WriteLine("tres");
                    break;
                case 4:
                    Console.WriteLine("cuatro");
                    break;
                case 5:
                    Console.WriteLine("cinco");
                    break;
                case 6:
                    Console.WriteLine("seis");
                    break;
                case 7:
                    Console.WriteLine("siete");
                    break;
                case 8:
                    Console.WriteLine("ocho");
                    break;
                case 9:
                    Console.WriteLine("nueve");
                    break;
                default:
                    Console.WriteLine("cero");
                    break;
            }
        }
    }
}

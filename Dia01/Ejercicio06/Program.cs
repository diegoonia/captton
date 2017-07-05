using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio06
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Escriba el puntaje:");
            int puntaje = int.Parse(Console.ReadLine());
            long total=0;
            Boolean esValido = true;

            if ( puntaje >= 1 && puntaje <= 3 )
            {
                total = puntaje * 11;
            }
            else if (puntaje >= 4 && puntaje <= 6)
            {
                total = puntaje * 101;
            }
            else if (puntaje >= 7 && puntaje <= 9)
            {
                total = puntaje * 1001;
            }
            else
            {
                esValido = false;
            }

            if ( esValido )
            {
                Console.WriteLine("Puntaje extra: " + total);
            }
            else
            {
                Console.WriteLine("Puntaje no valido");
            }

            Console.ReadKey();

        }
    }
}

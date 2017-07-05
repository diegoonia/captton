using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio09
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumeros = { 2, 4, 6 , 10 };
            float promedio;
            double total = 0;

            for(int i=0; i<arrayNumeros.Length; i++)
            {
                total += arrayNumeros[i];
            }

            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                Console.Write(arrayNumeros[i] + " ");
            }

            promedio = (float)(total / arrayNumeros.Length);

            Console.WriteLine("\n\nEl promedio es : " + promedio);
            Console.ReadKey();
        }
    }
}

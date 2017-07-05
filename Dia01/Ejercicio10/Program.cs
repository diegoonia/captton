using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumeros = new int[10];

            Console.WriteLine("Ingrese un numero");
            int num = int.Parse(Console.ReadLine());

            arrayNumeros[0] = num;

            for(int i=1; i<arrayNumeros.Length; i++)
            {
                num++;
                arrayNumeros[i] = num;
            }

            for(int i=0; i<arrayNumeros.Length; i++)
            {
                Console.Write(arrayNumeros[i] + " ");
            }

            Console.ReadKey();
        }
    }
}

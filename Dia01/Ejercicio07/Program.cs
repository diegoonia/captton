using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumeros = { 2, 5, 7, 20, 30, 100, 34, 30, 23 };

            Console.WriteLine("Ingrese el nro que busca: ");
            int num = int.Parse(Console.ReadLine());
            Boolean numeroEncontrado = false;
            int posicion = -1;

            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                Console.Write(arrayNumeros[i] + " ");

                if ( num == arrayNumeros[i] && !numeroEncontrado ) //Me va a mostrar la posicion del primero que encontro
                {
                    posicion = i+1;
                    numeroEncontrado = true;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Numero encontrado en la posicion : " + posicion);
            
            Console.ReadKey();
        }
    }
}

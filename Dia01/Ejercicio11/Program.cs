using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingrese un palindromo");
            string palabra = Console.ReadLine();
            palabra = palabra.Replace(" ", "").ToLower();

            Console.WriteLine(palabra);
            

            int i = 0;
            int j = palabra.Length-1;
            Boolean esPalindromo = true;
            while( i < j && esPalindromo )
            {
                if( palabra[i] != palabra[j] )
                {
                    esPalindromo = false;
                }
                i++;
                j--;
            }

            if( esPalindromo)
            {
                Console.WriteLine("Es palindromo");
            }
            else
            {
                Console.WriteLine("No palindromo");
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio04
{
    class Ejecicio04
    {
        static void Main(string[] args)
        {
            /*
             * Declarar un array de 5 posiciones de texto y luego inicializarlo.
                Recorrerlo imprimiendo por pantalla cada uno de los valores contenidos
                Declarar un array de 5 posiciones numéricas e inicializarlo en la misma linea.
                Recorrerlo e imprimir sólo los números contenidos que sean pares
             */

            string[] arrayString = { "hola", "como", "andas", "todo", "bien" };

            for (int i = 0; i < arrayString.Length; i++)
            {
                 Console.Write(arrayString[i] + " ");
            }


            int[] arrayNumeros = { 5, 10, 20, 2, 9 };
            Boolean numeroEncontrado = false;
            int posicion = -1;

            Console.WriteLine();
            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                if ( arrayNumeros[i]%2 == 0) //Me va a mostrar la posicion del primero que encontro
                {
                    Console.Write(arrayNumeros[i] + " ");
                }
            }

            Console.ReadKey();

        }
    }
}

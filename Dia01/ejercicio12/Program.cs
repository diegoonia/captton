using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio12
{
    class Program
    {
        /*
         * Dado un valor de temperatura por consola y una unidad de medida origen y destino, convertir el valor según corresponda.
         * Las unidades disponibles de temperatura serán: Grados Celsius, Grados Fahrenheit o Grados Kelvin. 

            Dado un valor de distancia por consola y una unidad de medida origen y destino, convertir el valor según corresponda. 
         * Las unidades disponibles de distancia serán: Metros, Pies, Kilometros, Millas, Centimetros y Pulgadas.
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una temperatura, luego ingresara en que unidad está la misma");
            float tempOriginal = float.Parse(Console.ReadLine());
            int opcion;

            do
            {
                Console.WriteLine("\nIndique en que unidad está su temperatura y a que unidad la convierte\n Elija una opcion válida:");
                Console.WriteLine("1 : Celsius a Fahrenheit");
                Console.WriteLine("2 : Celsius a Kelvin");
                Console.WriteLine("3 : Fahrenheit a Celsius");
                Console.WriteLine("4 : Fahrenheit a Kelvin");
                Console.WriteLine("5 : Kelvin a Celsius");
                Console.WriteLine("6 : Kelvin a Fahrenheit");
                opcion = int.Parse(Console.ReadLine());
            } while (opcion < 1 || opcion > 6);

            float tempConvertida=0;

            switch ( opcion )
            {
                case 1: //Celsius a Fahrenheit
                    tempConvertida = (float)(tempOriginal * 1.8 + 32);
                    break;

                case 2: //Celsius a Kelvin
                    tempConvertida = (float)(tempOriginal + 273);
                    break;

                case 3: //Fahrenheit a Celsius
                    tempConvertida = (float)(tempOriginal - 32 / 1.8);
                    break;

                case 4: //Fahrenheit a Kelvin
                    tempConvertida = (float)((tempOriginal - 32 / 1.8) + 273 );
                    break;

                case 5: //Kelvin a Celsius
                    tempConvertida = (float)(tempOriginal - 273);
                    break;

                case 6: //Kelvin a Fahrenheit
                    tempConvertida = (float)((tempOriginal - 32 / 1.8) - 273);
                    break;
            }

            Console.WriteLine("\nLa temperatura convertida es: " + tempConvertida);

            Console.ReadKey();

        }
    }
}

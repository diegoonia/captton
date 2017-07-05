using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13
{
    class Program
    {
        /*
         * Desarrolle una calculadora de interes para los clientes de un banco dado por linea de comando un capital inicial, 
         * taza anual(taza por periodo) y cantidad de años(cantidad de periodos).

La formula a utilizar es:  el capital acumulado del periodo anterior + (taza * el capital acumulado)
Ejemplo:
Periodos p = 4 | Taza i = 10 % | Capital inicial c = $1000
p = 1 | capital acumulado = $1000 | interes = (capital acumulado * taza) $1000 * 0.1 = $100
p = 2 | capital acumulado = $1100 | interes = (capital acumulado * taza) $1100 * 0.1 = $110
p = 3 | capital acumulado = $1210 | interes = (capital acumulado * taza) $1210 * 0.1 = $121
p = 4 | capital acumulado = $1331 | interes = (capital acumulado * taza) $1331 * 0.1 = $133
Intereses acumulado a lo largo al final del 4 periodo $464

A tener en cuenta, el sistema tiene que ser a prueba de errores por lo tanto:
Para prevenir errores de los usuarios, no permite tazas negativas, emite un error cuando se ingresa un valor negativo.
Los intereses no pueden sobrepasar un maximo del 50%. Emite un error por pantall cuando se ingresa un valor que sobrepasa el 50% de interes.
El Capital no puede ser negativo, emite un error por pantalla cuando se ingresa un valor negativo.
Al final emite un informe con los datos ingresados, el capital final y el interes generado.
         * */
        static void Main(string[] args)
        {
            int periodos;
            float taza;
            float capitalAcumulado;
            float capitalInicial;

            Console.WriteLine("Ingrese la cantidad de periodos");
            do
            {
                periodos = int.Parse(Console.ReadLine());

                if (periodos <= 0)
                {
                    Console.WriteLine("Periodo no válido, no puede ser un número negativo");
                    Console.WriteLine("Ingrese nuevamente la cantidad de periodos");
                }
            } while (periodos <= 0);

            ///////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nIngrese la taza (debe ser un valor entre 0 y 50");
            do
            {
                taza = float.Parse(Console.ReadLine());

                if( taza < 0 || taza >= 50 )
                {
                    Console.WriteLine("Taza ingresada no válida, debe ser un valor entre 0 y 50");
                    Console.WriteLine("Ingrese nuevamente la taza");
                }
            } while ( taza < 0 || taza >= 50);

            taza = (float)(taza * 0.01);

            ///////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nIngrese el capital inicial");
            do
            {
                capitalInicial = float.Parse(Console.ReadLine());

                if (capitalInicial < 0)
                {
                    Console.WriteLine("Capital no válido, no puede ser un número negativo");
                    Console.WriteLine("Ingrese nuevamente el capital");
                }
            } while (capitalInicial < 0);

            capitalAcumulado = capitalInicial;
            float interes = 0;
            float interesTotal = 0;

            Console.WriteLine("periodos = " + periodos + " | Taza i = " + taza * 100 + " % | Capital inicial c = $" + capitalInicial);

            for (int i = 1; i <= periodos; i++)
            {
                Console.Write("\n p = " + i + " | Cap acum = $" + capitalAcumulado + " | interes = (cap acum * taza) ");
                Console.Write("$" + capitalAcumulado + " * " + taza + " = ");

                interes = capitalAcumulado * taza;
                interesTotal += interes;
                Console.Write("$" + interes);

                capitalAcumulado = capitalAcumulado + interes;
            }

            Console.WriteLine("\nIntereses acumulados a lo largo al final del " + periodos + " periodo $" + interesTotal);


            Console.ReadKey();


        }
    }
}

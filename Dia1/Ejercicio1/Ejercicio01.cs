using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        /*
         * Pedir al usuario que ingrese su nombre y su edad, guardando ambos valores 
         * en variables. Mostrar un mensaje de bienvenida que contenga ambos valores.*/
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba su nombre");
            string usuario = Console.ReadLine();

            Console.WriteLine("Escriba su edad");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Bienvenido " + usuario + ", de " + edad + " años");
            Console.ReadKey();
        }
    }
}

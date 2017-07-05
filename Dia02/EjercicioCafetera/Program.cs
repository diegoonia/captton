using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCafetera
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafetera cafetera = new Cafetera();
            bool terminarPrograma = false;
            int opcion = 1;
            int cantidad;

            while ( opcion != 0 )
            {
                Console.Clear();

                Console.WriteLine("Que desea hacer?");
                Console.WriteLine("1- Llenar cafetera");
                Console.WriteLine("2- Servir taza");
                Console.WriteLine("3- Vaciar cafetera");
                Console.WriteLine("4- Agregar cafe");
                Console.WriteLine("\n0- Terminar programa");

                opcion = int.Parse(Console.ReadLine());

                Console.Clear();

                switch ( opcion )
                {
                    case 1:
                        Console.WriteLine("Cafetera llenada");
                        cafetera.LlenarCafetera();
                        break;

                    case 2:
                        Console.WriteLine("Indique la cantidad de cafe que quiere servir");
                        cantidad = int.Parse(Console.ReadLine());
                        cafetera.ServirTaza(cantidad);
                        break;

                    case 3:
                        Console.WriteLine("Cafetera vaciada");
                        cafetera.VaciarCafetera();
                        break;

                    case 4:
                        Console.WriteLine("Indique la cantidad de cafe que quiere agregar a la cafetera");
                        cantidad = int.Parse(Console.ReadLine());
                        cafetera.AgregarCafe(cantidad);
                        break;

                    default:
                        break;
                }

                if(opcion != 0)
                {
                    Console.WriteLine("\n\n\nCantidad actual de cafe: " + cafetera.GetCantidadActual());
                    Console.WriteLine("\nCapacidad maxima de cafetera: " + cafetera.GetCapacidadMaxima());
                }
               
                Console.ReadKey();
                
            }


        }
    }
}

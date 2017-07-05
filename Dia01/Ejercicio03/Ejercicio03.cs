using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03
{
    class Ejercicio03
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingrese un nro: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese otro nro: ");
            int num2 = int.Parse(Console.ReadLine());

            if ( num < num2 )
            {
                Console.WriteLine(num + "," + num2);
            }
            else
            {
                Console.WriteLine(num2 + "," + num);
            }

            Console.ReadKey();
        }
    }
}

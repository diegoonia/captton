using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton single1 = Singleton.GetInstancia();
            Singleton single2 = Singleton.GetInstancia();
            Singleton single3 = Singleton.GetInstancia();
            Singleton single4 = Singleton.GetInstancia();

            Console.WriteLine(single4.cantidadDeInstancias);

            Console.WriteLine("Que numero desea poner en single?");
            single4.numero = int.Parse(Console.ReadLine());

            Console.WriteLine("single1: " + single1.numero + " | single2: " + single2.numero);


            Perro per = LaFactoria.CriarDogui("Grande");

            Console.ReadKey();
        }
    }
}

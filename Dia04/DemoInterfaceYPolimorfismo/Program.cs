using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaceYPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("Animal");
            Tigre tigre = new Tigre("Tiger");
            Perro perro = new Perro("Scooby-Doo");

            List<Animal> lista = new List<Animal>();
            lista.Add(animal);
            lista.Add(tigre);
            lista.Add(perro);

            foreach (Animal item in lista)
            {
                if (item is Perro)
                {
                    Perro per = item as Perro;
                    Console.WriteLine(per.nombre + ": " +  per.Pasear("Haedo"));
                }
            }

            Console.ReadKey();
        }
    }
}

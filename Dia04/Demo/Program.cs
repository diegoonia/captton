using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Actor actor = new Actor("Joey", "Tribianni", 123456);

            actor.Hablar();
            Console.WriteLine(actor.Comer());

            Console.ReadKey();

        }
    }
}

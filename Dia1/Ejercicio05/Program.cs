using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio05
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BASE = 3;
            const int EXP = 4;

            long total;

            int i = 1;
            total = BASE;
            while (i < EXP)
            {
                total *= BASE;
                i++;
            }

            Console.WriteLine( BASE + " elevado a " + EXP + " es " + total);

            total = BASE;
            for (int j = 1; j < EXP; j++)
            {
                total *= BASE;
            }

            Console.WriteLine( BASE + " elevado a " + EXP + " es " + total);
            Console.ReadKey();
        }
    }
}

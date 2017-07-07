using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSingleton
{
    class Singleton
    {
        private static Singleton single;
        //ESTO NO SE NECESITA
        public int cantidadDeInstancias;
        public int numero;



        private Singleton()
        {
            cantidadDeInstancias++;
        }

        public static Singleton GetInstancia()
        {
            if (single == null)
            {
                single = new Singleton();
            }
            return single;
        }


    }
}

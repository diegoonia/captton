using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSingleton
{
    class LaFactoria : IPerreable
    {

        static public Perro CriarDogui(string tamaño)
        {
            Perro per = null;

            switch(tamaño)
            {
                case "Grande":
                    per = new Pitbull();
                    break;
                case "Mediano":
                    per = new Labrador();
                    break;
                case "Chico":
                    per = new Caniche();
                    break;
            }

            return per;
        }
    }
}

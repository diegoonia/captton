using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaceYPolimorfismo
{
    class Perro : Animal, IPaseable
    {

        public Perro(string name) : base(name)
        {
            
        }



        public string Pasear(string lugar)
        {
            return "Estoy paseando en " + lugar;
        }
    }
}

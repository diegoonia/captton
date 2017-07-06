using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Actor : Persona
    {
        public Actor(string name, string lastname, int dni) : base(name, lastname, dni)
        {
            
        }

        public override void Hablar()
        {
            Console.WriteLine(this.nombre + ": how you doin");
        }

        public override string Comer()
        {
            return this.nombre + ": doesn't share food!";
        }


    }
}

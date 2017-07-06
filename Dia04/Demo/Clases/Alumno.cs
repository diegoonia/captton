using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Alumno : Persona
    {
        public float promedio;

        public Alumno(string name, string lastname, int dni, float promedio)
            : base(name, lastname, dni)
        {
            this.promedio = promedio;
        }

        public override void Hablar()
        {
            Console.WriteLine("Eaeaeaea");
        }

        public override string Comer()
        {
            return "ñami ñami";
        }

        public override string Pensar()
        {
            return "mmmmmm.. espera un momento";
        }


    }
}

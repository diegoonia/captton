using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02.Clases
{
    abstract class Actor
    {
        protected int id;
        protected string nombre;
        protected string apellido;
        protected int edad;
        protected int horasDeVuelo;

        public Actor(string nombre, string apellido, int id, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.id = id;
            this.edad = edad;
        }

        virtual public void Viajar(int horas)
        {
            horasDeVuelo += horas;
            Console.WriteLine("Ahora mi total de horas viajadas son: " + horasDeVuelo);

            this.GetPremio();
        }

        abstract public void GetPremio();

    }
}

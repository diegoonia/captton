using ejercicio02.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02
{
    class Azafata : Actor
    {
        const int HORAS_PREMIO = 50;

        public Azafata(string nombre, string apellido, int id, int edad) : base (nombre, apellido, id, edad)
        {
            
        }

        public override void GetPremio()
        {
            if ( this.horasDeVuelo > HORAS_PREMIO )
            {
                Console.WriteLine("Felicitaciones usted ha llegado/superado las 50 horas, tiene un bonus del 20% de su sueldo");
            }
            else
            {
                Console.WriteLine("Aun te faltan "+ (HORAS_PREMIO - this.horasDeVuelo) +" cantidad de horas para el premio");
            }
        }
    }
}

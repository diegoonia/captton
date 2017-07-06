using ejercicio02.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02
{
    class Pasajero : Actor
    {
        const int HORAS_PREMIO = 100;
        bool esFrecuente;

        public Pasajero(string nombre, string apellido, int id, int edad, bool esFrecuente) : base (nombre, apellido, id, edad)
        {
            this.esFrecuente = esFrecuente;
        }

        public override void GetPremio()
        {
            if (this.horasDeVuelo > HORAS_PREMIO && esFrecuente)
            {
                Console.WriteLine("Felicitaciones usted ha llegado/superado las 100 horas y al ser frecuente se le regala un pasaje a Miami");
            }
            else if ( this.horasDeVuelo > HORAS_PREMIO && !esFrecuente )
            {
                Console.WriteLine("Felicitaciones usted ha llegado/superado las 100 horas  se le regala un pasaje a Brasil");
            } else
            {
                Console.WriteLine("Aun te faltan " + (HORAS_PREMIO - this.horasDeVuelo) + " cantidad de horas para el premio");
            }

        }
    }
}

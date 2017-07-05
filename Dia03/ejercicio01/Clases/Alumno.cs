using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Alumno
    {
        private string nombre;

        public Alumno(string nombre, Universidad uni)
        {
            this.nombre = nombre;
            uni.AñadirAlumno(this);
        }

        public string HablaAlumno()
        {
            return nombre + ": Estoy cursando";
        }
    }
}

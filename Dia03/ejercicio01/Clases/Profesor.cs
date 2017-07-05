using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Profesor
    {
        private string nombre;

        public Profesor(string nombre)
        {
            this.nombre = nombre;
           
        }

        public string GetNombre()
        {
            return nombre;
        }
    }
}

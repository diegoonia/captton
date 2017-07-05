using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase
{
    class Empleado
    {
        public string nombre;

        public Empleado(string name)
        {
            this.nombre = name;
        }

        public string Trabajar()
        {
            return this.nombre + ": Trabaja muy duro";
        }
    }

}


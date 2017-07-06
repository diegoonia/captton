using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01.Clases
{
    class Factura
    {
        public float montoTotal;
        public int mes;

        public Factura(int mes, float montoTotal)
        {
            this.mes = mes;
            this.montoTotal = montoTotal;
        }
    }
}

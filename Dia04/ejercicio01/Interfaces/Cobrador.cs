using ejercicio01.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    interface Cobrador
    {

        string EmitirFactura(int mes);

        void CalcularMontoFacturar(int mes);

    }
}

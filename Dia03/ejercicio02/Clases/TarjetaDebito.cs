using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02
{
    class TarjetaDebito
    {

        private int cuenta;

        public TarjetaDebito(int cuenta)
        {
            this.cuenta = cuenta;
        }


        public string GetCuenta()
        {
            return cuenta.ToString();
        }
    }
}

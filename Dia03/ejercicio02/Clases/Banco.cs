using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02
{
    class Banco
    {
        public List<CuentaBancaria> listaDeCuentasBancarias = new List<CuentaBancaria>();
        public string nombre;

        public Banco(string nombre)
        {
            this.nombre = nombre;
        }

        public void añadirCuentaBancaria(CuentaBancaria cuenta)
        {
            listaDeCuentasBancarias.Add(cuenta);
        }

        public string hablanCuentas()
        {
            StringBuilder str = new StringBuilder();

            foreach (CuentaBancaria item in listaDeCuentasBancarias)
            {
                str.AppendLine(item.hablaCuenta());
            }

            return str.ToString();
        }
    }
}

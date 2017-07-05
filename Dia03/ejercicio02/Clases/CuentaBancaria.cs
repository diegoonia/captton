using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02
{
    class CuentaBancaria
    {
        private Cliente titular;
        private TarjetaDebito tarjeta;

        public CuentaBancaria(Cliente cliente, int numeroCuenta)
        {
            titular = cliente;
            tarjeta = new TarjetaDebito(numeroCuenta);
        }

        public string hablaCuenta()
        {
            return "Hola, soy " + titular.GetNombre() + " y mi tarjeta es: " + tarjeta.GetCuenta();
        }

        public Cliente getCliente()
        {
            return titular;
        }

        public TarjetaDebito getTarjeta()
        {
            return tarjeta;
        }
    }
}

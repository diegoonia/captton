using ejercicio01.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Empleado : Persona, Cobrador
    {
        public float salarioHora;
        public int horasTrabajadas;
        public List<Factura> listaFacturas = new List<Factura>();

        public Empleado(string nombre, int edad, float salarioHora, int horasTrabajadas)
            : base(nombre, edad)
        {
            this.salarioHora = salarioHora;
            this.horasTrabajadas = horasTrabajadas;
        }

        public string EmitirFactura(int mes)
        {
            foreach (Factura item in listaFacturas)
	        {
		        if( item.mes == mes )
                {
                    return "Emitiendo factura del mes " + mes + ", con un monto total de: $" + item.montoTotal;
                }
	        }
            return "No hay factura de ese mes";
        }

        public string EmitirTodasLasFacturas()
        {
            StringBuilder str = new StringBuilder();
            foreach (Factura item in listaFacturas)
            {
                str.AppendLine("Emitiendo factura del mes " + item.mes + ", con un monto total de: $" + item.montoTotal);
            }
            return str.ToString();
        }

        public void CalcularMontoFacturar(int mes)
        {
            listaFacturas.Add(new Factura(mes, salarioHora * horasTrabajadas));
        }

        public void CambioDeHorasTrabajadas(int horasNuevas)
        {
            this.horasTrabajadas = horasNuevas;
        }

        public void CambioDeSalarioHora(int salarioNuevo)
        {
            this.salarioHora = salarioNuevo;
        }
    }
}

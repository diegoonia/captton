using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
*
*
* Trabajo Practico Integrador - Semana 1
* Oña, Diego
*
*
*/
namespace ProyectoDia05
{
    class Factura
    {
        private char tipo; //A discriminado tiene IVA, B no discriminado, tiene IVA pero no lo muestra
        Cliente cliente;
        float total, precioUnitario, iva;
        int cantidad;

        public Factura(char tipo, Cliente cliente, float total, int cantidad)
        {
            cliente.agregarFactura(this);
            this.tipo = tipo;
            this.precioUnitario = total / cantidad;
            if( tipo == 'A' )
            {
                this.total = (float)(total * 0.79); //LE SACO EL 21%
                iva = total - this.total;
            }
            else
            {
                this.total = total;
            }
            this.cliente = cliente;
            this.cantidad = cantidad;
        }

        public void mostrarInfo()
        {
            Console.WriteLine("Factura tipo " + tipo);
            Console.WriteLine("Cantidad: " + cantidad);
            Console.WriteLine("Precio unitario: $" + precioUnitario);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Total: $" + total);
            if ( tipo == 'A' )
            {
                Console.WriteLine("IVA discriminado: $" + iva);
            }
        }

    }
}

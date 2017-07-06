using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {

            Empleado emp = new Empleado("Diego", 24, 150, 140);

            //Calculo el mes de enero, y emito la factura
            emp.CalcularMontoFacturar(1);
            //Console.WriteLine(emp.EmitirFactura(1));

            //En febrero le cambio la cantidad de horas
            emp.CambioDeHorasTrabajadas(100);
            //Y emito la factura de febrero
            emp.CalcularMontoFacturar(2);
            //Console.WriteLine(emp.EmitirFactura(2));

            //Aca emito la factura de marzo, pero no calcule nada, asi que no la encuentra
            //Console.WriteLine(emp.EmitirFactura(3));

            Console.WriteLine(emp.EmitirTodasLasFacturas());

            Console.ReadKey();
        }
    }
}

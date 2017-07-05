using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase
{
    class Program
    {
        static void Main(string[] args)
        {

            TarjetaIdentificacion tarj = new TarjetaIdentificacion();
            Empleado emp1 = new Empleado("Gabi");
            Empleado emp2 = new Empleado("Mario");
            Empleado emp3 = new Empleado("Matias");
            Supervisor sup = new Supervisor("Dario", "Banco Rio");

            Console.WriteLine(sup.Ingresar(tarj));

            sup.AgregarEmpleado(emp1);
            sup.AgregarEmpleado(emp2);
            sup.AgregarEmpleado(emp3);

            Console.WriteLine(sup.HacerTrabajar());

            Console.WriteLine("El sueldo antes de evaluar es: " + sup.sueldo);

            sup.Evaluar();

            Console.WriteLine("El sueldo despues de evaluar es: " + sup.sueldo);

            Console.ReadKey();

        }
    }
}

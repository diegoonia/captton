using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioOpcional
{
    class Program
    {
        static void Main(string[] args)
        {

            Empresa empresa = new Empresa("Garbarino");
            Producto prod = new Producto(111, "Notebook ASUS", 10, 10000);
            Producto prod2 = new Producto(112, "Parlantes BOSE", 10, 6000);

            Cliente cli = new Cliente(123, "Diego Oña");

            empresa.AñadirProducto(prod);
            empresa.AñadirProducto(prod2);

            empresa.Vender(prod, cli);
            empresa.Vender(prod, cli);
            empresa.Vender(prod2, cli);
            empresa.Vender(prod, 5, cli);

            Console.ReadKey();
        }
    }
}

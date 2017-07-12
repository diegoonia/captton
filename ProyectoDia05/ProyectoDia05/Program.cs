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
    class Program
    {
        static void Main(string[] args)
        {
            const bool IVA_DISCRIMINADO = true;

            Empresa empresa = new Empresa("Carbarino", 20000);
            Cliente cli = new Cliente("Diego", "Oña", 37677212);

            MateriaPrima metal = new MateriaPrima(111, "metal", 10);
            MateriaPrima madera = new MateriaPrima(222, "madera", 15);

            Proveedor prov = new Proveedor("PEPE PROVEEDOR");

            prov.AgregarMateriaPrima(metal);
            prov.AgregarMateriaPrima(madera);

            List<MateriaPrima> listaMateria1 = new List<MateriaPrima>();
            listaMateria1.Add(metal);
            listaMateria1.Add(madera);

            madera.AumentarCantidad(100);
            metal.AumentarCantidad(100);

            empresa.ComprarAProveedor(prov, madera, 200);
            empresa.ComprarAProveedor(prov, metal, 400);

            Manufactura manu1 = new Manufactura(123, "transistor bc377", 20, listaMateria1);
            Servicio serv1 = new Servicio(124, "servicio tecnico", 500);

            empresa.AgregarProducto(manu1, 500);
            empresa.AgregarProducto(serv1);

            empresa.Producir(manu1);

            cli.Habilitar();
            empresa.Vender(cli, manu1, 20, IVA_DISCRIMINADO);

            cli.MostrarInfoFacturas();

            Console.ReadKey();
        }
    }
}

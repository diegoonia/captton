using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDia05
{
    class Fabrica
    {
        string nombre;
        List<Producto> listaProductos = new List<Producto>();

        public Fabrica(string nombre)
        {
            this.nombre = nombre;
        }

        public void Vender(Cliente cliente, Producto producto)
        {
            
            if( cliente.EstaHabilitado() )
            {
                
            }
            else
            {
                Console.WriteLine("Cliente no esá habilitado");
            }

        }
    }
}

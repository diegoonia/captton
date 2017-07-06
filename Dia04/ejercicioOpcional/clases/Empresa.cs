using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioOpcional
{
    class Empresa
    {
        private string nombre;
        private List<Producto> listaProductos = new List<Producto>();

        public Empresa( string nombre)
        {
            this.nombre = nombre;
        }

        public void AñadirProducto(Producto producto)
        {
            listaProductos.Add(producto);
        }

        public void Vender(Producto producto, Cliente cliente)
        {
            bool productoEncontrado = false;

            foreach (Producto item in listaProductos)
            {
                if ( item.GetId() == producto.GetId() )
                {
                    if ( item.GetStock() > 0 )
                    {
                        item.SeVendio();

                        if (cliente.EsHabitual())
                        {
                            Console.WriteLine("Del producto: " + item.GetNombreProducto() + " me queda de stock: " + item.GetStock());
                            Console.WriteLine("Al cliente: " + cliente.GetNombreYApellido() + " le va a salir: $" + (item.GetPrecio() * 0.95));
                            Console.WriteLine("El cliente es habitual\n");
                        }
                        else
                        {
                            Console.WriteLine("Del producto: " + item.GetNombreProducto() + " me queda de stock: " + item.GetStock());
                            Console.WriteLine("Al cliente: " + cliente.GetNombreYApellido() + " le va a salir: $" + item.GetPrecio());
                            Console.WriteLine("El cliente no es habitual, tiene hechas " + cliente.GetCantidadCompras() + " compras\n");
                            cliente.ComproProducto();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay stock del producto\n");
                    }

                    productoEncontrado = true;
                }
            }

            if ( !productoEncontrado )
            {
                Console.WriteLine("No se encontro el producto\n");
            }
        }


        public void Vender(Producto producto, int cantidad, Cliente cliente)
        {
            bool productoEncontrado = false;

            foreach (Producto item in listaProductos)
            {
                if (item.GetId() == producto.GetId())
                {
                    if ( item.GetStock() > cantidad )
                    {
                        item.SeVendio(cantidad);

                        if (cliente.EsHabitual())
                        {
                            Console.WriteLine("Del producto: " + item.GetNombreProducto() + " me queda de stock: " + item.GetStock());
                            Console.WriteLine("Al cliente: " + cliente.GetNombreYApellido() + " le va a salir: $" + (cantidad * (item.GetPrecio() * 0.95)));
                            Console.WriteLine("El cliente es habitual\n");
                        }
                        else
                        {
                            Console.WriteLine("Del producto: " + item.GetNombreProducto() + " me queda de stock: " + item.GetStock());
                            Console.WriteLine("Al cliente: " + cliente.GetNombreYApellido() + " le va a salir: $" + item.GetPrecio());
                            Console.WriteLine("El cliente no es habitual, tiene hechas " + cliente.GetCantidadCompras() + " compras\n");
                            cliente.ComproProducto();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay stock del producto\n");
                    }
                    productoEncontrado = true;
                }
            }

            if (!productoEncontrado)
            {
                Console.WriteLine("No se encontro el producto\n");
            }
        }
    }
}

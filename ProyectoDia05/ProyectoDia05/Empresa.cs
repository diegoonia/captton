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
    class Empresa
    {
        string nombre;
        float capital;
        List<Producto> listaProductos = new List<Producto>();
        List<MateriaPrima> listaMateria = new List<MateriaPrima>();

        public Empresa(string nombre, float capital)
        {
            this.capital = capital;
            this.nombre = nombre;
        }

        /* AGREGO PRODUCTO SIN FABRICARLO (osea no gasto materia prima, magia) */
        public void AgregarProducto(Producto producto)
        {
            bool existeProducto = false;

            foreach (Producto item in listaProductos)
            {
                if (producto.GetCodigo() == item.GetCodigo())
                {
                    Type tipoProducto = producto.GetType();
                    if (tipoProducto.Name.Equals("Manufactura"))
                    {
                        Manufactura manufac = (Manufactura)producto;
                        //manufac.AumentarStock(1);
                    }
                }
            }

            if (!existeProducto)
            {
                listaProductos.Add(producto);
            }
        }

        /* AGREGO PRODUCTO SIN FABRICARLO (osea no gasto materia prima, magia) */
        public void AgregarProducto(Producto producto, int cantidad)
        {
            bool existeProducto = false;

            foreach (Producto item in listaProductos)
            {
                if (producto.GetCodigo() == item.GetCodigo())
                {
                    Type tipoProducto = producto.GetType();
                    if (tipoProducto.Name.Equals("Manufactura"))
                    {
                        Manufactura manufac = (Manufactura)producto;
                        //manufac.AumentarStock(cantidad);
                    }
                }
            }

            if (!existeProducto)
            {
                listaProductos.Add(producto);
            }
        }

        /* ES UN METODO INTERNO PARA AUMENTAR EL CAPITAL CUANDO VENDO A UN CLIENTE */
        private void Ganancias(float ganancias)
        {
            Console.WriteLine("Se ganaron $" + ganancias);
            this.capital += ganancias;
        }

        /* ES UN METODO INTERNO PARA DISMINUIR EL CAPITAL CUANDO COMPRO AL PROVEEDOR */
        private void Gastos(float gastos)
        {
            Console.WriteLine("Se gastaron $" + gastos);
            this.capital -= gastos;
        }

        /* COMPRO MATERIAL AL PROVEEDOR PARA FABRICAR PRODUCTO */
        public void ComprarAProveedor(Proveedor prov, MateriaPrima materia, int cantidad)
        {
            bool tieneMateriaProv = false;
            bool tengoMateria = false;

            /* REVISO QUE EL PROVEEDOR TENGA ESA MATERIA PRIMA PRIMERO */
            foreach (MateriaPrima item in prov.GetListaMateria())
            {
                if (materia.GetCodigo() == item.GetCodigo())
                {
                    tieneMateriaProv = true;
                }
            }

            if (tieneMateriaProv)
            {
                Gastos(materia.GetPrecio() * cantidad);
                /* REVISO MI LISTA DE MATERIA PRIMA PARA AGREGAR EN CASO DE QUE NO LA TENGA, Y SINO AUMENTAR
                 * LA CANTIDAD QUE TENGO, ESTO PARA NO GENERAR DUPLICADOS */
                foreach (MateriaPrima item in listaMateria)
                {
                    if (materia.GetCodigo() == item.GetCodigo())
                    {
                        item.AumentarCantidad(cantidad);
                        tengoMateria = true;
                    }
                }
            }

            //SI RECORRI TODO Y NO TENGO LA MATERIA LA AGREGO
            if (!tengoMateria)
            {
                MateriaPrima materiaMia = new MateriaPrima(materia.GetCodigo(), materia.GetNombre(), materia.GetPrecio());
                materiaMia.AumentarCantidad(cantidad);
                listaMateria.Add(materiaMia);
            }
        }

        /* LE VENDO PRODUCTOS A UN CLIENTE, PUEDE SER UN SERVICIO O MANUFACTURA */
        public void Vender(Cliente cliente, Producto producto, int cantidad, bool ivaDiscriminado)
        {
            Type tipoProducto = producto.GetType();
            float total;
            bool existeProducto = false;

            if (cliente.EstaHabilitado())
            {
                foreach (Producto item in listaProductos)
                {
                    if (producto.GetCodigo() == item.GetCodigo())
                    {
                        existeProducto = true;
                    }
                }

                if (existeProducto)
                {
                    if (tipoProducto.Name.Equals("Manufactura"))
                    {
                        Manufactura manufac = (Manufactura)producto;
                        if (manufac.HayStock(cantidad))
                        {
                            manufac.ReducirStock(cantidad);
                            total = cantidad * manufac.GetPrecio();
                            Ganancias(total);
                            if (ivaDiscriminado)
                            {
                                Factura factura = new Factura('A', cliente, total, cantidad);
                            }
                            else
                            {
                                Factura factura = new Factura('B', cliente, total, cantidad);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay stock del producto solicitado");
                        }
                    }
                    else
                    {
                        Servicio serv = (Servicio)producto;
                        total = cantidad * serv.GetPrecio();
                        Ganancias(total);
                        if (ivaDiscriminado)
                        {
                            Factura factura = new Factura('A', cliente, total, cantidad);
                        }
                        else
                        {

                            Factura factura = new Factura('B', cliente, total, cantidad);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No tenemos ese producto/servicio");
                }

            }
            else
            {
                Console.WriteLine("Cliente no esá habilitado");
            }

        }

        /* EN ESTE METODO PRODUZCO LA MANUFACTURA CON EL MATERIAL QUE TENGO */
        public void Producir(Manufactura manu)
        {
            bool puedoProducirlo = true;
            float totalGasto = 0;
            int cantMaterialesNecesarios = manu.GetListaMateria().Count;
            int cantAux = 0;

            Console.WriteLine("Vamos a producir " + manu.GetNombre() + " que necesita "+ cantMaterialesNecesarios + " materiales");
            /* VOY VERIFICANDO QUE TENGA LAS MATERIAS PRIMAS Y LA CANTIDAD COMO PARA PRODUCIR ESA MANUFACTURA */
            foreach (MateriaPrima itemNecesario in manu.GetListaMateria())
            {
                foreach (MateriaPrima itemTengo in this.listaMateria)
                {
                    if (itemTengo.GetCodigo() == itemNecesario.GetCodigo())
                    {
                        cantAux++;
                        if (itemTengo.GetCantidad() < itemNecesario.GetCantidad())
                        {
                            puedoProducirlo = false;
                            Console.WriteLine("Tengo " + itemTengo.GetCantidad() + " y necesito " + itemNecesario.GetCantidad());
                            Console.WriteLine("No tengo suficiente " + itemTengo.GetNombre() +" para producir el producto");
                        }
                    }
                }
            }

            if (cantAux == cantMaterialesNecesarios && puedoProducirlo)
            {
                foreach (MateriaPrima itemNecesario in manu.GetListaMateria())
                {
                    foreach (MateriaPrima itemTengo in this.listaMateria)
                    {
                        if (itemTengo.GetCodigo() == itemNecesario.GetCodigo())
                        {
                            itemTengo.DisminuirCantidad(itemNecesario.GetCantidad());
                            totalGasto += (itemNecesario.GetCantidad() * itemNecesario.GetPrecio());
                        }
                    }
                }

                Console.WriteLine("Hacer la manufactura " + manu.GetNombre() + " salio: $" + totalGasto);
            }


        }
    }
}

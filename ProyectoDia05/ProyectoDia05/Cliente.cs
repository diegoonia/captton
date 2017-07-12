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
    class Cliente
    {
        private string nombre, apellido;
        private int id;
        private bool habilitado;
        List<Factura> listaFacturas = new List<Factura>();

        public Cliente(string nombre, string apellido, int id)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.id = id;
            this.habilitado = false;
        }

        public void agregarFactura(Factura factura)
        {
            listaFacturas.Add(factura);
        }

        public void Habilitar()
        {
            this.habilitado = true;
        }

        public void Deshabilitar()
        {
            this.habilitado = false;
        }

        public bool EstaHabilitado()
        {
            return habilitado;
        }

        /* MUESTRO LA INFO DE TODAS LAS FACTURAS DEL CLIENTE */
        public void MostrarInfoFacturas()
        {
            foreach (Factura item in listaFacturas)
            {
                item.mostrarInfo();
            }
        }
    }
}

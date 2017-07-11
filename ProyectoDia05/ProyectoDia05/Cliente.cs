using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDia05
{
    class Cliente
    {
        private string nombre, apellido;
        private int id;
        private bool habilitado;
        List<Factura> listaFacturas;

        public Cliente(string nombre, string apellido, int id)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.id = id;
            this.habilitado = false;
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
    }
}

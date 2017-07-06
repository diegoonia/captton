using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioOpcional
{
    class Cliente
    {
        private int id;
        private string nombreYApellido;
        private int contadorCompras = 0;

        public Cliente(int id, string nombreYApellido)
        {
            this.id = id;
            this.nombreYApellido = nombreYApellido;
        }

        public string GetNombreYApellido()
        {
            return nombreYApellido;
        }

        public void SetNombreYApellido(string nombre)
        {
            this.nombreYApellido = nombre;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public bool EsHabitual()
        {
            return (contadorCompras >= 2);
        }

        public void ComproProducto()
        {
            contadorCompras++;
        }

        public int GetCantidadCompras()
        {
            return contadorCompras;
        }
    }
}

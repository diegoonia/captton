using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioOpcional
{
    class Producto
    {
        private int id;
        private string nombreProducto;
        private int stock;
        private float precio;

        public Producto(int id, string nombreProd, int stock, float precio)
        {
            this.id = id;
            this.nombreProducto = nombreProd;
            this.stock = stock;
            this.precio = precio;
        }

        public string GetNombreProducto()
        {
            return nombreProducto;
        }

        public int GetId()
        {
            return id;
        }

        public int GetStock()
        {
            return stock;
        }

        public float GetPrecio()
        {
            return precio;
        }

        public void SetStock(int stock)
        {
            this.stock = stock;
        }

        public void SeVendio()
        {
            this.stock--;
        }

        public void SeVendio(int cantidad)
        {
            this.stock -= cantidad;
        }
    }
}

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
    class MateriaPrima
    {
        private int codigo;
        private string nombre;
        private float precio;
        private int cantidad;

        public MateriaPrima(int codigo, string nombre, float precio)
        {
            this.precio = precio;
            this.codigo = codigo;
            this.nombre = nombre;
        }

        public int GetCodigo()
        {
            return codigo;
        }

        public void AumentarCantidad(int cantidad)
        {
            this.cantidad += cantidad;
        }
        
        public void DisminuirCantidad(int cantidad)
        {
            this.cantidad -= cantidad;
        }

        public int GetCantidad()
        {
            return this.cantidad;
        }

        public float GetPrecio()
        {
            return this.precio;
        }

        public string GetNombre()
        {
            return nombre;
        }
    }
}

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
    abstract class Producto
    {
        protected int codigo;
        protected string nombre;
        protected float precio;

        public Producto(int codigo, string nombre, float precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
        }

        public float GetPrecio()
        {
            return precio;
        }

        public int GetCodigo()
        {
            return codigo;
        }

        public string GetNombre()
        {
            return nombre;
        }
    }
}

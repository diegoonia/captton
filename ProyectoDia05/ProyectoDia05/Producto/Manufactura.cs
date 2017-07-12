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
    class Manufactura : Producto
    {
        private int stock;
        private List<MateriaPrima> listaMateria = new List<MateriaPrima>();

        public Manufactura(int codigo, string nombre, float precio, List<MateriaPrima> listaMateria)
            : base(codigo, nombre, precio)
        {
            this.listaMateria = listaMateria;
        }
        
        public bool HayStock(int cantidad)
        {
            return cantidad >= stock;
        }

        public void ReducirStock(int cantidad)
        {
            stock -= cantidad;
        }

        public List<MateriaPrima> GetListaMateria()
        {
            return listaMateria;
        }
    }
}

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
    class Proveedor
    {
        /* AL PROVEEDOR NO LE BAJO LA CANTIDAD DE MATERIA QUE TIENE, SIEMPRE TIENE */
        private string nombre;
        private List<MateriaPrima> listaMateriaPrima = new List<MateriaPrima>();

        public Proveedor(string nombre)
        {
            this.nombre = nombre;
        }

        public void AgregarMateriaPrima(MateriaPrima materia)
        {
            MateriaPrima materiaProv = new MateriaPrima(materia.GetCodigo(), materia.GetNombre(), materia.GetPrecio());
            listaMateriaPrima.Add(materiaProv);
        }

        public List<MateriaPrima> GetListaMateria()
        {
            return this.listaMateriaPrima;
        }
    }
}

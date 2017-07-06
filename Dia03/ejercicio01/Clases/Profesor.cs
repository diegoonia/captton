using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Profesor
    {
        private string nombre;
        private List<Curso> listaDeCursos = new List<Curso>();

        public Profesor(string nombre)
        {
            this.nombre = nombre;
           
        }

        public void AñadirCurso(Curso curso)
        {
            listaDeCursos.Add(curso);
        }

        public string GetNombre()
        {
            return nombre;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Universidad
    {
        List<Curso> listaDeCursos = new List<Curso>();
        List<Alumno> listaDeAlumnos = new List<Alumno>();
        private string nombre;

        public Universidad(string nombre)
        {
            this.nombre = nombre;
        }

        public void AñadirCurso(Curso curso)
        {
            listaDeCursos.Add(curso);
        }

        public void AñadirAlumno(Alumno alumno)
        {
            listaDeAlumnos.Add(alumno);
        }
        
        public string HablanCursos()
        {
            StringBuilder str = new StringBuilder();

            foreach (Curso item in listaDeCursos)
            {
                str.AppendLine(item.HablanAlumnos());
            }

            return str.ToString();
        }
    }
}

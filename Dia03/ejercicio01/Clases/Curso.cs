using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Curso
    {
        private string nombre;
        private int aula;
        private Profesor profesorTitular;
        private List<Alumno> listaDeAlumnos = new List<Alumno>();

        public Curso(string nombre, int aula, string nombreProfesor)
        {
            this.profesorTitular = new Profesor(nombreProfesor);
            this.nombre = nombre;
            this.aula = aula;
        }

        public void AñadirAlumno(Alumno alumno)
        {
            listaDeAlumnos.Add(alumno);
        }

        public string HablanAlumnos()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("En el curso: " + this.nombre);
            str.AppendLine(profesorTitular.GetNombre() + ": Soy el profesor titular");

            foreach (Alumno item in listaDeAlumnos)
            {
                str.AppendLine(item.HablaAlumno());
            }

            return str.ToString();
        }
    }
}

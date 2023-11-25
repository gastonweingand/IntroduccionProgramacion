using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerPrograma.POO
{
    public class Universidad
    {
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();
        
        public Universidad()
        {
            //Demo, la universidad por defecto me agrega el alumno jorge martinez...
            Alumno alumno = new Alumno();
            alumno.SetLegajo(777878);
            alumno.Nombre = "Jorge";
            alumno.Apellido = "Martinez";
            Alumnos.Add(alumno);
        }

        private void Demo()
        {
            Alumnos[0].Nombre = "pepito";
        }

        public void MostrarTodosLosAlumnos()
        {
            //Utilizando un foreach puedo recorrer toda mi lista
            foreach (var alumno in Alumnos)
            {
                Console.WriteLine($"Soy el alumno: {alumno.Nombre} {alumno.Apellido}");
            }

            for (int i = 0; i < Alumnos.Count; i++)
            {
                Console.WriteLine($"Soy el alumno: {Alumnos[i].Nombre} {Alumnos[i].Apellido}");
            }
        }
    }
}

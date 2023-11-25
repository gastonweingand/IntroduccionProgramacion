using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerPrograma.POO
{
    //public/internal:  Puede accederla cualquiera dentro de la solución, private, solamente se accede entro del proyecto 
    public class Alumno
    {
        //TEORÍA DEL ENCAPSULAMIENTO ME DICE QUE 
        //1)NUNCA DEBO DEJAR QUE MIS DATOS PRIVADOS SEAN ACCEDIDOS NI MODIFICADOS DIRECTAMENTE POR LOS CLIENTES
        //2)Los atributos deben quedar SIEMPRE private
        //3)Generar métodos para obtener o actualizar dichos atributos -> property
        //En otros lenguajes lo hacemos con get y set


        //Con atributos describo cuál es la identidad de mi Objeto/CLASE
        //Para los atributos o métodos los métodos de acceso private/public/protected
        public DateTime FechaNacimiento { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }


        //EJEMPLO COMPLETO DE TÉCNICA DEL ENCAPSULAMIENTO
        #region DEMO ENCAPSULAMIENTO
        private int legajo;

        public void SetLegajo(int legajo)
        {
            //    if (legajo.ToString().StartsWith("4"))
            //        this.legajo = legajo;
            //    else
            //        this.legajo = int.Parse(("4" + legajo.ToString());
            this.legajo = legajo;
        }

        public int GetLegajo()
        {
            return this.legajo;
        }
        #endregion

        //Métodos /Comportamiento

        //IMPLEMENTACIÓN - > ES EL CÓDIGO QUE ESTÁ DENTRO DE UNA CLASE

        /// <summary>
        /// Constructor por defecto (No recibe ningún argumento)
        /// </summary>
        public Alumno()
        {
            Console.WriteLine("Soy el constructor por defecto");
        }

        /// <summary>
        /// Constructor que pide todos los atributos de la clase Alumno
        /// </summary>
        /// <param name="fechaNacimiento">¿Cuándo nació?</param>
        /// <param name="nombre">¿Cómo se llama?</param>
        /// <param name="apellido"></param>
        /// <param name="legajo"></param>
        public Alumno(DateTime fechaNacimiento, string nombre, string apellido, int legajo) : this(fechaNacimiento, nombre, apellido)
        {
            //Recordar que this se utiliza para acceder a los mimebros propios...
            this.legajo = legajo;
        }

        public Alumno(DateTime fechaNacimiento, string nombre, string apellido)
        {
            this.FechaNacimiento = fechaNacimiento;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        //SOBRECARGA DE CONSTRUCTORES: ES tener la posibilidad de varias constructores 
        //dentro de una clase que reciben diferentes parámetros...

        public void RendirAsignatura()
        {
            Console.WriteLine($"Tengo el legajo {legajo} y estoy rindiendo una materia");
        }

        public void InscribirAsignatura()
        {
            Console.WriteLine("Me estoy anotando a una materia");
        }

        private void DarLeccion()
        {

        }

        //La clase Object (Que la acceso por código con la palabra reservada base
        //Nos provee de ciertas implementaciones básicos como ToString()
        //Que retorna el namespace + nombre de la clase
        //Con override y el nombre del método podemos personalizar esta funcionalidad
        public override string ToString()
        {

            return base.ToString() + $" {this.Nombre} {this.Apellido}";
        }

    }
}

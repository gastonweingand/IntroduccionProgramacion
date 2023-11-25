using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoClase4.DomainModel
{
    /// <summary>
    /// Clase que utilizo para conceptualizar un rectángulo...
    /// </summary>
    public class Rectangulo : FiguraGeometrica
    {
        public decimal Base { get; set; }

        public decimal Altura { get; set; }

        /// <summary>
        /// Calculamos el área desde el propio objeto rectangulo
        /// </summary>
        /// <returns>Retornamos el valor calculado...</returns>
        public override decimal CalcularArea() //Se utiliza la palabra override para implementar
            //aquellos métodos que se definieron como abstractos en nuestra clase base (FiguraGeometrica)
        {
            return Base * Altura;
        }

        public override decimal CalcularPerimetro()
        {
            return (Base * 2) + (Altura * 2);
        }

        //Constructor es también llamado método especial que se llama igual que la clase!
        //class Rectangulo -> public Rectangulo
        //Y no retorna ABSOLUTAMENTE NADA!!!
        public Rectangulo() : base(0,0)
        {
            Console.WriteLine("Estamos construyendo un rectángulo");
        }

        /// <summary>
        /// Constructor que recibe los argumentos de base y altura al momento de llamar al new
        /// </summary>
        /// <param name="rectanguloBase">Enviar la base en cm.</param>
        /// <param name="altura">Enviar la altura en cm.</param>
        public Rectangulo(decimal rectanguloBase, decimal altura, int posX = 0, int posY = 0): base(posX, posY)
        {
            Base = rectanguloBase;
            Altura = altura;
        }

        //Sobrecarga de constructores...

        public override string ToString()
        {
            return $"Soy un rectángulo con base {this.Base} y altura {this.Altura}, posición {base.ToString()}";
        }

        public override void OtroMetodo(string cadena)
        {
            Console.WriteLine($"Aprendiendo sobre clases abstractas {cadena}");
        }
    }
}

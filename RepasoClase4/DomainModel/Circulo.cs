using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoClase4.DomainModel
{
    public class Circulo : FiguraGeometrica
    {
        //public int posX { get; set; }

        //public int posY { get; set; }
        public decimal Radio { get; set; }

        /// <summary>
        /// En este constructor asignaríamos 0 y 0 a la posición de la figura
        /// </summary>
        /// <param name="radio"></param>
        public Circulo(decimal radio) : base(0,0)
        {
            Radio = radio;

            //base vs this

            //con base acceso SOLAMENTE los miembros de mi clase base
            //con this veo TODO!
        }

        /// <summary>
        /// Construyo un objeto Circulo con una posición diferente a 0,0
        /// </summary>
        /// <param name="radio"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public Circulo(decimal radio, int posX, int posY) : base(posX, posY)
        {
            Radio = radio;
        }

        public override string ToString()
        {
            return $"Soy un círculo con radio {this.Radio}, posición {base.ToString()}"; 
        }

        #region Métodos Implementados de clase base
        public override decimal CalcularArea()
        {
            return (decimal)(Math.PI * Math.Pow((double)this.Radio, 2));
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)(2 * Math.PI * (double)this.Radio);
        }

        public override void OtroMetodo(string cadena)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

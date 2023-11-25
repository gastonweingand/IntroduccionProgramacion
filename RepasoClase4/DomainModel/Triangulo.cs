using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoClase4.DomainModel
{
    /// <summary>
    /// Triángulo, Circulo y Rectángulo son clases concretas (Que pueden ser instanciadas)
    /// </summary>
    public class Triangulo : FiguraGeometrica
    {
        public float Lado1 { get; set; }

        public float Lado2 { get; set; }

        public float Lado3 { get; set; }

        public Triangulo(float lado1, float lado2, float lado3, int posX, int posY) : base(posX, posY)
        {
            Lado1 = lado1;
            Lado2 = lado2;
            Lado3 = lado3;
        }

        public override decimal CalcularArea()
        {
            return 0;
        }

        public override decimal CalcularPerimetro()
        {
            return 0;
        }

        public override void OtroMetodo(string cadena)
        {
            throw new NotImplementedException();
        }
    }
}

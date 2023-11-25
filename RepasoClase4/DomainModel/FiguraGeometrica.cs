using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoClase4.DomainModel
{
    /// <summary>
    /// Figura geométrica será una clase abstracta
    /// Es una clase base (Padre) que no puede ser instanciada
    /// Puede contener métodos implementados: Ej -> MostrarPosicion() que sería util para cualquier hijo
    /// Contiene al menos 1 método abstracto: Que los hijos, están obligados a implementar
    /// esa funcionalidad...
    /// Puede contener atributos, propiedades...
    /// </summary>
    public abstract class FiguraGeometrica
    {
        public int posX { get; set; }

        public int posY { get; set; }

        public FiguraGeometrica(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        //La visibilidad de tipo protegida sirve para compartir miembros entre clases padre/hijas
        protected int valor = 9;

        /// <summary>
        /// Método implementado en nuestra clase base (Abstract) que puede ser utilizado directamente...
        /// </summary>
        public void MostrarPosicion()
        {
            Console.WriteLine($"Posición X: {posX}, Y: {posY}");
        }

        public override string ToString()
        {
            return $"X: {posX}, Y: {posY}";
        }

        //Estos métodos necesitan CONCRETAMENTE conocer que tipo de figura geométrica soy: Circulo, triángulo, etc...
        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();

        public abstract void OtroMetodo(string cadena);
        

        //ESTO LO DEJO EN STANDBY PARA ENTENDER LO QUE ES UNA CLASE ABSTRACTA
        // EN EL PRÓXIMO CAPÍTULO...
    }
}

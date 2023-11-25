using RepasoClase4.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoClase4
{

    class Program
    {
        private static void DibujarEnPantalla(FiguraGeometrica figura)
        {
            Console.WriteLine("Para dibujar no me importa qué tipo de figura sos");
            Console.WriteLine("Solo necesito tu X y tu Y");
            figura.MostrarPosicion();
        }

        static void Main(string[] args)
        {
            //DEMO COMPOSICIÓN VS AGREGACIÓN
            //En la composición estoy obligado a enviar las instancias de las listas
            //pertinentes, de lo contrario, un curso no puede existir!!!
            List<Profesor> listaProfesores = new List<Profesor>();

            Curso curso = new Curso(listaProfesores, new List<Alumno>());

            Console.WriteLine("El programa seguirá con su curso natural...");

            Console.WriteLine("Y en algún momento, le asocio un aula");

            curso.Aula = new Aula(); //AGREGACIÓN, en el tiempo asignaré un aula...



            Circulo circulo = new Circulo(5);
            Console.WriteLine(circulo);

            Circulo circuloConPosicion = new Circulo(5, 10, 10);
            Console.WriteLine(circuloConPosicion);

            //Se declara la clase abstracta y se instancia SIEMPRE una concreta
            FiguraGeometrica figura = new Rectangulo(0, 0);
            figura.posY = 90;
            figura.posX = 10;
            Console.WriteLine(figura);

            figura = circuloConPosicion;

            DibujarEnPantalla(figura);

            //circuloConPosicion = (Circulo)figura;
            decimal radio = (figura as Circulo).Radio;

            FiguraGeometrica circulo2 = new Circulo(6, 5, 8);
            FiguraGeometrica rectangulo = new Rectangulo(6, 2, 3, 11);
            FiguraGeometrica rectangulo2 = new Rectangulo(10, 12, 10, 20);

            Triangulo triangulo = new Triangulo(1, 2, 3, 56, 78);

            List<FiguraGeometrica> figuras = new List<FiguraGeometrica>();
            figuras.Add(circulo2);
            figuras.Add(rectangulo);
            figuras.Add(rectangulo2);
            figuras.Add(triangulo);

            foreach (var item in figuras)
            {
                //Reflection -> Programación avanzada -> Conocer el ADN de nuestros objetos en tiempo de ejecución
                Console.WriteLine("Conociendo que estoy accediendo a un objeto de tipo: ");
                Console.WriteLine(item.GetType().FullName);
                Console.WriteLine(item.GetType().Name);
                           
                //Otra forma de conocer si un objeto es instancia de un tipo X (Tipo Circulo)

                //if(item is Circulo)
                //{
                //    Circulo obj = (Circulo)item; //Tengo que hacer downCasting para poder acceder al miembro concreto
                //    obj.Radio = 50;
                //    //Este objeto es concretamente un objeto de tipo Circulo
                //    Console.WriteLine($"Mostrando el radio del círculo {obj.Radio}");
                //}

                if (item.GetType().Name == "Circulo")
                {
                    Circulo obj = (Circulo)item; //Tengo que hacer downCasting para poder acceder al miembro concreto
                    obj.Radio = 50;
                    //Este objeto es concretamente un objeto de tipo Circulo
                    Console.WriteLine($"Mostrando el radio del círculo {obj.Radio}");
                }
                else if (item.GetType().Name == "Rectangulo")
                {
                    //Este objeto es concretamente un objeto de tipo Circulo
                    Console.WriteLine((item as Rectangulo).Altura);
                }

                Console.WriteLine("Calculo de área " + item.CalcularArea());
                Console.WriteLine("Calculo de perímetro " + item.CalcularPerimetro());
                Console.WriteLine(item);
            }

            Console.WriteLine($"Conociendo el nuevo radio del círculo {(circulo2 as Circulo).Radio}");

            int salir = 0;
            do
            {
                //Hay una clase llamada Rectangulo (Mayúscula)
                //La palabra rectangulo es un objeto de tipo Rectangulo
                //También podemos decir que rectangulo es una instancia de Rectangulo
                //new -> Aloca el objeto en una posición de memoria -> Se llama al método CONSTRUCTOR!!!

                decimal area, perimetro;
                //ConstruirRectanguloConstructorDefecto(out area, out perimetro);

                ConstruirRectanguloConstructorSobrecargado(out area, out perimetro);

                Console.WriteLine($"El perímetro es {perimetro} cm y el área es {area} cm");

                Console.WriteLine("Ingrese un número distinto de cero para continuar. 0 para finalizar.");
                salir = int.Parse(Console.ReadLine());

            } while (salir != 0);


            //RepasoEstructurado();
        }

        private static void ConstruirRectanguloConstructorDefecto(out decimal area, out decimal perimetro)
        {
            Rectangulo rectangulo = new Rectangulo();

            Console.WriteLine("Por favor ingrese la base del rectángulo");
            rectangulo.Base = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingrese la altura del rectángulo");
            rectangulo.Altura = decimal.Parse(Console.ReadLine());

            //Le pedimos servicio al objeto rectángulo para que nos calcule el área y el perímetro
            area = rectangulo.CalcularArea();
            perimetro = rectangulo.CalcularPerimetro();
        }

        private static void ConstruirRectanguloConstructorSobrecargado(out decimal area, out decimal perimetro)
        {

            Console.WriteLine("Por favor ingrese la base del rectángulo");
            decimal @base = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingrese la altura del rectángulo");
            decimal altura = decimal.Parse(Console.ReadLine());

            Rectangulo rectangulo = new Rectangulo(@base, altura); //Al momento de construir envío los argumentos...

            //Le pedimos servicio al objeto rectángulo para que nos calcule el área y el perímetro
            area = rectangulo.CalcularArea();
            perimetro = rectangulo.CalcularPerimetro();
        }

        private static void RepasoEstructurado()
        {
            //Ingresar los sueldos y nombres de 30 empleados, indicar e imprimir el sueldomayor y a quién pertenece

            //EXACTOS -> for (tamaño) for (iterador) -> for each
            //NO EXACTOS -> while / do while

            decimal sueldo = 0;
            decimal sueldoMayor = 0;
            string empleado = String.Empty;
            string empleadoMayor = String.Empty;

            const int maximo = 5;

            for (int contador = 0; contador < maximo; contador++)
            {
                //Console.WriteLine($"Pasando por el contador nro {contador + 1}");

                Console.WriteLine($"Por favor ingrese el nombre del empleado nro {contador + 1 }");
                empleado = Console.ReadLine();

                sueldo = ObtenerSueldo(sueldo, empleado);

                if (sueldo > sueldoMayor)
                {
                    //El sueldo actual es mayor al que existía previamente...
                    sueldoMayor = sueldo;
                    empleadoMayor = empleado;
                }
            }

            Console.WriteLine($"El empleado con mayor sueldo es {empleadoMayor} y tiene un sueldo de $ {sueldoMayor}");

            Console.WriteLine("Presione una tecla para finalizar");
            Console.Read();
            //Console.WriteLine("Presione enter para finalizar");
            //Console.ReadLine();
        }

        private static decimal ObtenerSueldo(decimal sueldo, string empleado)
        {
            do
            {
                Console.WriteLine($"Por favor ingrese el sueldo del empleado {empleado}, siendo mayor a 0.");

                //Acá validamos una regla de usabilidad (El usuario ingresa un dato no válido)
                if (decimal.TryParse(Console.ReadLine(), out decimal sueldoSalida))
                {
                    sueldo = sueldoSalida;
                }

                //Acá validamos una regla del negocio (NINGÚN SUELDO ES MENOR O IGUAL A $0)
                if (sueldo <= 0)
                    Console.WriteLine("El valor ingresado para el sueldo es inválido");

            } while (sueldo <= 0);


            //while (true) //bucle infinito for(;;)
            //{
            //    Console.WriteLine($"Por favor ingrese el sueldo del empleado {empleado}, siendo mayor a 0.");

            //    //Acá validamos una regla de usabilidad (El usuario ingresa un dato no válido)
            //    if (decimal.TryParse(Console.ReadLine(), out decimal sueldoSalida))
            //    {
            //        sueldo = sueldoSalida;
            //    }

            //    if (sueldo <= 0)
            //        Console.WriteLine("El valor ingresado para el sueldo es inválido");
            //    else
            //        break; //Este break corte el bucle de manera abrupta (NO SE RECOMIENDA EN ABSOLUTO)
            //}

            return sueldo;
        }
    }
}

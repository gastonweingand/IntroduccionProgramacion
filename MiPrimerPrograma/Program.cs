using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MiPrimerPrograma.POO;
using DAO;

namespace MiPrimerPrograma
{
    class Program
    {
        //1) Método que no recibe argumentos y retorna void

        /// <summary>
        /// Método que no recibe argumentos y retorna void
        /// </summary>
        static void HolaMundo()
        {
            Console.WriteLine("Hola mundo, bienvenidos al mundo de los métodos en C#");
            Console.WriteLine("Saliendo del método en cuestión");
        }

        //2) Método que retorna ALGO y no recibe argumentos

        /// <summary>
        /// Método que retorna el año actual
        /// </summary>
        /// <returns>Año actual</returns>
        static int ObtenerAñoActual()
        {
            return DateTime.Now.Year;
        }

        //PARA ACORDARSE: SOBRECARGA DE MÉTODOS ES CUANDO UN MÉTODO SE LLAMA IGUAL, PERO 
        //RECIBE DIFERENTE CANTIDAD DE ARGUMENTOS
        //3) Método que recibe argumentos y no retorna nada (Procedimiento, action, Accesso, Excel, Word : sub (vb 6.0))
        /// <summary>
        /// Método que recibe argumentos para sumarlos y mostrarlos por pantalla
        /// </summary>
        /// <param name="a">Número decimal</param>
        /// <param name="b">Número decimal</param>
        /// <param name="c">Número decimal</param
        static void SumarMostrar(decimal a, decimal b, decimal c)
        {
            decimal total = a + b + c;
            Console.WriteLine($"La suma de {a} + {b} + {c} es {total}");
        }

        /// <summary>
        /// Método que recibe argumentos para sumarlos y mostrarlos por pantalla
        /// </summary>
        /// <param name="a">Número decimal</param>
        /// <param name="b">Número decimal</param>
        static void SumarMostrar(decimal a, decimal b)
        {
            decimal total = a + b;
            Console.WriteLine($"La suma de {a} + {b} es {total}");
        }

        //4) Método que retorna algo y recibe argumentos
        static int CalcularEdad(DateTime fechaNacimiento)
        {
            //Pensar cómo calcular bien la edad de una persona...
            //Buscar la técnica para calcular la edad contemplando años biciestos...

            //Probar este método
            double edad = ((DateTime.Now - fechaNacimiento).TotalDays) / 365;

            //Otra opción (Muy mala)
            int años = DateTime.Now.Year - fechaNacimiento.Year;

            return (int)edad;

        }


        /// <summary>
        /// Main es la función principal de un programa de tipo CONSOLA
        /// </summary>
        /// <param name="args">Son los argumentos que recibo desde línea de comandos...</param>
        static void Main(string[] args)
        {

            FileTxtWriter fileTxtWriter = new FileTxtWriter();
            fileTxtWriter.EscribirNoticia(@"d:\demo04112023.txt", "Cualquier noticia...");





            Universidad universidad = new Universidad();
            universidad.Alumnos.Add(new Alumno(DateTime.Now, "Alumno X", "Nombre Y"));
            universidad.MostrarTodosLosAlumnos();

            //Declaro un objeto fernanda de tipo Alumno (fernanda pertenece a la clase Alumno)
            Alumno fernanda;

            //Esta línea de código crea REALMENTE UN OBJETO EN MEMORIA!!! fernanda
            //tiene una dirección de memoria con su propio ESTADO!!!
            fernanda = new Alumno(new DateTime(1978,4,15), "Fernanda", "Sanchez");

            fernanda.SetLegajo(9999);
            fernanda.Nombre = "Otro nombre";

            Console.WriteLine(fernanda.Nombre);

            Console.WriteLine($"Obteniendo el legajo de {fernanda}: {fernanda.GetLegajo()} Código HASH: {fernanda.GetHashCode()}");
            
            //fernanda.Nombre = "Fernanda";
            //fernanda.Apellido = "Sanchez";

            fernanda.RendirAsignatura();
            fernanda.InscribirAsignatura();
            
            //En este caso estoy declarando la variable objeto de tipo Alumno y la instancio
            Alumno andres = new Alumno(new DateTime(2000, 1, 10), "Andrés", "Mendoza", 1111);
            //andres.Nombre = "Andrés";
            //andres.Apellido = "Mendoza";


            //if(andres.Nombre == fernanda.Nombre && andres.Apellido == fernanda.Apellido)
            //{
            //    Console.WriteLine("En principio parece que ambos objetos son iguales");
            //}

            //Al ser objetos diferentes, esto se invalida
            if(andres == fernanda)            
                Console.WriteLine("¿Qué pasa realmente acá?");            
            else
                Console.WriteLine("Son diferentes");

            List<Alumno> alumnos = new List<Alumno>();

            for (int i = 0; i < 30; i++)
            {
                Alumno alumno = new Alumno();
                //alumno.Legajo = i;
                //alumno.fechaNacimiento = DateTime.Now.AddYears(-18 - i);
                alumno.RendirAsignatura();
                alumnos.Add(alumno);
            }

            foreach (var alumno in alumnos)
            {
                //Console.WriteLine($"Mostrando el alumno con legajo: {alumno.Legajo}");
                alumno.InscribirAsignatura();
            }


            //new SmtpServer("from", "to", "Subject", "Body").Send(); //Objeto de un solo uso...
            






            //Cargar 10 números en un vector, calcularle a cada uno la potencia 2 y mostrar el resultado por pantalla
            const int cantidadElementos = 10;

            int[] numeros = new int[cantidadElementos];
            int[] numerosConPotencia = new int[cantidadElementos];

            //int numeroIngresado = 0;

            //Si aprendí lo que es un ciclo exacto, por qué no lo utilizo?

            CargarVector(cantidadElementos, numeros);

            //Hacemos el cálculo de las potencias

            CalcularCuadrados(cantidadElementos, numeros, numerosConPotencia);

            //Mostramos por pantalla la salida lo más linda posible
            MostrarPorPantalla(cantidadElementos, numeros, numerosConPotencia);

            int[] otroVector = new int[1000];
            CargarVector(1000, otroVector);

            int[] otroVector2 = new int[5];
            CargarVector(5, otroVector);




            //Funciones -> C, MÉTODOS EN C#
            //Action -> Procedimientos -> Función que retorna void (nada)
            //Function -> Funciones -> Función que retorna algo (int, double, decimal, string, CUALQUIER ELEMENTO)

            Console.ReadLine();





            //Ciclos/Bucles -> EXACTOS E INEXACTOS
            //Exactos (for)

            //El requerimiento nos especifica una n cantidad de elementos a recorrer/iterar

            //Mostrar por pantalla los primeros 100 números pares, comenzando por el 0

            //VARIABLES DE TIPO CONTADOR
            //i++ -> i = i + 1
            //i-- -> i = i - 1;

            //VARIABLES DE TIPO ACUMULADOR
            //total += x -> total = total + x;
            //total *= x -> total = total * x;

            //Ejercicio10Bucles();

            //Metodos();

            //CiclosInexactos();

            //CiclosExactos();

            //EjercicioConSwitch();

            //Ejercicio4();

            //Ejercicio3();

            //Ejercicio1();

            //Ejercicio2();

            //Esto lo hacemos, para que el programita no se nos cierre...
            Console.WriteLine("Presione una tecla para finalizar");
            Console.Read();
        }

        private static void MostrarPorPantalla(int cantidadElementos, int[] numeros, int[] numerosConPotencia)
        {
            for (int i = 0; i < cantidadElementos; i++)
            {
                Console.WriteLine($"La potencia al cuadrado del nro {numeros[i]} es {numerosConPotencia[i]}");
            }
        }

        private static void CalcularCuadrados(int cantidadElementos, int[] numeros, int[] numerosConPotencia)
        {
            for (int i = 0; i < cantidadElementos; i++)
            {
                numerosConPotencia[i] = numeros[i] * numeros[i];
            }
        }

        private static void CargarVector(int cantidadElementos, int[] numeros)
        {
            for (int indice = 0; indice < cantidadElementos; indice++)
            {
                Console.WriteLine("Por favor ingrese un número para conocer más tarde su potencia al cuadrado");

                //Opción 1 con una variable de tipo aux
                //numeroIngresado = int.Parse(Console.ReadLine());
                //numeros[indice] = numeroIngresado;

                //Opción 2, leo directamente al vector
                numeros[indice] = int.Parse(Console.ReadLine());
            }
        }

        private static void Ejercicio10Bucles()
        {
            //Ingresar la patente y monto de la multa de 5 autos, 
            //indicar e imprimir cuántos montos superan los $ 40 y del total 
            //cobrado que porcentaje representa la suma de los que superan los $40


            //VARIABLES
            decimal monto = 0;
            decimal total = 0;
            decimal contadorMontosSuperior40 = 0;
            decimal acumuladorMontosSuperior40 = 0;
            decimal porcentajeSuperiores40 = 0;

            //DATOS ENTRADA
            for (int contador = 1; contador <= 5; contador++)
            {
                Console.WriteLine($"Por favor ingrese el monto de la multa para el vehículo {contador}");
                monto = decimal.Parse(Console.ReadLine());

                if (monto > 40)
                {
                    contadorMontosSuperior40++; //VARIABLE CONTADOR
                    acumuladorMontosSuperior40 += monto; //VARIABLE ACUMULADOR PARCIAL DE LOS > 40
                }

                total += monto; //VARIABLE ACUMULADOR TOTAL
            }

            //PROCESO
            porcentajeSuperiores40 = (acumuladorMontosSuperior40 * 100) / total;

            //DATOS SALIDA

            Console.WriteLine($"El total de los montos superiores a $40 es {contadorMontosSuperior40}");
            Console.WriteLine($"El total en % de los montos superior a $40 es de {porcentajeSuperiores40.ToString("0.00")} %");
        }

        private static void Metodos()
        {
            for (int i = 0; i < 1000; i++)
            {
                HolaMundo();
            }

            int año = ObtenerAñoActual();
            Console.WriteLine($"El año actual es {año}");

            SumarMostrar(67, 89);

            SumarMostrar(13, 98, 156);

            int edad = CalcularEdad(new DateTime(1984, 8, 13));

            Console.WriteLine($"El profe tiene {edad} años");
        }

        private static void CiclosInexactos()
        {
            //Ciclos inexactos
            //while / do-while . Ejecuto un ciclo hasta una condición de parada.
            //Ingresar alumnos con nombre, legajo y las notas de los trimestres y calcular los promedios de cada alumno
            //Los legajos son nros entre 1000 y 50000

            //do-while a diferencia de while EJECUTA AL MENOS UNA VEZ UN BLOQUE DE CÓDIGO

            int legajo = ObtenerLegajo();

            while (legajo > 0)
            {
                //Tengo que solicitar el resto de los datos y calcular los promedios...
                Console.WriteLine("Ingrese el nombre del alumno");

                //Todo lo que haría con cada alumno...(Secuencial/condicionales)

                legajo = ObtenerLegajo();
            }
        }

        private static int ObtenerLegajo()
        {
            //Esta variable legajo existe solo para la función ObtenerLegajo
            int legajo;
            do
            {
                Console.WriteLine("Ingrese el legajo del alumno o 0 o un nro negativo para finalizar");
                legajo = int.Parse(Console.ReadLine());

                if (legajo < 1000 || legajo > 50000)
                    Console.WriteLine("Legajo inválido, vuelva a ingresar");

            } while (legajo < 1000 || legajo > 50000);
            return legajo;
        }

        private static void CiclosExactos()
        {
            int total = 0;
            //(DESDE; HASTA; INCREMENTO)
            for (int i = 100; i > 0; i--)
            {
                //% módulo -> resto de la división
                if (i % 2 == 0)
                {
                    //Este es un número par
                    Console.WriteLine("Este es un nro par " + i);
                }
                else
                {
                    //Este no es un número par
                }

                Console.WriteLine($"Mostrando el nro {i}");
                total += i;
            }

            for (int i = 2; i < 500; i = i + 2)
            {
                Console.WriteLine($"{i} es un número par");
            }

            Console.WriteLine($"El total de los nros anteriores es {total}");
        }

        private static void EjercicioConSwitch()
        {
            //Condicionales -> Clásico y querido if/else if/else
            //En algunos lenguajes como C#, C, C++, Java -> switch/case

            //Utilizar switch case cuando se tienen valores etiquetados/nomenclados

            //Se ingresa un empleado, su sueldo y su categoria, calcular el sueldo total
            //sabiendo que categoria1, incrementa el sueldo en $15.000
            //y categoria2, incrementa el sueldo en $40.0000

            int categoriaIngresada = 0;
            int sueldoTotal = 0;
            int sueldo = 0;

            Console.WriteLine("Ingrese por favor la categoría del empleado: 1) Jefe, 2,3,4) Empleado base");

            categoriaIngresada = int.Parse(Console.ReadLine());

            CategoriaEnum categoria = (CategoriaEnum)categoriaIngresada;

            switch (categoria)
            {
                case CategoriaEnum.JEFE:
                    sueldoTotal = sueldo + 15000;
                    break;
                case CategoriaEnum.EMPLEADO:
                case CategoriaEnum.GERENTE:
                case CategoriaEnum.PRESIDENTE:
                    sueldoTotal = sueldo + 40000;
                    break;
                case CategoriaEnum.TRANSPORTISTA:
                    Console.WriteLine("Agregamos la categoría transportista");
                    break;
                default:
                    Console.WriteLine("Usted ingresó una categoría inválida");
                    break;
            }
        }

        private static void Ejercicio4()
        {
            //Ejercicio nro 4 - CONDICIONALES
            //Ingresar dos valores y realizar e imprimir la resta del mayor menos el menor
            //Si ambos son iguales, solicitar nuevamente el ingreso hasta que uno sea diferente...

            int nro1 = 0;
            int nro2 = 0;
            int resta = 0;

            Console.WriteLine("Por favor ingrese un nro");
            nro1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Por favor ingrese otro nro");
            nro2 = int.Parse(Console.ReadLine());

            if (nro1 > nro2) //? true or false
            {
                //Condicional evalúa una expresión por la verdad
                resta = nro1 - nro2;
                //Interpolación de cadenas o strings
                Console.WriteLine($"El nro mayor es {nro1} y la resta con {nro2} es {resta}");
                //Console.WriteLine("El nro mayor es " + nro1 + " y la resta con " + nro1);
            }
            else if (nro2 > nro1)
            {
                //Condicional evalúa una expresión por la verdad
                resta = nro2 - nro1;
                //Interpolación de cadenas o strings
                Console.WriteLine($"El nro mayor es {nro2} y la resta con {nro1} es {resta}");
                //Console.WriteLine("El nro mayor es " + nro1 + " y la resta con " + nro1);
            }
            else
            {
                //¿Qué pasa si ambos son iguales?
                //throw new NotImplementedException("No se definió que hacemos cuándo ambos son iguales");
                Console.WriteLine("Ambos son iguales");
            }
        }

        private static void Ejercicio3()
        {
            //Ejercicio 3
            int a, b = 0;

            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            int total = a + b;

            Console.WriteLine($"La suma es de {a} + {b} es {total}");
        }

        private static void Ejercicio2()
        {
            //CONDICIONALES
            //Escribir un software que solicite la edad al usuario y le diga
            //si es mayor de edad o no
            //Si es menor, decir si es un bebe o no...

            int edad = 0;

            Console.WriteLine("Por favor ingrese su edad");
            edad = int.Parse(Console.ReadLine());

            if (edad >= 18)
                Console.WriteLine("Usted es mayor de edad");
            else if (edad <= 2)
            {
                Console.WriteLine("Usted es un baby");
                Console.WriteLine("Estoy dentro de la condicional de edad");
            }
            else
                Console.WriteLine("Usted es un menor");

            //Operadores lógicos... Ejemplo: Tercera edad: 60-80 años
            //&& = Y -> CONJUNCIÓN
            //|| = O -> DISYUNCIÓN
            //! = NEGAR

            if (edad >= 60)
            {
                if (edad <= 80)
                {

                }
            }

            if ((edad >= 60 && edad <= 80))
            {
                //Para que acá sea cierto, ambas condiciones deben ser verdaderas....
            }

            //Tabla de verdad de ||
        }

        private static void Ejercicio1()
        {
            //Desde acá vamos a empezar a escribir nuestro código...
            //() {} ; "" = == !=
            //snippets -> Ej: cw
            //Definición de variable de tipo string (Cadena)
            string nombreApellido;

            Console.WriteLine("Bienvenidos al mundo del c#");
            Console.WriteLine("Por favor ingrese su nombre y apellido");

            nombreApellido = Console.ReadLine();

            //Retrasar la ejecución de la siguiente intrucción
            Thread.Sleep(5000);

            //Concatenar cadenas: Es como sumar en matemática pero texto
            Console.WriteLine("Usted se llama " + nombreApellido);

            /*Dado el valor de la hora y la cantidad de horas trabajadas por un 
              empleado, calcular su sueldo*/

            //RECETA PARA ARMAR ESTOS EJERCICIOS INICIALES
            //1) PENSAR QUÉ VARIABLES NECESITO?
            //2) ESCRIBIR LO QUE NECESITO SOLICITARLE AL USUARIO
            //3) PROCESAR LOS DATOS
            //4) MOSTRAR LO CALCULADO, REPORTES, ETC....

            //1)
            decimal valorHora = 0;
            decimal cantidadHoras = 0;
            decimal sueldoTotal = 0;

            //2)
            Console.WriteLine("Por favor ingrese el valor de la hora en $");
            //Lo que ocurre es que ReadLine retorna un string y yo necesito un decimal
            valorHora = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingrese la cantidad de horas trabajadas");
            //Lo que ocurre es que ReadLine retorna un string y yo necesito un decimal
            cantidadHoras = decimal.Parse(Console.ReadLine());

            //3)
            sueldoTotal = valorHora * cantidadHoras;

            //4)
            Console.WriteLine("El sueldo total calculado es de $" + sueldoTotal);

            sueldoTotal = 1000;
        }
    }
}

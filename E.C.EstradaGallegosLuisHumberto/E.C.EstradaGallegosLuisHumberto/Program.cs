using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace E.C.EstradaGallegosLuisHumberto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables necesarias
            int opcion = 0;
            string valor = "";
            int numero = 0;
            bool encontrado = false;
            string b = null;
            var numer= b;
            // Creamos el stack
            Stack miPila = new Stack();
            do
            {
                // Mostramos menu
                Console.WriteLine("\n1- Push");
                Console.WriteLine("2- Pop");
                Console.WriteLine("3- Clear");
                Console.WriteLine("4- Contains");
                Console.WriteLine("5- GetType");
                Console.WriteLine("6- ToString");
                Console.WriteLine("7- ToSArray");
                Console.WriteLine("8- Getenumerator");
                Console.WriteLine("9- Salir");
                Console.WriteLine("Dame tu opcion");
                valor = Console.ReadLine();
                opcion = Convert.ToInt32(valor);
                switch (opcion)
                {
                    case 1:
                        // Pedimos el valor a introducir
                        Console.WriteLine("Dame el valor a introducir");
                        valor = Console.ReadLine();
                        numero = Convert.ToInt32(valor);
                        // Adicionamos el valor en el stack
                        miPila.Push(numero);
                        break;
                    case 2:
                        // Obtnemos el elemento
                        numero = (int)miPila.Pop();
                        // Mostramos el elemento
                        Console.WriteLine("El valor obtenido es: {0}", numero);
                        break;
                    case 3:
                        // Limpiamos todos los contenidos del stack
                        miPila.Clear();
                        break;
                    case 4:
                        // Pedimos el valor a encontrar
                        Console.WriteLine("Dame el valor a encontrar");
                        valor = Console.ReadLine();
                        numero = Convert.ToInt32(valor);
                        // Vemos si el elemento esta
                        encontrado = miPila.Contains(numero);
                        // Mostramos el resultado
                        Console.WriteLine("Encontrado - {0}", encontrado);
                        break; 
                    case 5: // Se utiliza el gettype
                        if (miPila.GetType() == typeof(Stack))
                            Console.WriteLine("Si comprueba");
                        break;
                    case 6://Se utiliza el tostring
                        Console.WriteLine("El objeto seleccionado es: " + miPila.ToString());
                        break;
                    case 7: // Se utiliza el toarray
                        Console.WriteLine("El elemento en el arreglo es: " + miPila.ToArray().ElementAt(0));
                        break;

                    case 8: // se utiliza el GetEnumerator
                        IEnumerator ej = miPila.GetEnumerator();
                        while (ej.MoveNext())
                        {
                            Object objeto = ej.Current;
                            Console.WriteLine("El enumerador de la pila es: " + objeto);
                        }
                        break;

                    default:
                        Console.WriteLine("No existe opción intente de nuevo");
                        break;
                }
                // Mostramos la informacion del stack
                Console.WriteLine("La pila tiene {0} elementos", miPila.Count);
                foreach (int n in miPila)
                    Console.Write("El elemento es: {0}", n);

            } while (opcion != 9);
        }
    }
    
}

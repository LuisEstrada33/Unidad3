using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroClases;

            Console.Write("Cuantas clases va a ingresar: "); //Ingresa y guarda la cantidad de clases
            numeroClases = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Calificaciones proceso = new Calificaciones(); //Se crea un objeto

            proceso.Capturar(numeroClases); //Se manda a llamar al Metodo

            Console.ReadKey();
        }
    }
}

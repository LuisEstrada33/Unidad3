using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3_EstradaGallegosLuisHumberto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; //Se puede poner unicode
            BlackJack Procesos = new BlackJack();           //POO
            string opcion = "BJ";                       //Opcion BJ por default
            int victorias = 0;                         //Victorias
            int derrotas = 0;                          //Derrotas
            int juegos = 0;                            //Cuenta cuantos juegos se han jugado
            string opcion2 = "0";                     //Opcion2 para estadisticas

            do
            {
              
                    Console.Clear();
                    Console.Write("*******Blackjack*****");
                    Console.Write("\n1)Jugar\n2)Ver estadisticas\nTu Opcion: ");  //Menu
                    opcion2 = Console.ReadLine();
                    if (opcion2 == "1") //Opcion para Correr el juego
                    {
                        Console.Clear();
                        Procesos.Jugar(ref victorias, ref derrotas, ref juegos);
                        Console.Write("\n\n¿Desea volver a jugar? (BJ/N)\n");
                        opcion = Console.ReadLine().ToUpper();
                    }
                    else if (opcion2 == "2") //Opcion para desplegar las estadisticas 
                    {
                        Console.Clear();
                        Console.Write("♠♥♦♣ Juegos: {0} ♠♥♦♣\n♠♥♦♣ Victorias: {1} ♠♥♦♣\n♠♥♦♣Derrotas: {2} ♠♥♦♣\n\n", juegos, victorias, derrotas);
                        Console.Write("\n\n¿Desea jugar? (BJ/N)\n");
                        opcion = Console.ReadLine().ToUpper();
                    }
  
                

                
            } while (opcion == "BJ");
            Console.Clear(); //Limpia la consola cuando ya no desea jugar
            Console.Write("Sus estadisticas fueron: \n\nJuegos: {0} \nVictorias: {1}\nDerrotas: {2} \n\n", juegos, victorias, derrotas);
            //Despliega las estadisticas antes de salir.
            Console.ReadKey();
        }
    }
}
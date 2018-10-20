using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3_EstradaGallegosLuisHumberto

{
    class BlackJack
    {
        //Se crean las variables del blackjack
        ArrayList aux = new ArrayList(); //Lista auxiliar para poder quitar una carta de la pila
        Stack cartas = new Stack();           //Pila donde se guarda la baraja
        Random random = new Random();           //Variable para generar los numeros random
        Stack mano = new Stack();             //Pila donde se almacena la mano de cartas
        object carta;                         
        int indice = 0;                       
        int total = 0;                       
        int aces = 0;                           
        int Rondas = 0;                       

        //Metodo para barajar
        private void Barajar()
        {
            
            mano.Clear();
            cartas.Clear();
            Rondas = 0;
            //Ciclo para las cartas del 1-11
            for (int contador = 1; contador < 11; contador++)
            {
                cartas.Push("♠-" + contador.ToString());
                cartas.Push("♥-" + contador.ToString());
                cartas.Push("♦-" + contador.ToString());
                cartas.Push("♣-" + contador.ToString());
            }
            cartas.Push("♠-J");
            cartas.Push("♥-J");
            cartas.Push("♦-J");
            cartas.Push("♣-J");
            cartas.Push("♠-Q");
            cartas.Push("♥-Q");
            cartas.Push("♦-Q");
            cartas.Push("♣-Q");
            cartas.Push("♠-K");
            cartas.Push("♥-K");
            cartas.Push("♦-K");
            cartas.Push("♣-K");
        }
        //Metodo para jugar
        //Parametros:
        //Victorias
        //derrotas
        //juegos

        public void Jugar(ref int victorias, ref int derrotas, ref int juegos)
        {
            //Cada vez que se inicia una partida se limpia la mano
            Barajar();
            //Se roban dos cartas al inicio del juego.
            RobarCarta();
            RobarCarta();
            //Despliega la mano
            Desplegarmano();
            //Compara si se obtuvo un 21 al iniciar
            Comparar();
            Console.Write("Total: {0}\n\n", total); //Escribe el total del robo inicial.
            if (total == 21)
            {
                //Si obtuvo 21 se gana el juego
                Console.Write("Has ganado");
                victorias++;
            }
            else
            { //Si no obtuvo 21 vuelve a robar una carta de la baraja
                do
                {
                    RobarCarta();
                    Desplegarmano(); //Roba, despliega y compara el numero nuevamente.
                    Comparar();
                    Console.Write("Total: {0}\n\n", total); //Despliega el total.
                } while ((mano.Count < 5) && (total <= 20)); //Si la mano llega a 5 cartas o el total pasa de 20 se sale del ciclo

                if (total > 21)   // si pasa de 21 se pierde el juego, se despliega el mensaje de derrota y se suma el contador de derrotas.
                {
                    Console.Write("Has perdido");
                    derrotas++;
                }
                else            //si no paso de 21 significa que gano el juego, despliega el mensaje de victoria y suma el contador de victorias.
                {
                    Console.Write("Has ganado");
                    victorias++;
                }
                juegos++; //Se suma el contador de juegos jugados cuando ya se acabo la sesion.
            }
        }
        //Metodo para sacar una carta
        private void RobarCarta()
        {
            aux.Clear(); 
            indice = random.Next(0, cartas.Count); //Saca un carta al azar de la pila
            carta = cartas.ToArray().ElementAt(indice); //Se asigna la carta con el indice obtenido
            mano.Push(carta); //Se agrega a la pila de la mano la carta obtenida

            for (int contador = cartas.Count; contador > 0; contador--)
            {
                aux.Add(cartas.Pop());  //Se utiliza pop para sacar los elentos
            }
            aux.Remove(carta); //Se remueve la carta auxiliar
            foreach (object objeto in aux)
            {
                cartas.Push(objeto); 
            }
        }
        //Metodo para poder tener la suma de las cartas
        private void Comparar()
        {
            string[] valor = new string[3]; //arreglo de string
            total = 0; //La suma total se convierte a 0
            foreach (object objeto in mano) //foreach para hacer los ciclos 
            {
                valor = objeto.ToString().Split('-'); //Separar el numero con el simbolo

                if (int.TryParse(valor[1], out int res)) 
                {                                     
                    if ((Convert.ToInt32(valor[1]) >= 2) && (Convert.ToInt32(valor[1]) <= 10)) //Si el valor obtenido del split esta entre 2 y 10
                    {
                        total = total + Convert.ToInt32(valor[1]); //el total simplemente se suma con el numero que tenga
                    }
                    else
                    {
                        aces = aces + 1;  //si es az entonces se guarda en un contador para los aces que sera usado mas adelante
                    }
                }
                else
                {
                    total = total + 10; //si no era un valor numerico el valor obtenido significa que puede ser un J,Q o K y siempre valen 10
                }
            }

            for ( aces = aces; aces > 0; aces--) //Por cada az dentro de la mano realizara este ciclo
            {
                if ((total + 11) > 21)          //Si el az hace que la mano pase de 21  si vale 11
                {
                    total = total + 1;        //El az vale 1
                }
                else                         
                {
                    total = total + 11;       //EL az vale 11
                }
            }
        }
        //Metodo para desplegar la mano
        private void Desplegarmano()
        {
            Rondas++;                       //Se suma 1 al round
            Console.Write("Tu mano en round {0}:\n", Rondas);      
            foreach (object objeto in mano)
            {
                Console.Write(objeto.ToString() + "\n");         
            }
        }

    }
}
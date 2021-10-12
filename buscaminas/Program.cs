using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*¿Has jugado alguna vez buscaminas? Este pequeño y lindo juego viene con cierto
 * sistema operativo cuyo nombre no podemos nombrar ahora ;). La meta del juego es encontrar
 * dónde están localizadas todas las minas dentro de un campo de M x N cuadros. El juego muestra
 * un número en un cuadro el cual te dice cuántas minas hay en los cuadros adyacentes a ese cuadro. 
 * Cada cuadro tiene a lo sumo ocho cuadros adyacentes. La representación del campo de 4 x 4 en la
 * izquierda contiene dos minas, cada una representada por un asterisco (*). Si representamos
 * el mismo campo con los números que indican la cantidad de minas adyacentes, obtendríamos los valores
 * a la derecha:*/


/* Entrada
La entrada consistirá en un número arbitrario de campos.
La primera línea de cada campo contiene dos enteros n y m 
(0 <n,m<= 100) que indica el número de filas y columnas del campo, respectivamente.
Cada una de las filas n siguiente contiene exactamente m caracteres, representando el campo.
Los cuadros seguros están denotados por “.” y los cuadros con minas por “*”, ambas sin las comillas. 
La primera línea de entrada donde n = m = 0 representa el final de la entrada y no debe ser procesada.

Salida
Para cada campo, imprime el mensaje Field#x: en una línea sola, 
donde x indica el número del campo iniciando por 1. 
Las n líneas siguientes deben contener el campo con los caracteres “.” 
Reemplazados por el número de minas adyacente a ese cuadro. 
Debe haber una línea en blanco entre las salidas de cada campo.

Ejemplo
El siguiente es un ejemplo de entradas y la respectiva salida esperada*/


namespace buscaminas
{
 
    class Program
    {
        // BARIABLES GLOVALES-------------------------
        static int VACIO = 0;
        static int MINA = 2;
        static void Main(string[] args)
        {
            // MIS BARIABLES------------------------------------
            
            

            const int NUMERO_MINAS = 3;
            const int TURNOS_SIN_PISAR = 5;


            // -------MATRIZ SI SE MUESTRA LA MINAS---------------------
            //-----------MATRIZ DEL TABLERO---------------------------------------
            bool[,] posicionesMostrar = new bool[4,4];
            int[,] tablero = new int[4,4];

            bool minaPisadas = false;
            int turnosSinPisarMinas = 0;


            //---------------AÑADIR LAS MINAS----------------------------------
            int n = 0;
            Random r = new Random();
            //------------PARA QUE LAS MINAS NO SE ME REPITAN------------------------------
            while (n < NUMERO_MINAS)
            {
                int filaUno = r.Next(0, tablero.GetLength(0));
                int columnaUno = r.Next(0, tablero.GetLength(1));
                if (tablero[filaUno,columnaUno] == VACIO)
                {
                    tablero[filaUno, columnaUno] = MINA;
                    n++;
                }

            }


            //------FUNCION SI NO PISO NINGUNA MINA PUEDO SEGUIR AVANZANDO--------
            
            while(!minaPisadas && turnosSinPisarMinas <= TURNOS_SIN_PISAR)
            {
                //Console.WriteLine("Inserta una Fila");
                mostarTablero(posicionesMostrar, tablero);

                Console.WriteLine("Inserta una Fila");
                int fila = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Inserta una Columna");
                int columna = Convert.ToInt32(Console.ReadLine());

                if (tablero[fila,columna] == MINA)
                {
                    Console.WriteLine("Has pisado una mina");
                    minaPisadas = true;
                    posicionesMostrar[fila, columna] = true;
                }
                else if (posicionesMostrar[fila,columna])
                {
                    Console.WriteLine("Ya has pasado por esta celda");
                }
                else
                {
                    Console.WriteLine("Te has librado, esta vez...");

                    turnosSinPisarMinas++;
                    posicionesMostrar[fila,columna] = true;
                }

            }
            // PROCESO DE ESCOJER LAS CASILLAS SI SIGO AVANZANDO  O PIERDO 
            

            if (minaPisadas)
            {
                Console.WriteLine("Has pisado una MINA");
                Console.WriteLine("LLEGO TU FINAL");
            }
            else
            {
                Console.WriteLine("HAS GANADO");

            }
            mostarTablero(posicionesMostrar, tablero);

            Console.ReadLine();
          
        } 
        // ESTOY RELLENANDO MI MATRIS
        public static void mostarTablero(bool[,]posicionesMostar,int[,] tablero)
        {
            for(int i = 0; i < posicionesMostar.GetLength(0); i++)
            {
                for (int j = 0; j < posicionesMostar.GetLength(1); j++)
                {
                    if (posicionesMostar[i,j])
                    {
                        if (tablero[i,j] == VACIO)
                        {
                            Console.Write("V "); // CASILLA VASIDA
                        }
                        else
                        {
                            Console.Write("* ");// CASILLA CON MINA
                        }
                        
                    }
                    else
                    {
                        Console.Write(". ");// CASILLA PARA EXPLORAR 
                    }
                }
                Console.WriteLine("");
            }
            //Console.ReadKey();
        }

    }
}

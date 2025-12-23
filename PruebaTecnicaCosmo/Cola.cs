using System;
using System.Collections.Generic;
using System.Threading;

namespace PruebaTecnicaCosmo
{
    public class Cola
    {


        public static void ProcesoCola()
        {
            //Instancia de la cola de personas a atender
            Queue<string> cola = new Queue<string>();

            //Con esta manejamos la condición para terminar el ciclo
            int contador = 0;
            
            //1.Llega alguien, 2.Se atiende 3.No pasa nada
            int accionAzar = 0;

            //Personas
            string[] personas = { "Ana", "Luis", "Sara", "Alejandro", "Sofía" };
            
            int personaAzar = 0;

            string usuariosEnCola = "";

            //Generar eventos aleatorios
            var random = new Random();
            do
            {
                //Se decide la acción
                accionAzar = random.Next(0, 3);

                switch (accionAzar)
                {
                    case 0:
                        if (cola.Count < 4)
                        {
                            personaAzar = random.Next(0, 5);
                            cola.Enqueue(personas[personaAzar]);
                            General.Imprimir("Llega usuario " + personas[personaAzar] + " a la fila");
                        }
                        else
                        {
                            General.Imprimir("Cola llena, espere que se vacíe un campo");
                        }

                        break;
                    case 1:
                        if (cola.Count != 0)
                        {
                            General.Imprimir("Se está atendiendo a " + cola.Peek());
                            cola.Dequeue();
                        }
                        else
                        {
                            General.Imprimir("La cola está vacía, no hay nadie por atender");
                        }
                        break;
                    case 2:
                        General.Imprimir("No hay novedades");
                        break;
                }

                //Retroalimentación de la cola con los usuarios
                if (cola.Count != 0)
                {
                    usuariosEnCola = "";
                    foreach (string persona in cola)
                    {
                        usuariosEnCola += persona + "->";
                    }
                    General.Imprimir("Cola actual: " + usuariosEnCola);
                }

                //Cada iteración esperamos 1,4 segundos para simular algo más real
                Thread.Sleep(1400);
                contador++;

            } while (contador < 16);
        }

    }
}

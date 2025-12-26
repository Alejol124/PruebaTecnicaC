using System;
using System.Collections.Generic;

namespace PruebaTecnicaCosmo
{
    public class Grafo
    {

        public static List<(string from, string to)> edges = new List<(string, string)>
        {
            ("A", "B"),
            ("B", "C"),
            ("C", "D")
        };

        public static Dictionary<string, List<string>> grafo = new Dictionary<string, List<string>>();


        public static void LlenarGrafo()
        {
            foreach (var edge in edges)
            {
                string origen = edge.from;
                string destino = edge.to;

                //Si el nodo de origen no existe, lo creo
                if (!grafo.ContainsKey(origen))
                {
                    grafo[origen] = new List<string>();
                }

                //Se agrega el destino a la lista de origen
                grafo[origen].Add(destino);


                //Aseguro que el nodo destino exista aunque no tenga salidas
                if (!grafo.ContainsKey(destino))
                {
                    grafo[destino] = new List<string>();
                }
            }
        }

        public static bool IsReachable()
        {
            string origen = General.Leer("Ingrese el punto de partida");
            string destino = General.Leer("Ingrese el destino");

            if (!grafo.ContainsKey(origen) || !grafo.ContainsKey(destino))
            {
                Console.WriteLine("No es alcanzable");
                return false;
            }

            Queue<string> cola = new Queue<string>();
            HashSet<string> visitados = new HashSet<string>();

            cola.Enqueue(origen);
            visitados.Add(origen);

            while(cola.Count > 0)
            {
                string actual = cola.Dequeue();

                //Si se llega al destino
                if (actual == destino)
                {
                    General.Imprimir("Es alcanzable");
                    return true;
                }

                //Recorremos los vecinos
                foreach (string vecino in grafo[actual])
                {
                    if (!visitados.Contains(vecino))
                    {
                        visitados.Add(vecino);
                        cola.Enqueue(vecino);
                    }
                }
            }

            //No hubo camino
            return false;
        }

    }
}

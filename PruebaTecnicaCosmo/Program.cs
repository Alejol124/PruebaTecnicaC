using System;

namespace PruebaTecnicaCosmo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                op = Int32.Parse(General.Leer("Seleccione el ejercicio a probar:\n" +
                    "1.Grafos(Alcanzabilidad)\n" +
                    "2.Cola(FIFO)\n" +
                    "3.Pila(LIFO)\n" +
                    "4.Filtrado y Limpieza de datos\n" +
                    "0. Salir"));
                switch (op)
                {
                    case 1:

                        break;
                    case 2:
                        Cola.ProcesoCola();
                        break;
                    case 3:
                        General.Imprimir(Pila.IsBalanced().ToString());
                        break;
                    default:
                        General.Imprimir("Ingrese una opcción válida");
                        break;
                }
            } while (op != 0);
        }
    }
}

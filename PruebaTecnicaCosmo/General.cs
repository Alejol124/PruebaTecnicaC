using System;

namespace PruebaTecnicaCosmo
{
    public class General
    {
        public static void Imprimir(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public static string Leer(string mensaje)
        {
            string dato = "";
            Imprimir(mensaje);
            dato = Console.ReadLine();
            return dato;
        }
    }
}

using System;
using System.Collections.Generic;

namespace PruebaTecnicaCosmo
{
    public class Pila
    {

        public static bool IsBalanced()
        {
            Stack<string> pila = new Stack<string>();
            string expresion = General.Leer("Ingrese la expresión que desea balancear");
            char[] expresionSeparada = expresion.ToCharArray();

            foreach (char c in expresionSeparada)
            {
                //Si es un simbolo que abre lo apilo
                if (c.Equals('(') || c.Equals('[') || c.Equals('{'))
                {
                    pila.Push(c.ToString());
                }
                else if(c.Equals(')') || c.Equals(']') || c.Equals('}'))
                {
                    if (pila.Count == 0)
                    {
                        return false;
                    }

                    if (c.ToString() == ")" && pila.Peek() == "(" ||
                        c.ToString() == "]" && pila.Peek() == "[" ||
                        c.ToString() == "}" && pila.Peek() == "{")
                    {
                        pila.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (pila.Count == 0)
            {
                return true;
            }
            return false;
        }

    }
}

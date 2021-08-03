using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCsharp
{
    class Persona
    {
        public string nombre;
        public int edad;

        public void saludar()
        {
            Console.WriteLine("Hola mi nombre es: " + nombre + " y mi edad es: " + edad);
        }
    }
}

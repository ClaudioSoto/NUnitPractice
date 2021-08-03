using System;

namespace CursoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            char letra = 'a';
            string nombre = "claudio soto";
            float b = 3.1416f;
            Boolean isWorking = false;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(letra);
            Console.WriteLine(nombre);
            Console.WriteLine(isWorking);

            //casting
            int c = (int)b;

            string s = "110";
            int i = Convert.ToInt32(s);
            int j = int.Parse(s);

            Console.WriteLine(i);
            Console.WriteLine(j);

            //clases
            Persona claudio = new Persona();
            claudio.nombre = "Claudio Soto";
            claudio.edad = 24;
            claudio.saludar();

            //arrays
            int[] arreglo = new int[10];
        
        }
    }
}

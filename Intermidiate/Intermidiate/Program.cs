using System;

namespace Intermidiate
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona();
            p.Nombre = "Claudio Soto";
            p.Saludar();

            Persona p2 = new Persona("Claudio Ayala");
            p2.Saludar();

            Persona p3 = new Persona("Luis",1);
            p3.Hijos.Add(new Hijo());
            p3.Hijos.Add(new Hijo());
            Console.WriteLine(p3.Hijos.Count);

            //encapsulamiento con metodos tradicionales de set y get
            /*
            p.SetTrabajo("ISC");
            Console.WriteLine(p.GetTrabajo());
            */

            //forma nmueva para hacer gets y sets
            p.Trabajo = "sofia";
            Console.WriteLine(p.Trabajo);

            //propiedades autoimplementadas 
            Hijo hijo1 = new Hijo();
            hijo1.nombre = "claudio soto";
            hijo1.edad = 24;



            Console.WriteLine("Nombre: {0}  Edad: {1}", hijo1.nombre, hijo1.edad);

            //herencia
            Automovil bmw = new Automovil("alamadre");
            bmw.Arrancar();
            bmw.Frenar();
            bmw.TipoVehiculo();

            //upcasting and downcasting

            //ejemplo de upcasting
            Text text = new Text();
            Shape shape = text;

        }
    }
}

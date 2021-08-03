using System;
using System.Collections.Generic;
using System.Text;

namespace Intermidiate
{
    public class Automovil : Vehiculo
    {
        //si se requiere usar parametros de la clase padre en el constructor hijo y es dependiente la clase padre
        public Automovil(string placas)
            : base(placas)
        {
            Console.WriteLine("Automovil inicializado con placas {0}",placas);
        }

        public void Arrancar()
        {
            Console.WriteLine("El automovil esta en marcha");
        }

        public void Frenar()
        {
            Console.WriteLine("El automovil esta frenando");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Intermidiate
{
    public class Vehiculo
    {
        public string Tipo { set; get; }
        public string Motor { set; get; }
        private string _placas;

        public Vehiculo(string placas)
        {
            Console.WriteLine("Vehiculo inicializado con placas {0}",placas);
            this._placas = placas;
        }

        public void TipoVehiculo()
        {
            Console.WriteLine("Puede ser aereo, tesrestre o maritimo");
        }

        


    }
    
}

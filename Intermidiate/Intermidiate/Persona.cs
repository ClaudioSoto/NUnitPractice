using System;
using System.Collections.Generic;
using System.Text;

namespace Intermidiate
{
    class Persona
    {
        public string Nombre;
        public int Edad;
        public List<Hijo> Hijos;
        private  string _trabajo;
        //se puede declarar directamente en la clase para no tener que inicializarlo en constructor
        //public List<Hijo> Hijos = new List<Hijo>();

        //para hacer set y get modernos para el campo _trabajo
        public string Trabajo
        {
            set
            {
                _trabajo = value;
            }
            get
            {
                return _trabajo;
            }
        }

        public Persona()
        {
            //constructor default
            Hijos = new List<Hijo>();
        }


        public Persona(string nombre)
            :this()//para llamar primero al contructor default
        {
            this.Nombre = nombre;
        }

        public Persona(string nombre, int edad)
            :this(nombre)//para llamar al constructor que solo pide el nombre
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        /* METODOS TRADICIONALES DE SETS Y GETTS
        public void SetTrabajo(string trabajo)
        {
            this._trabajo = trabajo;

        }

        public string  GetTrabajo()
        {
            return this._trabajo;
        }
        */

        public void Saludar()
        {
            Console.WriteLine("Hola mi nombre es : " + this.Nombre);
        }
    }
}

using EjerciciosClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    //Clase que hereda de Persona para poder tener sus atributos, añadiendo la materia del profesor.
    internal class Profesor : Persona
    {
        public string materia { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {materia}";
        }

    }
}

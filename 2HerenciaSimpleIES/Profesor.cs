using EjerciciosClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    //Clase que hereda de Persona para poder tener sus atributos, añadiendo la materia del profesor.
    public abstract class Profesor : Persona
    {
        public string materia { get; set; }

        public Profesor(string nombre, string apellido, int edad) : base(nombre, apellido, edad)
        {
        }

        public enum TipoFuncionario : uint
        {
            Interino = 1,
            EnPracticas = 2,
            DeCarrera = 3
        }
        public TipoFuncionario TipoProfesor { get; set; }

        public string ToStringProfesor()
        {
            return $"{base.ToString()} {materia} {TipoProfesor}";
        }

        public abstract string toString { get; }
    }
}

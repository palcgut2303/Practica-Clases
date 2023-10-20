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

        public enum TipoFuncionario : uint
        {
            //Tienen asignados los valores de constante por defecto
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

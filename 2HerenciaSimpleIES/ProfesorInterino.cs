﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    public class ProfesorInterino : Profesor
    {
        public ProfesorInterino(string nombre, string apellidos, int edad)
        : base(nombre, apellidos, edad)
        {
            
        }
        //CONSTRUCTOR QUE HEREDA DE LA CLASE BASE.
        public ProfesorInterino(string nombre, string apellidos, int edad, string materia, TipoFuncionario tipoProfesor)
        : base(nombre, apellidos, edad)
        {
            base.materia = materia;
            TipoProfesor = tipoProfesor;
        }
        public override string toString => ToStringProfesor();


    }
}

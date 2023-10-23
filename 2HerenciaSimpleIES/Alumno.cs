using EjerciciosClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EjerciciosClases.Persona;
namespace _2HerenciaSimpleIES
{

    //Clase que hereda de Persona y obtiene sus atributos añadiendo el numero de expediente.
    internal class Alumno : Persona
    {
        public int numeroExpediente { get; set; }

        public Alumno()
        {

        }

        //CONSTRUCTORES HEREDANDO DE LA CLASE BASE, Y SU ATRIBUTO PROPIO
        public Alumno(string nombre, string apellido, int edad, int numeroExpediente) : base(nombre, apellido, edad)
        {

            this.numeroExpediente = numeroExpediente;

        }

        //METODO ToSTRING.
        public override string ToString()
        {
            return $"{base.ToString()} {numeroExpediente}";
        }

        //METODO QUE TE GENERA EL CORREO ELECTRONICO
        public override string GenerarCorreoElectronico(string nombre, string apellidos)
        {
            return "a" + base.GenerarCorreoElectronico(nombre, apellidos);
        }
        
        
    }
}

using _2HerenciaSimpleIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosClases
{
    public class Persona
    {   
        //Creamos atributos para la clase persona con sus get, y set.

        public string nombre { get; set; }

        public int edad { get; set; }

        public string apellidos { get; set; }

        public string email { get; set;}

        public Persona() { 
        
        }

        //CONSTRUCTOR.
        public Persona(string nombre, string apellidos , int edad)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.email = GenerarCorreoElectronico(nombre,apellidos);
        }

        //Sobrecarga de operadores
        public static bool operator  > (Persona p1,Persona p2) => p1.edad > p2.edad ? true : false;

        public static bool operator < (Persona p1, Persona p2) => p1.edad < p2.edad ? true : false;


        //Metodo para generar el correo electronico.
        public virtual string GenerarCorreoElectronico(string nombre, string apellidos)
        {
            string primerasDosLetrasApellido2 = "";

            // Dividir la cadena de apellidos en dos partes
            string[] partesApellidos = apellidos.Split(' ');

            // Tomar las primeras dos letras del primer apellido (o la primera letra si es nulo)
            string primerasDosLetrasApellido1 = (partesApellidos.Length > 0 && partesApellidos[0].Length >= 2) ? partesApellidos[0].Substring(0, 2).ToLower() : (partesApellidos.Length > 0 ? partesApellidos[0].Substring(0, 1).ToLower() : "");

            // Tomar las primeras dos letras del segundo apellido (o la primera letra si es nulo)
            if (partesApellidos[1] != "")
            {
                 primerasDosLetrasApellido2 = (partesApellidos.Length > 1 && partesApellidos[1].Length >= 2) ? partesApellidos[1].Substring(0, 2).ToLower() : (partesApellidos.Length > 1 ? partesApellidos[1].Substring(0, 1).ToLower() : "");
            }
            
            // Tomar la primera letra del nombre
            string primeraLetraNombre = (nombre != null && nombre.Length > 0) ? nombre.Substring(0, 1).ToLower() : "";

            // Combinar las partes para formar el correo electrónico
            if(partesApellidos[1] != "") 
            {
                return primerasDosLetrasApellido1 + primerasDosLetrasApellido2 + primeraLetraNombre + "@trass.com";
            }
            else //si introduce un solo apellido.
            {
                return  primerasDosLetrasApellido1  + primerasDosLetrasApellido1 + primeraLetraNombre + "23@trass.com";
            }
            
            
            
        }

        

        
        //Metodo para comprobar si existe la misma persona.

        public static bool Equals(string nombre, string apellido)
        {
            return MetodosStatic.MisPersonas.Any(persona =>
                string.Equals(nombre, persona.nombre, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(apellido, persona.apellidos, StringComparison.OrdinalIgnoreCase)
            );
        }


        public string toString()
        {
            return nombre + " " + apellidos + " " + edad + " " + email;
        }  

    }
}

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

       
        //Metodo para comprobar edad de la persona.
        public bool comprobarEdad(int edad)
        {
           
            if (edad > 0 && edad <= 120)
            {
                return  true;
            }
            return false;
        }

        

        
        //Metodo para generar el correo electronico.
        public string GenerarCorreoElectronico(string nombre, string apellidos)
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
                return primerasDosLetrasApellido1 + primerasDosLetrasApellido2 + primeraLetraNombre + "@iestrassierra.com";
            }
            else //si introduce un solo apellido.
            {
                return  primerasDosLetrasApellido1  + primeraLetraNombre + "@iestrassierra.com";
            }
            
            
            
        }

        //Metodo para convertir las cadenas de texto nombre y apellidos, en priimera letra mayuscula de cada palabra,
        public string convertirCadena(ref string nombre, string apellidos)
        {
            string[] nombreSeparados = nombre.Split(" ");
            string cadenaNombre = "";
            string apellido2 = "";
            string apellido1 = "";
            for (int i = 0; i < nombreSeparados.Length; i++)
            {

                cadenaNombre += nombreSeparados[i].Substring(0, 1).ToUpper() + nombreSeparados[i].Substring(1).ToLower();
            }



            string[] partesApellidos = apellidos.Split(' ');

            if (partesApellidos.Length >= 2)
            {
                // Convierte la primera letra de cada apellido en mayúscula y las demás en minúscula
                apellido1 = partesApellidos[0].Substring(0, 1).ToUpper() + partesApellidos[0].Substring(1).ToLower();
                apellido2 = partesApellidos[1].Substring(0, 1).ToUpper() + partesApellidos[1].Substring(1).ToLower();


            }
            else
            {
                apellido1 = partesApellidos[0].Substring(0, 1).ToUpper() + partesApellidos[0].Substring(1).ToLower();
            }


            return cadenaNombre + " " + apellido1 + " " + apellido2;
        }

      public string toString()
        {
            return nombre + " " + apellidos + " " + edad + " " + email;
        }  

    }
}

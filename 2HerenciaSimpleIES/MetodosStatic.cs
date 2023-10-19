using EjerciciosClases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    public static class MetodosStatic
    {
        static List<Persona> misPersonas = new List<Persona>(); //Array de personas donde las añadiremos.
        public static List<Persona> MisPersonas
        {
            get { return misPersonas; }
            set { misPersonas = value; }
        }

        //Metodos para que no haya ningun problema cuando introduzcas espacios innecesarios.
        public static string eliminarEspaciosApellidos(string apellidos)
        {

            // Eliminar espacios en blanco al principio y al final
            apellidos = apellidos.Trim();

            //Utilizamos una expresion regular que busca una o mas ocurrencias de los espacios en blancos.
            apellidos = Regex.Replace(apellidos, @"\s+", " ");



            return apellidos;
        }

        public static string eliminarEspaciosNombre(string nombre)
        {


            nombre = nombre.Trim();

            nombre = Regex.Replace(nombre, @"\s+", " ");



            return nombre;
        }

        //Metodo para saber si es la misma persona.
        public static bool Equals(string nombre, string apellido)
        {
            string[] apellidoSeparado = apellido.Split(" ");
            foreach (Persona persona in misPersonas)
            {
                string[] apellidoSeparado2 = persona.apellidos.Split(" ");

                if (nombre.ToLower() == persona.nombre.ToLower())
                {
                    if (apellidoSeparado[0].ToLower() == apellidoSeparado2[0].ToLower())
                    {
                        if (apellidoSeparado[1].ToLower() == apellidoSeparado2[1].ToLower())
                        {
                            return true;
                        }
                    }

                }


            }
            return false;

        }

        //Metodo para introducir datos y comprobar que se introducen bien sin ningun fallo.
        public static void comprobarDatos(ref string nombre, ref string apellido, ref int edad)
        {
            Persona miPersona = new Persona();
            bool nombreTrue;
            bool apellidoTrue;
            bool profesionTrue;
            bool esEdad;
            do
            {
                Console.WriteLine("Nombre: ");
                nombre = Console.ReadLine().Trim();
                int numericValue;
                nombreTrue = int.TryParse(nombre, out numericValue); ;

            } while (nombreTrue || nombre == " " || nombre == "");

            do
            {
                Console.WriteLine("Apellidos: ");
                apellido = Console.ReadLine();
                int numericValue;
                apellidoTrue = int.TryParse(apellido, out numericValue); ;

            } while (apellidoTrue || apellido == " " || apellido == "");


            do
            {

                Console.WriteLine("EDAD (ENTRE 0-120):");

                esEdad = int.TryParse(Console.ReadLine(), out edad);

            } while (!esEdad || !miPersona.comprobarEdad(edad));




        }

    }
}

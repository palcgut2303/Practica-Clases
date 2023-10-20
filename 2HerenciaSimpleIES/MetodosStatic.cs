﻿using EjerciciosClases;
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
                nombre = eliminarEspaciosNombre(nombre);
            } while (nombreTrue || nombre == " " || nombre == "");

            do
            {
                Console.WriteLine("Apellidos: ");
                apellido = Console.ReadLine();
                int numericValue;
                apellidoTrue = int.TryParse(apellido, out numericValue); ;
                apellido = eliminarEspaciosApellidos(apellido);
            } while (apellidoTrue || apellido == " " || apellido == "");


            do
            {

                Console.WriteLine("EDAD (ENTRE 0-120):");

                esEdad = int.TryParse(Console.ReadLine(), out edad);

            } while (!esEdad || !comprobarEdad(edad));




        }

        //Metodo para convertir las cadenas de texto nombre y apellidos, en priimera letra mayuscula de cada palabra,
        public static string convertirCadena(ref string nombre, string apellidos)
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

        //Metodo para comprobar edad de la persona.
        public static bool comprobarEdad(int edad)
        {

            if (edad > 0 && edad <= 120)
            {
                return true;
            }
            return false;
        }


    }
}

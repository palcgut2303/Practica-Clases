using EjerciciosClases;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static _2HerenciaSimpleIES.Profesor;

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

        static int i = 1;

        static _2HerenciaSimple main = new _2HerenciaSimple();

        //Metodos para que no haya ningun problema cuando introduzcas espacios innecesarios.
        public static string eliminarEspaciosApellidos(string apellidos)
        {

            // Eliminar espacios en blanco al principio y al final
            apellidos = apellidos.Trim();

            //Utilizamos una expresion regular que busca una o mas ocurrencias de los espacios en blancos.
            apellidos = Regex.Replace(apellidos, @"\s+", " ");



            return apellidos;
        }

        //METODO QUE ELIMINA LOS ESPACIOS INNECESARIOS DE LA CADENA, CON UNA EXPRESION REGULAR.
        public static string eliminarEspaciosNombre(string nombre)
        {


            nombre = nombre.Trim();

            nombre = Regex.Replace(nombre, @"\s+", " ");



            return nombre;
        }


        //Metodo para introducir datos y comprobar que se introducen bien sin ningun fallo.
        public static void comprobarDatos(ref string nombre, ref string apellido, ref int edad)
        {
            bool nombreTrue;
            bool apellidoTrue;
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
        public static string convertirCadena(ref string nombre,ref string apellidos)
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

        public static int WordCount(this string entrada)
        {
            // Dividimos la cadena en palabras utilizando los espacios como separadores
            string[] palabras = entrada.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //Metodo del Split que elimina las subcadenas vacias.
            return palabras.Length;
        }

        public static string FirstLetterToUpper(this string entrada)
        {
            if (string.IsNullOrEmpty(entrada)) //Si es nula devolvemos la cadena que nos ha introducida.
            {
                return entrada;
            }
            
            //Convertimos la primera cadena de la frase con el substring y el toUpper, el resto en minuscula.
            string primeraLetra = entrada.Substring(0, 1).ToUpper();
            string cadena = entrada.Substring(1).ToLower();

            return primeraLetra + cadena;
        }

        //METODO QUE BORRA PERSONAS, INTRODUCIENDO POR PARAMETRO NOMBRE, APELLIDO, EDAD
        public static bool SeekRemoved(this string nombre,string apellidos,int edad)
        {
            foreach(var objecto in MisPersonas){
                if(objecto.nombre == nombre && objecto.apellidos == apellidos && objecto.edad == edad) //SI COINCIDEN TODOS LOS PARAMETROS, ELIMINA DE LA LISTA.
                {
                  MisPersonas.Remove(objecto);
                  return true;
                }
            }
            return false;



        }

        //OPCION 1 AÑADIR PERSONAS
        public static void añadirPersonas()
        {
            string miNombre = "";
            string misApellidos = "";
            string miEmail;
            int miEdad = 0;
            string respuesta;
            int profesion = 0;
            

            do
            {

                Persona persona = new Persona();

                Console.WriteLine("---PERSONA {0}---", i);
                MetodosStatic.comprobarDatos(ref miNombre, ref misApellidos, ref miEdad);
                string datos = MetodosStatic.convertirCadena(ref miNombre,ref misApellidos);
                string[] misDatos = datos.Split(' ');

                if (MetodosStatic.MisPersonas.Count >= 1 && Persona.Equals(miNombre, misApellidos)) //UTILIZAMOS EL METODO EQUALS PARA VER SI YA HAY UNA PERSONA IGUAL INTRODUCIDA.
                {
                    Console.WriteLine("La persona introducida ya esta en la lista.");
                }
                else
                {
                    comprobarProfesion(ref profesion); //Metodo donde elige el usuario si es profesor o alumno.
                    //Si profesion es alumno nos iniciara el siguiente condicional, si no se iria al else para pedir los datos del profesor
                    if (profesion == 1)
                    {
                        if (datosAlumno(misDatos, persona, miEdad) == false)
                        {
                            Console.WriteLine("Este nº de expediente ya existe.");
                        }

                    }
                    else
                    {
                        datosProfesor(MetodosStatic.MisPersonas, misDatos, persona, miEdad);
                    }

                }
                Console.WriteLine("\t\t=> DESEA INTRODUCIR MÁS PERSONAS (SI/NO): ");
                respuesta = Console.ReadLine().ToLower();
                if (respuesta == "si")
                {
                    i++;
                }



            } while (respuesta.ToLower() == "si");
        }

        //METODO MENU DONDE TENEMOS EL SWITCH CON TODAS LAS OPCIONES.
        public static void menu()
        {
            int opcionMenu = 0;
            do
            {
                Console.WriteLine("***********MENU***********\n" +
                "1. Añadir Personas\n" +
                "2. Visualizar Personas \n" +
                "3. Borrar una persona\n" +
                "4.Datos de un empleado público\n" +
                "5. Obtener el mayor de 2 persoanas\n" +
                "6. Salir");

                do
                {
                    Console.WriteLine("OPCION (1-6): ");

                }while (!int.TryParse(Console.ReadLine(), out opcionMenu) || opcionMenu <= 0  || opcionMenu >= 7 );

                switch( opcionMenu )
                {
                    case 1: 
                        añadirPersonas();
                        break;
                    case 2:
                        mostrarPersonas();
                        break;
                    case 3:
                        borradoPersonas();
                        break;
                    case 4:
                        datosEmpleadoPublico();
                        break;
                    case 5:
                        mayorEdad();
                        break;


                }


            } while (opcionMenu != 6);
            
        }

        //Metodo donde pedimos que escoga entre alumno o maestro
        public static void comprobarProfesion(ref int profesion)
        {

            bool esProfesion;
            do
            {


                Console.WriteLine("ESCOJE UNA OPCIÓN: \n1.-Alumno\n2.-Maestro: \t==>OPCIÓN(1/2)");

                esProfesion = int.TryParse(Console.ReadLine(), out profesion);

            } while (!esProfesion || !comprobarProfesion2(profesion));


        }

        //Comprobaremos que el numero que escoga solo sea 1 o 2.
        public static bool comprobarProfesion2(int profesion)
        {

            if (profesion > 0 && profesion < 3)
            {
                return true;
            }

            return false;
        }

        //Metodo para introducir los datos de los alumnos, donde pasaremos por parametros los atributros necesarios en el metodo principal.
        public static bool datosAlumno(string[] misDatos, Persona persona, int miEdad)
        {
            int numExpediente = 0;
            do
            {
                Console.WriteLine("Nº EXPEDIENTE: ");

            } while ((!int.TryParse(Console.ReadLine(), out numExpediente)) || numExpediente < 0);

            if (mismoExpediente(numExpediente, MetodosStatic.MisPersonas))
            {
                //Quiere decir que ya hay un alumno con el mismo numero de expediente.
                return false;
            }
            else
            {
                //Añadiremos el alumno al List<Persona>
                MetodosStatic.MisPersonas.Add(new Alumno(misDatos[0], misDatos[1] + " " + misDatos[2], miEdad, numExpediente));

            }
            return true;

        }

        

        //Metodo para introducir los datos de los profesor como la materia.
        public static void datosProfesor(List<Persona> misProfesores, string[] misDatos, Persona persona, int miEdad)
        {
            string materiaImpartida;
            int miOpcion;
            bool destinoDesfinitivo;
            string respuestaDestino;
            int tipoMedico;
            int anyoIngreso;
            do
            {
                Console.WriteLine("MATERIA QUE IMPARTE:");
                materiaImpartida = Console.ReadLine();

            } while (int.TryParse(materiaImpartida,out _));

            //OPCIONES DE TIPO PROFESOR
            do
            {
                Console.WriteLine("Elige el tipo de profesor: \n1. Interino\n" +
                "2. En Practicas\n" +
                "3. De Carrera\t\t\t" +
                "==>OPCION (1,2,3):");

            } while (!int.TryParse(Console.ReadLine(), out miOpcion));
            
            //SI ES INTERINO NO LE PEDIMOS MAS COSAS EN EL CASO CONTRARIO, AÑO DE INGRESO, DESTINO DEFINITIVO Y TIPO DE MEDICO.
            switch(miOpcion)
            {
                case 1:
                    TipoFuncionario tipoFuncionarioInterino = TipoFuncionario.Interino;
                    MisPersonas.Add(new ProfesorInterino(misDatos[0], misDatos[1] + " " + misDatos[2],miEdad,materiaImpartida, tipoFuncionarioInterino));
                    
                    break;
                case 2:
                    TipoFuncionario tipoFuncionarioPracticas = TipoFuncionario.EnPracticas;
                    
                    do
                    {
                        Console.WriteLine("AÑO DE INGRESO AL CUERPO (AÑO MAYOR DEL 2000): ");

                    } while (!int.TryParse(Console.ReadLine(), out anyoIngreso) || anyoIngreso <= 0 || anyoIngreso < 2000);

                    do
                    {
                        Console.WriteLine("DESTINO DEFINITIVO: (SI/NO)");
                         respuestaDestino = Console.ReadLine().ToLower();
                        if(respuestaDestino == "si")
                        {
                            destinoDesfinitivo = true;
                        }
                        else
                        {
                            destinoDesfinitivo = false;
                        }
                    } while (respuestaDestino != "si" && respuestaDestino != "no");

                    do
                    {
                        Console.WriteLine("ELIGE EL TIPO DE SEGURO MEDICO: \n1. Seguridad Social\n2. MUFACE\t\t\t=>OPCION: (1/2)");

                    } while (!int.TryParse(Console.ReadLine(), out tipoMedico) || (tipoMedico != 2  && tipoMedico != 1));

                    MisPersonas.Add(new ProfesorFuncionario(misDatos[0], misDatos[1] + " " + misDatos[2], miEdad, materiaImpartida, tipoFuncionarioPracticas,destinoDesfinitivo,anyoIngreso,tipoMedico));

                    break;

                case 3:
                    TipoFuncionario tipoFuncionarioCarrera = TipoFuncionario.DeCarrera;

                    do
                    {
                        Console.WriteLine("AÑO DE INGRESO AL CUERPO (AÑO MAYOR DEL 2000): ");

                    } while (!int.TryParse(Console.ReadLine(), out anyoIngreso) || anyoIngreso <= 0 || anyoIngreso < 2000);

                    do
                    {
                        Console.WriteLine("DESTINO DEFINITIVO: (SI/NO)");
                        respuestaDestino = Console.ReadLine().ToLower();
                        if (respuestaDestino == "si")
                        {
                            destinoDesfinitivo = true;
                        }
                        else
                        {
                            destinoDesfinitivo = false;
                        }
                    } while (respuestaDestino != "si" && respuestaDestino != "no");

                    do
                    {
                        Console.WriteLine("ELIGE EL TIPO DE SEGURO MEDICO: \n1. Seguridad Social\n2. MUFACE\t\t\t=>OPCION: (1/2)");

                    } while (!int.TryParse(Console.ReadLine(), out tipoMedico) || (tipoMedico != 2 && tipoMedico != 1));

                    MisPersonas.Add(new ProfesorFuncionario(misDatos[0], misDatos[1] + " " + misDatos[2], miEdad, materiaImpartida, tipoFuncionarioCarrera, destinoDesfinitivo, anyoIngreso, tipoMedico));

                    break;


            }


        }
        //Mostramos alumnos recorriendo el List<>
        public static void mostrarAlumnos()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t////////////ALUMNOS////////////");

            Console.WriteLine("Nombre".PadRight(20) + "Apellidos".PadRight(20) + "Edad".PadRight(20) + "Email".PadRight(20) + "Nº EXPEDIENTE".PadLeft(18));


            foreach (var alumno in MisPersonas)
            {
                if (alumno is Alumno)
                {
                    Alumno alumno1 = (Alumno)alumno;
                    Console.WriteLine($"{alumno1.nombre.PadRight(20)}{alumno1.apellidos.PadRight(20)}{alumno1.edad.ToString().PadRight(20)}{alumno1.email.PadRight(20)}{alumno1.numeroExpediente.ToString().PadLeft(8)}");
                    
                }
            }


        }

        //Mostramos profesores recorriendo su list<>
        public static void mostrarProfesor()
        {
            string destino;
            string tipoMedico;
            Console.WriteLine();
            Console.WriteLine("\t\t\t////////////PROFESORES////////////");

            Console.WriteLine("Nombre".PadRight(20) + "Apellidos".PadRight(20) + "Edad".PadRight(10) + "Email".PadRight(20) + "MATERIA".PadRight(10) + "FUNCIONARIO".PadRight(10) + "AÑO".PadLeft(8) + "DEFINITIVO".PadLeft(15) + "S.MÉDICO".PadLeft(10));

            foreach (var profesor in MisPersonas)
            {
                if(profesor is ProfesorInterino) {
                    ProfesorInterino profesorInterino = (ProfesorInterino)profesor;
                    Console.WriteLine($"{profesorInterino.nombre.PadRight(20)}" +
                         $"{profesorInterino.apellidos.PadRight(20)}" +
                         $"{profesorInterino.edad.ToString().PadRight(10)}" +
                         $"{profesorInterino.email.PadRight(20)}" +
                         $"{profesorInterino.materia.PadRight(10)}" +
                         $"{profesorInterino.TipoProfesor}");
                    
                    
                }else if(profesor is ProfesorFuncionario) {
                    ProfesorFuncionario profesorFuncionario = (ProfesorFuncionario)profesor;
                    if(profesorFuncionario.DestinoDefinitivo == true)
                    {
                        destino = "si";
                    }
                    else
                    {
                        destino = "no";
                    }

                    if(profesorFuncionario.TipoMedico == 1)
                    {
                        tipoMedico = "Seguridad Social";
                    }
                    else
                    {
                        tipoMedico = "MUFACE";
                    }

                    Console.WriteLine($"{profesorFuncionario.nombre.PadRight(20)}" +
                        $"{profesorFuncionario.apellidos.PadRight(20)}" +
                        $"{profesorFuncionario.edad.ToString().PadRight(10)}" +
                        $"{profesorFuncionario.email.PadRight(20)}" +
                        $"{profesorFuncionario.materia.PadRight(10)}" +
                        $"{profesorFuncionario.TipoProfesor}" +
                        $"{profesorFuncionario.AnyoIngresoCuerpo.ToString().PadLeft(8)}" +
                        $"{destino.PadLeft(15)}" +
                        $"{tipoMedico.PadLeft(10)}");

                }
                
            }
        }

        //Comprobamos que no hay más de un alumno con el mismo expediente.
        public static bool mismoExpediente(int nExpediente, List<Persona> misPersonas)
        {
            foreach (var mis in misPersonas)
            {
                if (mis is Alumno)
                {
                    Alumno alumno = (Alumno)mis;
                    if (nExpediente == alumno.numeroExpediente)
                    {
                        return true;
                    }
                }



            }

            return false;
        }

        public static void mostrarPersonas()
        {
            Console.WriteLine("/////////////////LISTADO DE ALUMNOS Y PROFESORES/////////////////");
            mostrarAlumnos();
            mostrarProfesor();
        }

        //OPCION BORRADO PERSONAS LLAMANDO AL METODO CREADO ANTES.
        public static void borradoPersonas()
        {
            Console.WriteLine("******BORRADO DE PERSONAS******");
            string nombre = "";
            string apellidos = "";
            int edad = 0;

            comprobarDatos(ref nombre, ref apellidos, ref edad);
            string datos = convertirCadena(ref nombre, ref apellidos);
            string[] misDatos = datos.Split(' ');
            string apellidosConver = misDatos[1] + " " + misDatos[2];


            if (SeekRemoved(misDatos[0], apellidosConver, edad))
            {
                Console.WriteLine("Borrado Correctamente");
            }
            else { Console.WriteLine("No existe esta persona"); }

        }
        
        //OPCION DE MOSTRAR DATOS DEL EMPLEADO PUBLIC, COMO TIEMPO TRABAJADO, SEXENIO, TRIENIOS.
        public static void datosEmpleadoPublico()
        {
            Console.WriteLine("******DATOS DEL EMPLEADO******");
            string nombre = "";
            string apellidos = "";
            int edad = 0;
            bool hayFuncionarios = false;
            comprobarDatos(ref nombre, ref apellidos, ref edad);
            string datos = convertirCadena(ref nombre,ref apellidos);
            string[] misDatos = datos.Split(' ');
            string apellidosConver = misDatos[1] + " " + misDatos[2];

            foreach (var objecto in MisPersonas)
            {
                if(objecto is ProfesorFuncionario)
                {
                    if(objecto.nombre == misDatos[0] && objecto.apellidos == apellidosConver && objecto.edad == edad)
                    {
                        ProfesorFuncionario profDatos = (ProfesorFuncionario)objecto;
                        Console.WriteLine("TIEMPO DE SERVICIO: " + profDatos.TiempoServicio()
                            + "\nNº SEXENIOS: "
                            + profDatos.GetSexenios()
                            + "\nNº TRIENIOS: " + profDatos.GetTrienios());
                        hayFuncionarios = true;
                    }
                }


            }

            if (!hayFuncionarios)
            {
                Console.WriteLine("LA PERSONA NO EXISTE O NO ES UN EMPLEADO PUBLICO");
            }

        }

        //OPCION QUE TE DICE QUE PERSONA ES MAYOR, UTILIZANDO LA SOBRECARGA DE OPERADORES > <
        public static void mayorEdad()
        {
            string nombre = "";
            string apellidos = "";
            int edad = 0;


            Console.WriteLine("******COMPARAR 2 PERSONAS******");
            Console.WriteLine("PERSONA 1");
            comprobarDatos(ref nombre, ref apellidos, ref edad);
            string datos = convertirCadena(ref nombre,ref apellidos);
            string[] misDatos = datos.Split(" ");
            if(buscarPersona(MisPersonas, misDatos[0], misDatos[1] + " " + misDatos[2]) != null)
            {
                Persona p1 = new Persona(nombre, apellidos, edad);

                Console.WriteLine("PERSONA 2");
                comprobarDatos(ref nombre, ref apellidos, ref edad); 
                string datos2 = convertirCadena(ref nombre,ref apellidos);
                string[] misDatos2 = datos2.Split(" ");
                if (buscarPersona(MisPersonas, misDatos2[0], misDatos2[1] + " " + misDatos2[2]) != null)
                {
                    Persona p2 = new Persona(nombre, apellidos, edad);

                    if (p1 > p2)
                    {
                        Console.WriteLine("PERSONA MAS MAYOR: \n" + p1.toString());
                    }
                    else if (p2 > p1)
                    {
                        Console.WriteLine("PERSONA MAS MAYOR: \n" + p2.toString());
                    }
                    else
                    {
                        Console.WriteLine("PERSONA DE IGUAL EDAD: \n" + p1.toString() + "\n" + p2.toString());
                    }
                }
                else
                {
                    Console.WriteLine("No se ha encontrado");
                }


            }
            else
            {
                Console.WriteLine("No se ha encontrado");
            }

            

            

            Console.WriteLine();
        }

        //METODO AUXILIAR PARA SABER SI SE ENCUENTRA UNA PERSONA EN LA LISTA O NO.
        public static Persona buscarPersona(List<Persona> lista, string nombre,string apellidos) {

            foreach(Persona persona in lista)
            {
                if(persona.nombre == nombre && persona.apellidos == apellidos)
                {
                    
                    return persona;
                }
            }

            return null;
        }

    }
}

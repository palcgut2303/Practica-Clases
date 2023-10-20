using EjerciciosClases;

namespace _2HerenciaSimpleIES
{
    internal class _2HerenciaSimple
{
        static int i = 1;
        
        static void Main(string[] args)
        {
            init2();
        }

        //Metodo iniciador donde tenemos todo el codigo principal.
        public static void init2()
        {

            string miNombre = "";
            string misApellidos = "";
            string miEmail;
            int miEdad = 0;
            string respuesta;
            int profesion = 0;
            
            //Creamos List<> de alumnos y profesores.
            
            List<Alumno> misAlumnos = new List<Alumno>();  
            List<Profesor> misProfesores = new List<Profesor>();

            //Metodo para introducir datos y comprobar.
            do { 
                Persona persona = new Persona();

                Console.WriteLine("---PERSONA {0}---", i);
                MetodosStatic.comprobarDatos(ref miNombre, ref misApellidos, ref miEdad);
                string datos = MetodosStatic.convertirCadena(ref miNombre, misApellidos);
                string[] misDatos = datos.Split(' ');

                if (MetodosStatic.MisPersonas.Count >= 1 && Persona.Equals(miNombre, misApellidos) )
                {
                    Console.WriteLine("La persona introducida ya esta en la lista.");
                }
                else
                {
                    comprobarProfesion(ref profesion); //Metodo donde elige el usuario si es profesor o alumno.
                    //Si profesion es alumno nos iniciara el siguiente condicional, si no se iria al else para pedir los datos del profesor
                    if (profesion == 1)
                    {
                        if(datosAlumno(misAlumnos, misDatos, persona, miEdad) == false)
                        {
                            Console.WriteLine("Este nº de expediente ya existe.");
                        }



                    }
                    else
                    {

                        datosProfesor(misProfesores, misDatos, persona, miEdad);
                    }

                }
                Console.WriteLine("\t\t=> DESEA INTRODUCIR MÁS PERSONAS (SI/NO): ");
                respuesta = Console.ReadLine().ToLower();
                if (respuesta == "si")
                {
                    i++;
                }



            } while (respuesta.ToLower() == "si");

            //Mostramos alumnos y profesores.
            mostrarAlumnos(misAlumnos);
            mostrarProfesor(misProfesores);


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
            
            if(profesion >0 && profesion < 3)
            {
                return true;
            }

            return false;
        }

        //Metodo para introducir los datos de los alumnos, donde pasaremos por parametros los atributros necesarios en el metodo principal.
        public static bool datosAlumno(List<Alumno> misAlumnos, string[] misDatos,Persona persona,int miEdad)
        {
            int numExpediente = 0;
            do
            {
                Console.WriteLine("Nº EXPEDIENTE: ");

            } while ((!int.TryParse(Console.ReadLine(), out numExpediente)) || numExpediente<0);

            if (mismoExpediente(numExpediente, misAlumnos))
            {
                //Quiere decir que ya hay un alumno con el mismo numero de expediente.
                return false;
            }
            else
            {

                MetodosStatic.MisPersonas.AddRange(new[] {
                            new Persona
                            {
                                nombre = misDatos[0],
                                apellidos = misDatos[1] + " " +misDatos[2],
                                edad = miEdad,
                                email = persona.GenerarCorreoElectronico(misDatos[0],misDatos[1] + " " +misDatos[2]),
                                
                            }
                        });

                //Añadiremos el alumno al List<>
                misAlumnos.AddRange(new[] {
                            new Alumno
                            {
                                nombre = misDatos[0],
                                apellidos = misDatos[1] + " " +misDatos[2],
                                edad = miEdad,
                                email = persona.GenerarCorreoElectronico(misDatos[0],misDatos[1] + " " +misDatos[2]),
                                numeroExpediente = numExpediente
                            }
                        });
            }
            return true;
            
        }

        //Metodo para introducir los datos de los profesor como la materia.
        public static void datosProfesor(List<Profesor> misProfesores, string[] misDatos,Persona persona, int miEdad)
        {
            string materiaImpartida;
            Console.WriteLine("MATERIA QUE IMPARTE:");
            materiaImpartida = Console.ReadLine();

            MetodosStatic.MisPersonas.AddRange(new[] {
                            new Persona
                            {
                                nombre = misDatos[0],
                                apellidos = misDatos[1] + " " +misDatos[2],
                                edad = miEdad,
                                email = persona.GenerarCorreoElectronico(misDatos[0],misDatos[1] + " " +misDatos[2]),

                            }
                        });


            misProfesores.AddRange(new[] {
                            new Profesor
                            {
                                nombre = misDatos[0],
                                apellidos = misDatos[1] + " " +misDatos[2],
                                edad = miEdad,
                                email = persona.GenerarCorreoElectronico(misDatos[0],misDatos[1] + " " +misDatos[2]),
                                materia = materiaImpartida
                            }
                        });
        }
        //Mostramos alumnos recorriendo el List<>
        public static void mostrarAlumnos(List<Alumno> misAlumnos)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t////////////ALUMNOS////////////");
            if (misAlumnos.Count == 0)
            {
                Console.WriteLine("\nNO HAY ALUMNOS DISPONIBLES.");
            }
            else
            {
                
                Console.WriteLine("Nombre".PadRight(20) + "Apellidos".PadRight(20) + "Edad".PadRight(20) + "Email".PadRight(20) + "Nº EXPEDIENTE".PadLeft(18));

               
                foreach (var alumno in misAlumnos)
                {
                    Console.WriteLine($"{alumno.nombre.PadRight(20)}{alumno.apellidos.PadRight(20)}{alumno.edad.ToString().PadRight(20)}{alumno.email.PadRight(20)}{alumno.numeroExpediente.ToString().PadLeft(8)}");
                }
            }
            
        }

        //Mostramos profesores recorriendo su list<>
        public static void mostrarProfesor(List<Profesor> misProfesores)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t////////////PROFESORES////////////");
            if (misProfesores.Count == 0)
            {
                Console.WriteLine("\nNO HAY PROFESORES DISPONIBLES.");
            }
            else
            {
                
                Console.WriteLine("Nombre".PadRight(20) + "Apellidos".PadRight(20) + "Edad".PadRight(10) + "Email".PadRight(28) + "MATERIA");

                foreach (var profesor in misProfesores)
                {
                    Console.WriteLine($"{profesor.nombre.PadRight(20)}{profesor.apellidos.PadRight(20)}{profesor.edad.ToString().PadRight(10)}{profesor.email.PadRight(28)}{profesor.materia}");
                }
            }

            
        }
        //Comprobamos que no hay más de un alumno con el mismo expediente.
        public static bool mismoExpediente(int nExpediente,List<Alumno> misAlumnos)
        {
            foreach (var mis in misAlumnos)
            {
                if(nExpediente == mis.numeroExpediente)
                {
                    return true;
                }


            }

            return false;
        }
    }
}
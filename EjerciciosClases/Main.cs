using System.Text.RegularExpressions;
using static EjerciciosClases.Persona;
namespace EjerciciosClases
{
    public class _1MayoresDeEdad
    {
        //Atributos que vamos a utilizar en toda la clase.
        static int i = 1;
        static List<Persona> misPersonas = new List<Persona>(); //Array de personas donde las añadiremos.
        public static List<Persona> MisPersonas
        {
            get { return misPersonas; }
            set { misPersonas = value; }
        }

        //Main, instanciaremos nuestros metodo de inicio e introducir las personas por defecto.
        static void Main(string[] args)
        {
            introducirPersonasAleatorias();
            init();
            
        }

        //Metodo iniciador.
        public static void init()
        {
            string miNombre = "";
            string misApellidos = "";
            string miEmail;
            int miEdad = 0;
            string respuesta;

            //Bucle do while para que se repita al menos una vez él introducir una persona.
            do
            {
                Persona persona = new Persona();
                
                Console.WriteLine("---PERSONA {0}---", i);
                comprobarDatos(ref miNombre, ref misApellidos, ref miEdad);
                string nombreModificado = eliminarEspaciosNombre(miNombre);
                string apellidoModificado =  eliminarEspaciosApellidos(misApellidos);
                string datos = persona.convertirCadena(ref nombreModificado, apellidoModificado);
                string[] misDatos = datos.Split(' ');

                //Comprobamos que no haya dos personas iguales.
                if (MisPersonas.Count >= 1 && mismaPersona(nombreModificado, apellidoModificado))
                {
                    Console.WriteLine("La persona introducida ya esta en la lista.");
                }
                else
                {
                    //Si no hay ninguna persona igual, se añadira al List<>.
                    MisPersonas.AddRange(new[] {
                    new Persona
                    {
                        nombre = misDatos[0],
                        apellidos = misDatos[1] + " " +misDatos[2],
                        edad = miEdad,
                        email = persona.GenerarCorreoElectronico(misDatos[0],misDatos[1] + " " +misDatos[2])
                    }
                 });
                }



                Console.WriteLine("\t\t=> DESEA INTRODUCIR MÁS PERSONAS (SI/NO): ");
                respuesta = Console.ReadLine().ToLower();
                if (respuesta == "si")
                {
                    i++;
                }


                //Si se desea introducir mas persona, se repite el bucle.
            } while (respuesta.ToLower() == "si");

            mostrarPersonas();

            mostrarMenores18();

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

        
        //Metodo para comprobar si hay alguna persona igual o no.
        public static bool mismaPersona(string nombre, string apellido)
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

        //Mostramos todas las personas del List<>
        public static void mostrarPersonas()
        {
            Console.WriteLine();
            Console.WriteLine("Nombre".PadRight(20) + "Apellidos".PadRight(20) + "Edad".PadRight(10) + "Email");

            foreach (var persona in misPersonas)
            {
                Console.WriteLine($"{persona.nombre.PadRight(20)}{persona.apellidos.PadRight(20)}{persona.edad.ToString().PadRight(10)}{persona.email}");
            }

        }

        //Mostramos todas las personas del List<> menores de 18
        public static void mostrarMenores18()
        {
            Console.WriteLine();
            Console.WriteLine("Nombre".PadRight(20) + "Apellidos".PadRight(20) + "Edad".PadRight(10) + "Email");
            int contador = 0;
            foreach (var persona in misPersonas)
            {
                if(persona.edad < 18)
                {
                 Console.WriteLine($"{persona.nombre.PadRight(20)}{persona.apellidos.PadRight(20)}{persona.edad.ToString().PadRight(10)}{persona.email}");
                    contador++;
                }
            }

            if(contador == 0)
            {
                Console.WriteLine("No hay personas menores de 18");
            }

        }

        //Metodo para introducir personas sin tener que introducir los datos por teclado. 
        public static void introducirPersonasAleatorias()
        {Persona persona = new Persona();
            misPersonas.AddRange(new[] {
                                        new Persona
                                        {
                                            
                                            nombre="Juan",
                                            apellidos="Lopez Cruz",
                                            edad=34,
                                            email=persona.GenerarCorreoElectronico("JUAN","LOPEZ CRUZ")
                                        },
                                        new Persona
                                        {
                                            nombre="Manolo",
                                            apellidos="Garcia Rios",
                                            edad=14,
                                            email=persona.GenerarCorreoElectronico("MANOLO","GARCÍA RIOS")
                                        },
                                        new Persona
                                        {
                                            nombre="Rebeca",
                                            apellidos="Alcudia Toril",
                                            edad=34,
                                            email=persona.GenerarCorreoElectronico("REBECA","ALCUDIA TORIL")
                                        }
            });

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








    }
}
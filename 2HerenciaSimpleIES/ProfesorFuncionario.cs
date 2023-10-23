using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    internal class ProfesorFuncionario : Profesor, IEmpleadoPublico
    {
        public int AnyoIngresoCuerpo {get; set;}

        public bool DestinoDefinitivo { get; set; }

        public ProfesorFuncionario(string nombre, string apellido, int edad) : base(nombre, apellido, edad)
        {
        }

        public ProfesorFuncionario(string nombre, string apellido, int edad,string materia,TipoFuncionario tipoProfesor,bool destinoDefinitivo,int anyoIngreso,int tipoMedico) : base(nombre, apellido, edad)
        {
            base.materia = materia;
            base.TipoProfesor = tipoProfesor;
            DestinoDefinitivo = destinoDefinitivo;
            AnyoIngresoCuerpo = anyoIngreso;
            TipoMedico = tipoMedico;

        }



        public override string toString => ToStringProfesor() + " " + AnyoIngresoCuerpo + " " + DestinoDefinitivo;

        private int tipoMedico;
        public int TipoMedico
        {
            get
            {
                return tipoMedico;
            }
            set
            {
                if (value == 1 || value == 2)
                {
                    tipoMedico = value; // Solo permite 1 o 2
                }
                else
                {
                    throw new ArgumentException("El valor de TipoMedico debe ser 1 (SeguridadSocial) o 2 (Muface).");
                }
            }
        }


        //METODO PARA OBTENER LOS SEXENIOS, MEDIANTE DateTime.
        public int GetSexenios()
        {
            DateTime fechaActual = DateTime.Now;
            int añosTrabajados = fechaActual.Year - AnyoIngresoCuerpo;

            if (fechaActual.Month < 9 || (fechaActual.Month == 9 && fechaActual.Day < 1))
            {
                añosTrabajados--; // Restamos un año si la fecha actual es anterior al 1 de septiembre
            }

            return añosTrabajados / 6;
        }

        //METODO PARA OBTENER LOS TRIENIOS, MEDIANTE DateTime.
        public int GetTrienios()
        {
            DateTime fechaActual = DateTime.Now;
            int añosTrabajados = fechaActual.Year - AnyoIngresoCuerpo;

            if (fechaActual.Month < 9 || (fechaActual.Month == 9 && fechaActual.Day < 1))
            {
                añosTrabajados--; // Restamos un año si la fecha actual es anterior al 1 de septiembre
            }

            return añosTrabajados / 3;
        }

        //METODO PARA AVERIGUAR EL TIEMPO DE SERVICIO QUE ESTA EL TRABAJDOR EN LA EMPRESA.
        public (int años, int días, int meses) TiempoServicio()
        {
            DateTime fechaActual = DateTime.Now;
            int añoActual = fechaActual.Year;
            int mesActual = fechaActual.Month;
            int diaActual = fechaActual.Day;

            int añosTrabajados = añoActual - AnyoIngresoCuerpo;

            if (mesActual < 9 || (mesActual == 9 && diaActual < 1))
            {
                añosTrabajados--; // Restamos un año si la fecha actual es anterior al 1 de septiembre
            }

            int meses = (mesActual - 9 + 12) % 12; // Cálculo de los meses transcurridos
            int días = diaActual - 1; // Días transcurridos en el mes actual

            return (añosTrabajados, meses, días);

        }
    }
}

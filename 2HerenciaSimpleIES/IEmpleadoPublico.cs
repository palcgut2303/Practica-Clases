using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    public interface IEmpleadoPublico
    {
        // Propiedad para obtener el Tipo de Médico
        public int TipoMedico { get; set; }

        // Método para obtener el tiempo de servicio
        public (int años, int días, int meses) TiempoServicio();

        // Método para obtener los sexenios acumulados
        public int GetSexenios();

        // Método para obtener los trienios acumulados
        public int GetTrienios();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion de alumno repetido
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : base("Alumno Repetido.") { }
        
    }
}

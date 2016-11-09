using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion retornada si no hay instructor para la clase
    /// </summary>
    public class SinInstructorException : Exception
    {
        public SinInstructorException() : base("No hay instructor para la clase.") { }
    }
}

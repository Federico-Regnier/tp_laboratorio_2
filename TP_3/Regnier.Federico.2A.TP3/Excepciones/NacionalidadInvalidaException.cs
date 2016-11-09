using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion por ingresar un dni que no se coincide con la nacionalidad
    /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException(string message) : base(message) { }
        public NacionalidadInvalidaException() : base() { }

    }
}

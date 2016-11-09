using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion por ingresar un DNI invalido
    /// </summary>
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException() : base() { }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
            this.mensajeBase = message;
        }

        public DniInvalidoException(Exception e) : this(null, e) { }

        public DniInvalidoException(string message) : this(message, null) { }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion al intentar leer o guardar un archivo
    /// </summary>
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base("Error en el archivo.", innerException) { }
    }
}

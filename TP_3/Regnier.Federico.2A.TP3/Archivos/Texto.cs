using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda el string pasado en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="dato">String a guardar</param>
        /// <returns></returns>
        public bool guardar(string archivo, string dato)
        {
            bool flag = false;

            if (archivo != null && dato != null)
            {
                try
                {
                    using (StreamWriter escritor = new StreamWriter(archivo, false))
                    {
                        escritor.Write(dato);
                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return flag;
        }

        /// <summary>
        /// Lee todo el contenido del archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="dato">Donde se guardara el string</param>
        /// <returns></returns>
        public bool leer(string archivo, out string dato)
        {
            bool flag = false;
            dato = null;

            if (archivo != null)
            {
                try
                {
                    using (StreamReader lector = new StreamReader(archivo))
                    {
                        dato = lector.ReadToEnd();
                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return flag;
        }

    }
}

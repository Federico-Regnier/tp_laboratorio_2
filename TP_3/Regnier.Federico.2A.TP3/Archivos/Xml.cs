using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa los datos del tipo pasado en un xml
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a ser serializados</param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            bool flag = false;

            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    escritor.Formatting = Formatting.Indented;
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(escritor, datos);
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return flag;
            
        }

        /// <summary>
        /// Deserializa los datos del archivo xml
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos deserializados</param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            bool flag = false;
            datos = default(T);

            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(lector);
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return flag;
        }
    }
}

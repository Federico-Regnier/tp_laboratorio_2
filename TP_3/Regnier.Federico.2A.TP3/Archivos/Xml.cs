﻿using System;
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
        public bool guardar(string archivo, T datos)
        {
            bool flag = false;

            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return flag;
            
        }

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

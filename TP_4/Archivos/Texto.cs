using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        // Ruta del Archivo
        private string _path;

        public Texto(string archivo)
        {
            this._path = archivo;
        }

        /// <summary>
        /// Guarda el string pasado en el archivo indicado por el path
        /// </summary>
        /// <param name="datos">Dato a guardar</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            bool flag = false;

            using (StreamWriter escritor = new StreamWriter(this._path, true))
            {
                escritor.WriteLine(datos);
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// Devuelve una lista con un string por cada linea guardada en el archivo
        /// </summary>
        /// <param name="datos">Lista donde se guardaran los datos leidos</param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            bool flag = false;
            datos = new List<string>();
            using (StreamReader lector = new StreamReader(this._path))
            {
                while (lector.Peek() > -1)
                {
                    datos.Add(lector.ReadLine());
                }

                flag = true;
            }

            return flag;
        }
    }
}

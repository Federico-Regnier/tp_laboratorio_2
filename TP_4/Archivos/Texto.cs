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
        private string _path;

        public Texto(string archivo)
        {
            this._path = archivo;
        }

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

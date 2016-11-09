using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz para guardar y leer archivos
    /// </summary>
    /// <typeparam name="T">Tipo del archivo a ser guardados</typeparam>
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en el archivo con la ruta especificada
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>True si tiene exito</returns>
        bool guardar(string archivo, T datos);

        /// <summary>
        /// Lee los datos del archivo
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Puntero a donde se guardaran los datos</param>
        /// <returns></returns>
        bool leer(string archivo, out T datos);
    }
}

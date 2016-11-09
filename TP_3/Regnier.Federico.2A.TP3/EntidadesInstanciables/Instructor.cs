using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        /// <summary>
        /// Constructor estatico que inicializa el random
        /// </summary>
        static Instructor()
        {
            Instructor._random = new Random();
        }

        /// <summary>
        /// Constructor por defecto para poder serializar la clase
        /// </summary>
        public Instructor() { }

        /// <summary>
        /// Constructor que inicializa los atributos de clase
        /// </summary>
        /// <param name="id">ID del instructor</param>
        /// <param name="nombre">Nombre del instructor</param>
        /// <param name="apellido">Apellido del instructor</param>
        /// <param name="dni">DNI como string del instructor</param>
        /// <param name="nacionalidad">Nacionalidad del instructor</param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad) 
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>(2);
            this._randomClases();
            
        }

        /// <summary>
        /// Devuelve un string con las clases que imparte en el dia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve en un string los datos del instructor y las clases que da
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve en un string los datos del instructor y las clases que da
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Agrega las clases que impartira el instructor por un random
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 4));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 4));
        }

        /// <summary>
        /// El instructor es igual a la clase si esta en su lista de clases del dia
        /// </summary>
        /// <param name="i">Instructor</param>
        /// <param name="clase">Clase a impartir</param>
        /// <returns></returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Un instructor no es igual a una clase si no la imparte
        /// </summary>
        /// <param name="i">Instructor</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }


    }
}

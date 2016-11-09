using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        /// <summary>
        /// Propiedad get de Alumnos para poder serializar la clase
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }
        private Gimnasio.EClases _clase;
        /// <summary>
        /// Clase de la jornada
        /// </summary>
        public Gimnasio.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }
        private Instructor _instructor;
        /// <summary>
        /// Instructor que imparte la clase
        /// </summary>
        public Instructor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }
        
        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa la lista
        /// </summary>
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa la jornada con el instructor y la clase pasadas
        /// </summary>
        /// <param name="clase">Clase</param>
        /// <param name="instructor">Instructor de la jornada</param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        /// <summary>
        /// Compara una jornada y un alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>Retorna true si el alumno esta en la jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return !(j != a);
        }

        /// <summary>
        /// Compara una jornada y un alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>Retorna true si el alumno no se encuentra en la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            if (a != j._clase)
                return true;
            return false;
        }

        /// <summary>
        /// Agrega un alumno a la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                j._alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Retorna los alumnos, el instructor y la clase como string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this._clase.ToString(), this._instructor.ToString());
            sb.AppendFormat("ALUMNOS: ").AppendLine();
            foreach (Alumno item in this._alumnos)
            {
                sb.Append(item.ToString());
            }
            sb.AppendLine("<----------------------------------------->");

            return sb.ToString();
        }

        /// <summary>
        /// Guarda la jornada pasada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();

            return text.guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee las jornadas del archivo de texto y las carga en datos
        /// </summary>
        /// <param name="datos">Variable a cargar las jornadas</param>
        /// <returns></returns>
        public static bool Leer(out string datos)
        {
            Texto text = new Texto();
            datos = null;
            return text.leer("Jornada.txt", out datos);
        }

    }
}

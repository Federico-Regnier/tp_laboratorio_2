using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(PersonaGimnasio))]
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        /// <summary>
        /// Propiedad get para poder serializar
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }
        private List<Instructor> _instructores;
        /// <summary>
        /// Propiedad get para poder serializar
        /// </summary>
        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }
        private List<Jornada> _jornada;
        /// <summary>
        /// Propiedad get para poder serializar
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }
        }
        
        public enum EClases
        {
            Natacion,
            CrossFit,
            Pilates,
            Yoga
        }

        /// <summary>
        /// Devuelve una jornada de la lista de jornadas
        /// </summary>
        /// <param name="i">Indice de la jornada</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i <= this._jornada.Count)
                    return this._jornada[i];

                return null;
            }
        }

        /// <summary>
        /// Constructor por defecto que inicializa las listas
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        /// <summary>
        /// Compara un gimnasio y un alumno. 
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno se encuentra en el gimnasio</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item.Equals(a))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Retorna true si el alumno no se encuentra en la lista de alumnos
        /// </summary>
        /// <param name="g">Gimnasio donde se buscara el alumno</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Retorna true si el instructor es parte del gimnasio
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="i">Instructor</param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Retorna true si el instructor no es parte del gimnasio
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="i">Instructor</param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara un gimnasio y una clase, devolviendo un instructor que pueda dar la clase
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">Clase a dar</param>
        /// <returns>Retorna un instructor que pueda dar la clase</returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                    return item;
            }

            throw new SinInstructorException();
        }

        /// <summary>
        /// Retorna el primer instructor del gimnasio que no pueda impartir la clase
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">Clase a impartir</param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                    return item;
            }

            return null;
        }

        /// <summary>
        /// Agrega un alumno al gimnasio salvo que ya exista
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();

            g._alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Agrega un instructor al gimnasio si no esta ya agregado
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="i">Instructor a agregar</param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g == i)
                throw new Exception("Instructor Repetido.");

            g._instructores.Add(i);
            return g;
        }

        /// <summary>
        /// Agrega una jornada al gimnasio si hay un instructor que pueda dar la clase
        /// </summary>
        /// <param name="g">Gimnasio</param>
        /// <param name="clase">Clase a agregar a la jornada</param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            try
            {
                Jornada j = new Jornada(clase, g == clase);
                foreach (Alumno item in g._alumnos)
                {
                    if (item == clase)
                        j += item;
                }
                g._jornada.Add(j);

                return g;

            }
            catch (SinInstructorException e)
            {
                
                throw e;
            }
        }

        /// <summary>
        /// Mustra los alumnos, instructores y jornadas del gimnasio
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim[i].ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra los alumnos, instructores y jornadas del gimnasio
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        /// <summary>
        /// Serializa el gimnasio pasado a un xml
        /// </summary>
        /// <param name="gim">Gimnasio a serializar</param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> xml = new Archivos.Xml<Gimnasio>();

            return xml.guardar("Gimnasio.xml", gim);
        }

        /// <summary>
        /// Lee el gimnasio de un xmly lo retorna
        /// </summary>
        /// <returns></returns>
        public static Gimnasio Leer()
        {
            Archivos.Xml<Gimnasio> xml = new Archivos.Xml<Gimnasio>();
            Gimnasio aux;
            if (xml.leer("Gimnasio.xml", out aux))
                return aux;

            return null;
        }

    }
}

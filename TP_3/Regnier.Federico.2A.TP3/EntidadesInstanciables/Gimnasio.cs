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
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }
        private List<Instructor> _instructores;
        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }
        private List<Jornada> _jornada;
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
        public Jornada this[int i]
        {
            get
            {
                if (i <= this._jornada.Count)
                    return this._jornada[i];

                return null;
            }
        }

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item.Equals(a))
                    return true;
            }

            return false;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                    return true;
            }

            return false;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                    return item;
            }

            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                    return item;
            }

            return null;
        }

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();

            g._alumnos.Add(a);
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g == i)
                throw new Exception("Instructor Repetido.");

            g._instructores.Add(i);
            return g;
        }

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

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        public static bool Guardar(Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> xml = new Archivos.Xml<Gimnasio>();

            return xml.guardar("Gimnasio.xml", gim);
        }

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

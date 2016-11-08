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
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        
        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion


    
        public static bool operator ==(Jornada j, Alumno a)
        {
            return !(j != a);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            if (a != j._clase)
                return true;
            return false;
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                j._alumnos.Add(a);

            return j;
        }

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


        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();

            return text.guardar("Jornada.txt", jornada.ToString());
        }

        public static bool Leer(out string datos)
        {
            Texto text = new Texto();
            datos = null;
            return text.leer("Jornada.txt", out datos);
        }

    }
}

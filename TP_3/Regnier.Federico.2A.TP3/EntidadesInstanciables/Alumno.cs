using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            MesPrueba
        }

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructores

        /// <summary>
        /// Constructor por defecto para poder serializar la clase
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Constructor de clase que inicializa todos los atributos
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI(int)del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de clase que inicializa todos los atributos
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI como string del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase del alumno</param>
        /// <param name="estadoCuenta">Estado de Cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        /// <summary>
        /// Devuelva la clase que toma como string
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Devuelve en un string todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine();
            sb.AppendFormat("ESTADO DE CUENTA: {0}", this._estadoCuenta.ToString()).AppendLine();
            sb.AppendFormat("TOMA CLASES DE {0}", this._claseQueToma.ToString()).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Retorna los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara un alumno y la clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si toma la clase y no tiene estado de cuenta Deudor</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }

        /// <summary>
        /// Retorna true si el alumno no toma la clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            return false;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        /// <summary>
        /// Numero identificador de la persona
        /// </summary>
        private int _identificador;

        /// <summary>
        /// Constructor por defecto para poder serializar
        /// </summary>
        public PersonaGimnasio() { }

        /// <summary>
        /// Constructor que inicializa todos los atributos
        /// </summary>
        /// <param name="id">ID de la persona</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI como string</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Devuelve un string con los atributos de clase
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.ToString());
            sb.AppendFormat("CARNET NÚMERO: {0}", this._identificador);
            
            return sb.ToString();
        }

        /// <summary>
        /// Retorna true si el operador o el DNI son iguales
        /// </summary>
        /// <param name="pg1">Primer persona a comparar</param>
        /// <param name="pg2">Segunda persona a comparar</param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador)
                return true;

            return false;
        }

        /// <summary>
        /// Compara las personas por DNI o identificador
        /// </summary>
        /// <param name="pg1">Persona a comparar</param>
        /// <param name="pg2">Persona a comparar</param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Retorna true si el tipo del objeto pasado es el mismo
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si es del mismo tipo, si no, retorna false.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                if (this == (PersonaGimnasio)obj)
                    return true;
            }
            return false;
        }

    }
}

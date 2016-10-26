using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string _nombre;
        public string Nombre
        {
            get
            {
                return this._nombre;
            }

            set
            {
                if (!string.IsNullOrEmpty(this.ValidarNombreApellido(value)))
                    this._nombre = value;
            }
        }
        private int _dni;
        public int DNI
        {
            get
            {
                return this._dni;
            }

            set
            {
                try
                {
                    this._dni = this.ValidarDni(this._nacionalidad, value);
                }
                catch (DniInvalidoException excepction)
                {
                    throw excepction;
                }
            }
        }
        public string StringToDNI
        {
            set
            {
                try
                {
                    this._dni = this.ValidarDni(this.Nacionalidad, value);
                }
                catch (DniInvalidoException exception)
                {

                    throw exception;
                }
            }
        }
        private ENacionalidad _nacionalidad;
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }
        private string _apellido;
        public string Apellido
        {
            get
            {
                return this._apellido;
            }

            set
            {
                if (!string.IsNullOrEmpty(this.ValidarNombreApellido(value)))
                    this._apellido = value;
            }
        }

        #region Constructores
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        private string ValidarNombreApellido(string dato)
        {
            if (string.IsNullOrEmpty(dato))
                return null;

            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato[i]))
                    return null;
            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new DniInvalidoException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                case ENacionalidad.Extranjero:
                    if (dato < 90000000)
                        throw new DniInvalidoException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                default:
                    return dato;
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (dato != null && int.TryParse(dato, out dni))
                return this.ValidarDni(nacionalidad, dni);

            throw new DniInvalidoException("El DNI no es un numero");

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre).AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad.ToString()).AppendLine();

            return sb.ToString();
        }

        #endregion
    }
}

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
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }
        /// <summary>
        /// Agrega el dni en formato string validandolo antes
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
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

        /// <summary>
        /// Constructor por defecto para poder serializar el objeto
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor que inicializa el nombre, apellido y nacionalidad solamente
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que inicializa los atributos
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI como entero</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que inicializa todos los atributos
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni como string</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el string pasado sean solo letras
        /// </summary>
        /// <param name="dato">String a validar como apellido</param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que el dni este entre 1 y 90000000 para argentinos y mayor para extranjeros
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona a validar el DNI</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                case ENacionalidad.Extranjero:
                    if (dato < 90000000)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                default:
                    return dato;
            }
        }

        /// <summary>
        /// Valida el dni pasado como string. 
        /// Entre 1 y 90000000(exclusivo) para argentinos y mayor a 90000000 para extranjeros
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (dato != null && int.TryParse(dato, out dni))
                return this.ValidarDni(nacionalidad, dni);

            throw new DniInvalidoException("El DNI no es valido");

        }

        /// <summary>
        /// Devuelve los datos de la persona como string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion
    }
}

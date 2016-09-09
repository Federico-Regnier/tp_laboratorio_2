using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Devuelve el valor de numero
        /// </summary>
        /// <returns>Double: valor de numero </returns>
        public double getNumero()
        {
            return numero;
        }

        /// <summary>
        /// Inicializa numero en 0.
        /// </summary>
        public Numero() : this(0) { }
        
        /// <summary>
        /// Inicializa numero con el valor pasado por parametro
        /// </summary>
        /// <param name="numero">Valor que se le asignara a numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Inicializa numero con el valor pasado como string si es un numero; si no en cero.
        /// </summary>
        /// <param name="numero">Valor a asignar pasado como string</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Asigna el valor pasado a numero, validandolo previamente.
        /// </summary>
        /// <param name="numero">Valor de numero</param>
        private void setNumero(string numero)
        {
            this.numero = this.validarNumero(numero);
        }

        /// <summary>
        /// Valida que el parametro pasado sea realmente un numero y lo retorna.
        /// En caso de no serlo, devuelve 0.
        /// </summary>
        /// <param name="numeroString">numero como string a validar</param>
        /// <returns>Numero validado o cero</returns>
        private double validarNumero(string numeroString)
        {
            double numero;
            if (double.TryParse(numeroString, out numero))
                return numero;
            return 0;
        }

    }
}

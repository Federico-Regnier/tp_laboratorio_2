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

        /// <summary>
        /// Operador suma, retorna un double con el resultado de la suma
        /// </summary>
        /// <param name="numero1">Primer numero a sumar</param>
        /// <param name="numero2">Segundo numero a sumar</param>
        /// <returns></returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            return (numero1.numero + numero2.numero);
        }

        /// <summary>
        /// Operador resta, retorna un double con el resultado de la resta
        /// </summary>
        /// <param name="numero1">Primer numero a restar</param>
        /// <param name="numero2">Segundo numero a restar</param>
        /// <returns></returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            return (numero1.numero - numero2.numero);
        }

        /// <summary>
        /// Operador multiplicar, retorna un double con el resultado de la multiplicacion
        /// </summary>
        /// <param name="numero1">Primer numero a multiplicar</param>
        /// <param name="numero2">Segundo numero a multiplicar</param>
        /// <returns></returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            return (numero1.numero * numero2.numero);
        }

        /// <summary>
        /// Operador suma, retorna un double con el resultado de la division
        /// </summary>
        /// <param name="numero1">Dividendo</param>
        /// <param name="numero2">Divisor</param>
        /// <returns>Resultado de la division</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            return (numero1.numero / numero2.numero);
        }

    }
}

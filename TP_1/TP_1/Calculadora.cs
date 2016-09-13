using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    
    public class Calculadora
    {
        
       /* 
        #region Deprecated por sobrecarga de operador
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            switch (Calculadora.validarOperador(operador))
            {
                case "+":
                    return (numero1.getNumero() + numero2.getNumero());
                case "-":
                    return (numero1.getNumero() - numero2.getNumero());
                case "/":
                    if(numero2.getNumero() != 0)
                        return (numero1.getNumero() / numero2.getNumero());
                    return 0;
                case "*":
                    return (numero1.getNumero() * numero2.getNumero());
                default:
                    return 0;
            }

        }
        #endregion
        */

        /// <summary>
        /// Realiza la operacion con los parametros y el operando pasados
        /// </summary>
        /// <param name="numero1">Primer numero a operar</param>
        /// <param name="numero2">Segundo numero a operar</param>
        /// <param name="operador">Operador(+,-,* o /)</param>
        /// <returns>Resultado de la operacion o 0, en caso de no poder operar</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            switch (Calculadora.validarOperador(operador))
            {
                case "+":
                    return (numero1 + numero2);
                case "-":
                    return (numero1 - numero2);
                case "/":
                    if (numero2.getNumero() != 0)
                        return (numero1 / numero2);
                    return 0;
                case "*":
                    return (numero1 * numero2);
                default:
                    return 0;
            }

        }



        /// <summary>
        /// Valida que el operador sea: +, -, * o /.
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>El operador validado o "+" en caso de no poder hacerlo</returns>
        public static string validarOperador(string operador)
        {
            switch (operador)
            {
                case "-":
                    return "-";
                case "/":
                    return "/";
                case "*":
                    return "*";
                default:
                    return "+";
            }
        }
    }
}

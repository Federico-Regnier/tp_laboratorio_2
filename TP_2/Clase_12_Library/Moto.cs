using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        private short _cantidadRuedas;

        /// <summary>
        /// Constructor que inicializa la cantidad de ruedas en 2 y los demas con los parametros
        /// </summary>
        /// <param name="marca">Marca de la moto</param>
        /// <param name="patente">Patente de la moto</param>
        /// <param name="color">Color de la moto</param>
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            this._cantidadRuedas = 2;
        }

        /// <summary>
        /// Cantidad de ruedas de la moto
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return this._cantidadRuedas;
            }
        }

        /// <summary>
        /// Retorna un string con los datos de la moto
        /// </summary>
        /// <returns></returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

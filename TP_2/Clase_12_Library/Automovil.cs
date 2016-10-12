using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        private short _cantidadRuedas;

        /// <summary>
        /// Constructor que inicializa las ruedas en 4 y los demás atributos con los pasados por parametro
        /// </summary>
        /// <param name="marca">Marca del auto</param>
        /// <param name="patente">Patente del auto</param>
        /// <param name="color">Color del auto</param>
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            this._cantidadRuedas = 4;
        }
        /// <summary>
        /// Cantidad de ruedas del automovil
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return this._cantidadRuedas;
            }
            
        }

        /// <summary>
        /// Retorna un string con los datos del auto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

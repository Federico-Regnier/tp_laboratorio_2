using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Camion : Vehiculo
    {
        private short _cantidadRuedas;

        /// <summary>
        /// Constructor que inicializa las ruedas en 8 y los demas atributos con los pasados por parametro
        /// </summary>
        /// <param name="marca">Marca del camion</param>
        /// <param name="patente">Patente del camion</param>
        /// <param name="color">Color del camion</param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            this._cantidadRuedas = 8;
        }
        /// <summary>
        /// Cantidad de ruedas del camion
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return this._cantidadRuedas;
            }
        }

        /// <summary>
        /// Retorna un string con los datos del camión
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

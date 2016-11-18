using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        /// <summary>
        /// Inicializa la direccion con la direccion pasada
        /// </summary>
        /// <param name="direccion"></param>
        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
        }

        /// <summary>
        /// Inicia la descarga del codigo html. Lanza un evento cuando cambia el progreso y cuando finaliza la descarga
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.Proxy = null;

                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public delegate void FinDescargaEventHandler(string html);
        public event FinDescargaEventHandler DescargaFinalizada;

        public delegate void ProgresoDescargaEventHandler(int progreso);
        public event ProgresoDescargaEventHandler ProgresoDescarga;

        /// <summary>
        /// Lanza un evento en caso de existir suscriptores a ProgresoDescarga con el porcentaje de progreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contiene el progreso de la descarga</param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (ProgresoDescarga != null)
                ProgresoDescarga(e.ProgressPercentage);
        }

        /// <summary>
        /// Lanza un evento con el codigo html descargado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contiene el codigo html descargado</param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.html = e.Result;
            if (DescargaFinalizada != null)
            {
                DescargaFinalizada(html);
            }
        }
    }
}

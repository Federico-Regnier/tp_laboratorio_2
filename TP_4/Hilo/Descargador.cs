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

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
        }

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

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (ProgresoDescarga != null)
                ProgresoDescarga(e.ProgressPercentage);
        }

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

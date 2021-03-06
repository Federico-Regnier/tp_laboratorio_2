﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Carga el formulario con las direcciones del archivo ARCHIVO_HISTORIAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            List<String> direcciones;
            try
            {
                if (archivos.leer(out direcciones))
                {
                    foreach (String item in direcciones)
	                {
                        this.lstHistorial.Items.Add(item);
	                }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            this.lblResultado.Text = string.Empty;
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = string.Empty;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1;
            Numero numero2;
            double resultado;

            numero1 = new Numero(this.txtNumero1.Text);
            numero2 = new Numero(this.txtNumero2.Text);

            resultado = Calculadora.operar(numero1, numero2, this.cmbOperacion.Text);
            this.lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }
    }
}

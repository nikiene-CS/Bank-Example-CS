using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBBank_v2
{
    public partial class frmTransferencia : Form
    {
        public double Valor { get; private set; }
        public string NConta { get; private set; }

        public frmTransferencia()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Valor = Double.Parse(txtValor.Text);
            NConta = txtContaDestino.Text;
            Close();
        }
    }
}

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
    public partial class frmLogin : Form
    {

        public string Numero { get; private set; }
        public string Senha { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            Numero = txtNumeroConta.Text;
            Senha = txtSenha.Text;
            Close();
        }
    }
}

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
    public partial class frmPrincipal : Form
    {
        Conta ContaAtual { get; set; }
        List<Conta> listaDeContas = new List<Conta>();

        public frmPrincipal()
        {
            InitializeComponent();
            listaDeContas.Add(new Conta("1010", "123456", new Usuario("Pedro", "222.777.888-99"), "pedro@pedro.com.br"));
            listaDeContas.Add(new Conta("0101", "123456", new Usuario("Gustavo", "111.222.333-44"), "gus_sk8@gus.com.br"));
        }

        public void AtualizaTela()
        {
            lblNome.Text = ContaAtual.Titular.Nome;
            lblPIX.Text = ContaAtual.Pix;
            lblSaldo.Text = ContaAtual.Saldo.ToString();
            
            lbxExtrato.Items.Clear();
            foreach (string log in ContaAtual.Logs)
            {
                lbxExtrato.Items.Add(log);
            }
        }

        public bool Login()
        {
            while (ContaAtual == null)
            {
                frmLogin login = new frmLogin();
                login.ShowDialog();
                //temos um conta na lista com a senha igual
                foreach (Conta conta in listaDeContas)
                {
                    if (conta.Numero == login.Numero && conta.SenhaCorreta(login.Senha))
                    {
                        ContaAtual = conta;
                        AtualizaTela();
                        return true;
                    }
                }
            }
            return false;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            frmDeposito deposito = new frmDeposito();
            deposito.ShowDialog();
            if(deposito.valor > 0)
            {
                ContaAtual.Deposito(deposito.valor);
                AtualizaTela();
            }
        }

        private void btnSaque_Click(object sender, EventArgs e)
        {
            frmSaque saque = new frmSaque();
            saque.ShowDialog();
            if(saque.Valor > 0)
            {
                ContaAtual.Saque(saque.Valor);
                AtualizaTela();
            }
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            frmTransferencia transferencia = new frmTransferencia();
            transferencia.ShowDialog();
            if(transferencia.Valor > 0 && transferencia.NConta != null)
            {
                foreach(Conta conta in listaDeContas)
                {
                    if(transferencia.NConta == conta.Numero)
                    {
                        ContaAtual.Transferencia(conta, transferencia.Valor);
                        break;
                    }
                }
                AtualizaTela();
            }
        }

        private void lblPIX_DoubleClick(object sender, EventArgs e)
        {
            ContaAtual = null;
            Login();
        }
    }
}

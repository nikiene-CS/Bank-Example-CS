using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBank_v2
{
    public class Conta
    {
        public List<string> Logs { get; private set; }

        public string Numero { get; private set; }
        private string Senha { get; set; }
        public double Saldo { get; private set; }
        public Usuario Titular { get; private set; }
        public string Pix { get; private set; }

        public Conta(string numero, string senha, Usuario titular, string pix)
        {
            Numero = numero;
            Titular = titular;
            Senha = senha;
            Pix = pix;
            Logs = new List<string>();
            Saldo = 0;
        }

        public bool SenhaCorreta(string senha)
        {
            return Senha.Equals(senha);
        }

        public void Log(string log)
        {
            Logs.Add(log);
        }


        public bool Deposito (double valor)
        {
            if(valor > 0)
            {
                Saldo += valor;
                Log("Deposito realizado no valor de R$" + valor);
                return true;
            }
            Log("Deposito não realizado!");
            return false;
        }

        public bool Saque (double valor)
        {
            if(valor > 0 && valor <= this.Saldo)
            {
                Saldo -= valor;
                Log("Saque realizado no valor de R$" + valor);
                return true;
            }
            Log("Saque não realizado!");
            return false;
        }

        public void ReceberTransferencia(Conta remetente, double valor)
        {
            Saldo += valor;
            Log("Recebido de " + remetente.Titular.Nome + ", o valor de R$" + valor);
        }

        public bool Transferencia(Conta destinatario, double valor)
        {
            if(valor > 0 && valor <= this.Saldo)
            {
                Saldo -= valor;
                Log("Transferido para " + destinatario.Titular.Nome + ", o valor de R$" + valor);
                destinatario.ReceberTransferencia(this, valor);
                return true;
            }
            return false;
        }

    }
}

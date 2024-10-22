using System;
using System.Windows;
using trab.Controller;

namespace trab
{
    public partial class TransacaoWindow : Window
    {
        private BancoController bancoController;

        public TransacaoWindow(BancoController controller)
        {
            InitializeComponent();
            bancoController = controller;
        }

        private void btnDepositar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroConta = int.Parse(txtNumeroConta.Text);
                double valor = double.Parse(txtValor.Text);
                bancoController.Depositar(numeroConta, valor);
                MessageBox.Show("Depósito realizado com sucesso!");
                AtualizarSaldo(numeroConta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnSacar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroConta = int.Parse(txtNumeroConta.Text);
                double valor = double.Parse(txtValor.Text);
                bancoController.Sacar(numeroConta, valor);
                MessageBox.Show("Saque realizado com sucesso!");
                AtualizarSaldo(numeroConta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnTransferir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int contaOrigem = int.Parse(txtContaOrigem.Text);
                int contaDestino = int.Parse(txtContaDestino.Text);
                double valor = double.Parse(txtValor.Text);
                bancoController.Transferir(contaOrigem, contaDestino, valor);
                MessageBox.Show("Transferência realizada com sucesso!");
                AtualizarSaldo(contaOrigem);
                AtualizarSaldo(contaDestino);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void AtualizarSaldo(int numeroConta)
        {
            var conta = bancoController.BuscarConta(numeroConta);
            if (conta != null)
            {
                txtSaldoInfo.Text = $"Saldo: R$ {conta.Saldo:F2}";
            }
        }
    }
}

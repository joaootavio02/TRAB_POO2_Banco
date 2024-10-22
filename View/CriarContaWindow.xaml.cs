using System;
using System.Windows;
using trab.Controller;
using trab.Model;
using trab.Model.trab.Models;

namespace trab
{
    public partial class CriarContaWindow : Window
    {
        private BancoController bancoController;

        public CriarContaWindow(BancoController controller)
        {
            InitializeComponent();
            bancoController = controller;
        }

        private void btnCriarConta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = txtNomeCliente.Text;
                string cpf = txtCPFCliente.Text;
                int numeroConta = int.Parse(txtNumeroNovaConta.Text);

                if (bancoController.BuscarConta(numeroConta) != null)
                {
                    MessageBox.Show("Erro: Já existe uma conta com esse número!");
                    return;
                }

                Cliente cliente = new Cliente(nome, cpf);

                if (cmbTipoConta.SelectedItem.ToString().Contains("Corrente"))
                {
                    ContaCorrente contaCorrente = new ContaCorrente(numeroConta, cliente);
                    bancoController.AdicionarConta(contaCorrente);
                }
                else if (cmbTipoConta.SelectedItem.ToString().Contains("Poupança"))
                {
                    Poupanca poupanca = new Poupanca(numeroConta, cliente, 0.05); // Exemplo com taxa de juros de 5%
                    bancoController.AdicionarConta(poupanca);
                }

                MessageBox.Show("Conta criada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar conta: {ex.Message}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
                string cpf = txtCPF.Text;
                string senha = txtSENHA.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(txtCPF.Text == "015")
            {
            NavigationService.Navigate(new AreaDeCompra());
            }
            else
            {
                MessageBox.Show("Você não tem uma conta");
                
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cadastro());
        }
    }
}

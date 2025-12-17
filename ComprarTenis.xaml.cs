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
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para ComprarTenis.xam
    /// </summary>
    public partial class ComprarTenis : Page
    {
        private int tamanhoSelecionado = 0;
        private Button botaoSelecionado = null;

        public ComprarTenis()
        {
            InitializeComponent();
        }

        private void SelecionarTamanho_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            // Reseta visual do botão anterior
            if (botaoSelecionado != null)
            {
                botaoSelecionado.Background = Brushes.Black;
                botaoSelecionado.Foreground = Brushes.White;
            }

            // Marca o novo botão como selecionado
            btn.Background = new SolidColorBrush(Color.FromRgb(180, 215, 255)); // azul claro
            btn.Foreground = Brushes.Black;

            botaoSelecionado = btn;

            // guarda o tamanho
            tamanhoSelecionado = int.Parse(btn.Tag.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AreaDeCompra());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());

        }
    }
}
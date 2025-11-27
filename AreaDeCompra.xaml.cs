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
    /// Interação lógica para AreaDeCompra.xam
    /// </summary>
    public partial class AreaDeCompra : Page
    {
        public Item Produto;

        public AreaDeCompra()
        {
            InitializeComponent();
        }
        private void SetProduto(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var tag = btn.Tag.ToString();

            Produto = new Item("100241", 449.90, int.Parse(tag));
        }

        private void btnAdicionarCarrinho_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FinalizarCompra(Produto));
        }

    }
}

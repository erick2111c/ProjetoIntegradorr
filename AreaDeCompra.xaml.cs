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
using System.Windows.Media.Animation;
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
        public List<Button> Btns = new List<Button>();

        public AreaDeCompra()
        {
            InitializeComponent();
            Btns.Add(this.btn33);
            Btns.Add(this.btn34);
            Btns.Add(this.btn35);
            Btns.Add(this.btn36);
            Btns.Add(this.btn37);
            Btns.Add(this.btn38);
            Btns.Add(this.btn39);
            Btns.Add(this.btn40);
            Btns.Add(this.btn41);
            Btns.Add(this.btn42);
            Btns.Add(this.btn43);
        }
        private void SetProduto(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            foreach (Button bt in Btns)
            {
                if (btn != bt)
                {
                    bt.BorderBrush = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    bt.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }

            var tag = btn.Tag.ToString();

            Produto = new Item(0011, btn.Name, "dewcrição", 449.90, 1, "Branco", int.Parse(tag),449.90);
        }

        private void btnAdicionarCarrinho_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PedidoConcluido());
        }

    }
}

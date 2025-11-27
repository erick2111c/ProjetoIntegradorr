using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

    }

    public class Item
    {
        public string Codigo;
        public double Valor;
        public int Tamanho;

        public Item(string codigo, double valor, int tamanho)
        {
            Codigo=codigo;
            Valor=valor;
            Tamanho=tamanho;
        }
    }

}

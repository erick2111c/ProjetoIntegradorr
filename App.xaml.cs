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
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public double ValorUn { get; set; }
        public int Quantidade { get; set; }
        public string Cor { get; set; }
        public int Tam { get; set; }
        public double ValorTotal { get; set; }

        internal Item(int id, string nome, string descricao, double valorUn, int quantidade, string cor, int tamanho, double valorTotal)
        {
            Id = id;
            Produto=nome;
            Descricao=descricao;
            ValorUn=valorUn;
            Quantidade=quantidade;
            Cor=cor;
            Tam=tamanho;
            ValorTotal = valorTotal;
        }
    }

}


using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para gerencimaneto.xam
    /// </summary>
    public partial class gerencimaneto : Page
    {
        public MySqlConnection Conexao { get; set; }
        public gerencimaneto()
        {
            InitializeComponent();

            try
            {
                var sql = "server=localhost;user=root;pwd=root;database=estoque";
                if (Conexao == null)
                {
                    Conexao = new MySqlConnection(sql);
                    Conexao.Open();
                }
            }
            catch (Exception ex)
            {
                Conexao = null;
                MessageBox.Show(ex.Message);
            }


            var estoque = new List<Item>();

            var sqlSelect = "SELECT * FROM produtos";
            MySqlCommand cmd = new MySqlCommand(sqlSelect, Conexao);
            var reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    var id = reader["Id"].ToString();
                    var nome = reader["Nome"].ToString();
                    var desc = reader["Descricao"].ToString();
                    var valorUn = reader["ValorUn"].ToString();
                    var quant = reader["Quantidade"].ToString();
                    var cor = reader["cor"].ToString();
                    var tamanho = reader["Tamanho"].ToString();

                    var valorTotal = double.Parse(valorUn) * int.Parse(quant);

                    estoque.Add(new Item(int.Parse(id), nome, desc, double.Parse(valorUn), int.Parse(quant), cor, int.Parse(tamanho), valorTotal));
                }
            }
            dgEstoque.ItemsSource = estoque;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conexao.Close();
            NavigationService.Navigate(new Home());

        }
    }

    //internal class Item
    //{
    //    public string Nome { get; set; }
    //    public string Descricao { get; set; }
    //    public decimal ValorUn { get; set; }
    //    public int Quantidade { get; set; }
    //    public string Cor { get; set; }
    //    public int Tam { get; set; }
    //    internal Item(string nome, string descricao, decimal valorUn, int quantidade, string cor, int tamanho)
    //    {
    //        Nome=nome;
    //        Descricao=descricao;
    //        ValorUn=valorUn;
    //        Quantidade=quantidade;
    //        Cor=cor;
    //        Tam=tamanho;
    //    }
    //}
}

using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

            CarregarEstoque();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conexao.Close();
            NavigationService.Navigate(new Home());

        }

        private void CarregarEstoque()
        {
            var sqlSelect = "SELECT * FROM produtos ORDER BY Id";
            MySqlCommand cmd = new MySqlCommand(sqlSelect, Conexao);
            var reader = cmd.ExecuteReader();

            var estoque = new List<Item>();
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

                    double valor = Math.Round(double.Parse(valorUn, new CultureInfo("pt-BR")), 3);
                    var valorTotal = valor * int.Parse(quant);

                    estoque.Add(new Item(int.Parse(id), nome, desc, valor, int.Parse(quant), cor, int.Parse(tamanho), valorTotal));
                }
                reader.Close();
            }
            dgEstoque.ItemsSource = estoque;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            var estoque = new List<Item>();
            var sql = "DELETE FROM produtos WHERE id = @id";
            var curId = (Item)dgEstoque.SelectedItem;
            using (MySqlCommand cmd = new MySqlCommand(sql, Conexao))
            {
                cmd.Parameters.AddWithValue("@id", curId.Id);
                cmd.ExecuteNonQuery();
            }

            CarregarEstoque();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var sqlUpdate = @"UPDATE produtos 
                  SET Nome = @nome,
                      Descricao = @descricao,
                      ValorUn = @valor,
                      Quantidade = @quantidade,
                      Cor = @cor,
                      Tamanho = @tamanho
                  WHERE Id = @id";

            var item = (Item)dgEstoque.SelectedItem;

            using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, Conexao))
            {
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@nome", item.Produto);
                cmd.Parameters.AddWithValue("@descricao", item.Descricao);
                cmd.Parameters.AddWithValue("@valor", item.ValorUn);
                cmd.Parameters.AddWithValue("@quantidade", item.Quantidade);
                cmd.Parameters.AddWithValue("@cor", item.Cor);
                cmd.Parameters.AddWithValue("@tamanho", item.Tam);

                cmd.ExecuteNonQuery(); // EXECUTA O UPDATE
            }
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
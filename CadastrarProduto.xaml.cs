using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interação lógica para ControleEstoque.xam
    /// </summary>
    public partial class CadastrarProduto : Page
    {
        public MySqlConnection Conexao { get; set; }

        public CadastrarProduto()
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("Tênis Cadastrado!");
            var sql = $"INSERT INTO produtos (Nome,Descricao,ValorUn,Quantidade,Cor,Tamanho,) VALUES (@nome, @descricao,@valorun,@quantidade, @cor, @tamanho)";
            try
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, Conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", prod.Text);
                        cmd.Parameters.AddWithValue("@descricao", DESC.Text);
                        cmd.Parameters.AddWithValue("@valorun", prec.Text);
                        cmd.Parameters.AddWithValue("@quantidade", quant.Text);
                        cmd.Parameters.AddWithValue("@cor", corr.Text);
                        cmd.Parameters.AddWithValue("@tamanho", tamanh.Text);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Conexao != null && Conexao.State == System.Data.ConnectionState.Open)
            {
                Conexao.Close();
            }
            NavigationService.Navigate(new gerencimaneto());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CadastrarProduto());
        }
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interação lógica para Cadastro.xam
    /// </summary>
    public partial class Cadastro : Page
    {
        public MySqlConnection Conexao { get; set; }

        public Cadastro()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = "server=localhost;user=root;pwd=root;database=estoque";
                if (Conexao == null)
                {
                    Conexao = new MySqlConnection(db);
                    Conexao.Open();
                }
            }
            catch (Exception ex)
            {
                Conexao = null;
                MessageBox.Show(ex.Message);
            }

            var sql = $"INSERT INTO usuarios (Nome,Email,Telefone,Senha) VALUES (@nome, @email, @telefone, @senha)";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, Conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", tb_Nome.Text);
                    cmd.Parameters.AddWithValue("@email", tb_Email.Text);
                    cmd.Parameters.AddWithValue("@telefone", tb_Telefone.Text);
                    cmd.Parameters.AddWithValue("@senha", tb_Senha.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User Cadastrado!");
                }
            }
            catch (Exception ex) { }

            NavigationService.Navigate(new ComprarTenis());
        }
    }
}

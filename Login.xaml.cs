using MySql.Data.MySqlClient;
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
        public MySqlConnection Conexao { get; set; }

        public Login()
        {
            InitializeComponent();
            Loaded += TelaInicial_Loaded;
        }

        private void TelaInicial_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Maximized;
                window.WindowStyle = WindowStyle.None;
                window.ResizeMode = ResizeMode.NoResize;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCPF.Text) && !string.IsNullOrEmpty(txtSENHA.Text))
            {
                if (txtCPF.Text == "adm" && txtSENHA.Text == "adm")
                {
                    NavigationService.Navigate(new Home());
                    return;
                }

                try
                {
                    var db = "server=localhost;user=root;pwd=root;database=estoque";
                    if (Conexao == null)
                    {
                        Conexao = new MySqlConnection(db);
                        Conexao.Open();

                        var sql = $"SELECT Email,Senha FROM usuarios";
                        MySqlCommand cmd = new MySqlCommand(sql, Conexao);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        var podeLogar = false;
                        while (reader.Read())
                        {
                            var email = reader["Email"].ToString();
                            var senha = reader["Senha"].ToString();

                            if (txtCPF.Text == email && txtSENHA.Text == senha)
                            {
                                podeLogar = true;

                            }
                        }
                        reader.Close();

                        if (podeLogar)
                        {
                            NavigationService.Navigate(new ComprarTenis());
                        }
                        else
                        {
                            MessageBox.Show("Você não tem uma conta");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Conexao.Close();
                    Conexao = null;
                    MessageBox.Show(ex.Message);
                }
                Conexao.Close();
                Conexao = null;
            }
            else
            {
                MessageBox.Show("Digiteee");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cadastro());
        }
    }
}

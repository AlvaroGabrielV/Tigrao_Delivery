using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Tigrao_Delivery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=sistema;UID=root;Pwd=";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM usuarios WHERE Usuario = @usuario AND Senha = @senha";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login realizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message);
            }
        }

    }
}

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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=sistema;UID=root;Pwd=";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO funcionarios (Usuario, Senha, Email) VALUES (@usuario, @senha, @email)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    //cmd.ExecuteNonQuery();

                    MessageBox.Show("Cadastro realizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }
    }
}
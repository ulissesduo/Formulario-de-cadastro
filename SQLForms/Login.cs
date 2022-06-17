using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SQLForms
{
    public partial class Login : Form
    {
        MySqlConnection objcon = new MySqlConnection("server=127.0.0.1;port=3306;User Id=usuario;database=sqlform;password=123987456");
        

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection objcon = new MySqlConnection("server=127.0.0.1;port=3306;User Id=usuario;database=sqlform;password=123987456");
            objcon.Open();
            MySqlCommand objCmd = new MySqlCommand("select login, senha from tb_dados where login=@login AND senha=@senha", objcon);
            objCmd.Parameters.AddWithValue("login", txtLogin.Text);
            objCmd.Parameters.AddWithValue("senha", txtSenha.Text);
            MySqlDataReader dr = objCmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Bem-Vindo!!");
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos.");
            }
        }

        private void btnCadastrese_Click(object sender, EventArgs e)
        {
            Cadastro add = new Cadastro();
            add.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cadastro add = new Cadastro();
            add.ShowDialog();
        }
    }
}

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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server=127.0.0.1;port=3306;User Id=usuario;database=sqlform;password=123987456");
                objcon.Open();

                MySqlCommand objCmd = new MySqlCommand("select login from tb_dados where login=@login", objcon);
                objCmd.Parameters.AddWithValue("login", txtLogin.Text);
                objCmd.Parameters.AddWithValue("senha", txtSenha.Text);
                MySqlDataReader dr = objCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Login já está sendo utilizado!");
                }
                else
                {
                    objcon = new MySqlConnection("server=127.0.0.1;port=3306;User Id=usuario;database=sqlform;password=123987456");
                    objcon.Open();

                    objCmd = new MySqlCommand("INSERT INTO tb_dados(nome, login, senha) values(@nome, @login, @senha)", objcon);

                    objCmd.Parameters.Add("@nome", MySqlDbType.VarChar, 30).Value = txtNome.Text;
                    objCmd.Parameters.Add("@login", MySqlDbType.VarChar, 30).Value = txtLogin.Text;
                    objCmd.Parameters.Add("@senha", MySqlDbType.VarChar, 30).Value = txtSenha.Text;

                    objCmd.ExecuteNonQuery();

                    MessageBox.Show("Cadastro realizado!");
                    objcon.Clone();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro");
            }
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login1 = new Login();
            login1.Show();
        }

        private MySqlDataReader MySqlDataReader()
        {
            throw new NotImplementedException();
        }
            
        private void btnSelect_Click(object sender, EventArgs e)
        {
            MySqlConnection objcon = new MySqlConnection("server=127.0.0.1;port=3306;User Id=usuario;database=sqlform;password=123987456");
            objcon.Open();
            MySqlCommand objCmd = new MySqlCommand("select * from tb_dados", objcon);
            objCmd.Parameters.AddWithValue("nome", txtNome.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(objCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection objcon = new MySqlConnection("server=127.0.0.1;port=3306;User Id=usuario;database=sqlform;password=123987456");
            objcon.Open();
            MySqlCommand objCmd = new MySqlCommand("delete from tb_dados where nome=@nome AND login=@login AND senha=@senha", objcon);
            objCmd.Parameters.AddWithValue("nome", txtNome.Text);
            objCmd.Parameters.AddWithValue("login", txtLogin.Text);
            objCmd.Parameters.AddWithValue("senha", txtSenha.Text);
            objCmd.ExecuteNonQuery();
            objcon.Close();
            MessageBox.Show("Deletado com sucesso");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection objcon = new MySqlConnection("server=127.0.0.1;port=3306;User Id=usuario;database=sqlform;password=123987456");
            objcon.Open();

            MySqlCommand objCmd = new MySqlCommand("UPDATE tb_dados SET senha=@senha where nome=@nome AND login=@login", objcon);
            objCmd.Parameters.AddWithValue("nome", txtNome.Text);
            objCmd.Parameters.AddWithValue("login", txtLogin.Text);
            objCmd.Parameters.AddWithValue("senha", txtSenha.Text);

            objCmd.ExecuteNonQuery();
            objcon.Clone();

            MessageBox.Show("Senha alterada");
        }
    }
}

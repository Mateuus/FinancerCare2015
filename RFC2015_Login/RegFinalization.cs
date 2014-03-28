using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Web;
using System.Net.Mail;

namespace RFC2015_Login
{
    public partial class RegFinalization : Form
    {
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        public RegFinalization()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CADASTRO ///////////////////////////////////////////////////////////////////////////////
            cep.Text = textBox6.Text + "-" + textBox10.Text;

            // Início da Conexão com indicação de qual o servidor, nome de base de dados e utilizar

            /* É aconselhável criar um utilizador com password. Para acrescentar a password é somente
            necessário acrescentar o seguinte código a seguir ao uid=root;password=xxxxx*/

            mConn = new MySqlConnection("Server=undeadbrasil.com; Database=undeadbr_refresh; Uid=undeadbr_test; Pwd=27091995");

            // Abre a conexão
            mConn.Open();

            //Query SQL
            MySqlCommand command = new MySqlCommand("INSERT INTO accounts (email,password,nomeempresa,nome,cep,accounttype,licensetype,serialkey,datacadastro)" +
            "VALUES('" + email.Text + "','" + password.Text + "','" + nomeempresa.Text + "','" + nome.Text + "','" + cep.Text + "','" + accounttype.Text + "','" + licensetype.Text + "','" + serialkey.Text + "','" + datacadastro.Text + "')", mConn);

            //Executa a Query SQL
            command.ExecuteNonQuery();

            // Fecha a conexão
            mConn.Close();

            //Mensagem de Sucesso
            Fim fim = new Fim();
            fim.Show();
            Hide();
            /////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void RegFinalization_Load(object sender, EventArgs e)
        {
            datacadastro.Text = DateTime.Now.Date.ToString();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = SystemColors.ButtonFace;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
    }
}

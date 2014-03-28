using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RFC2015_Login
{
    public partial class RegWithKey : Form
    {
        public RegWithKey()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidaSerial(string serialkey)
        {
            //variável que será testada para
            //informar o retorno
            int retorno = -1;
            ////instância da cocexão
            MySqlConnection conn = new MySqlConnection("Server=undeadbrasil.com; Database=undeadbr_refresh; Uid=undeadbr_test; Pwd=27091995");
            //comando sql que dá um count 
            //na tabela se existirem usuario e senha
            //com os dados informados
            string comando = "SELECT COUNT(*) FROM RFC2015Serials WHERE serialkey=@serialkey";
            //instância do comando
            MySqlCommand cmd = new MySqlCommand(comando, conn);
            //preenchimento dos parâmetros
            cmd.Parameters.AddWithValue("@serialkey", serialkey);
            //abro conexão
            conn.Open();
            //retorno recebe o resultado do execute scalar
            retorno = Convert.ToInt32(cmd.ExecuteScalar());
            //fecho conexão
            conn.Close();
            //retorno true se retorno for maior que zero
            return retorno > 0;
         }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Server=undeadbrasil.com; Database=undeadbr_refresh; Uid=undeadbr_test; Pwd=27091995");

            if (ValidaSerial(serialkey.Text))
            {
                if (label5.Text == "0")
                {
                    string comando = @"UPDATE RFC2015Serials SET serialused='" + label4.Text + "' WHERE serialKey='" + serialkey.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(comando, conn);
                    conn.Open();
                    cmd.ExecuteScalar();
                    conn.Close();

                    RegFinalization regfim = new RegFinalization();
                    regfim.Show();
                    Hide();
                    

                }
                else
                {
                    
                }
            }
            else
            {
                
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = SystemColors.ButtonFace;


        }
    }
}

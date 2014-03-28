using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net;
using System.Reflection;
using System.Management;


namespace RFC2015_Login
{
    public partial class Form1 : Form
    {
        
        //GITHUB
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Email")
            {
                textBox1.Text = "";
            }
            else
            {

            }
            
            
            Background1.BackColor = SystemColors.ButtonFace;
            fillet1.BackColor = Color.SteelBlue;

            background2.BackColor = Color.Transparent;
            fillet2.BackColor = Color.Transparent;
            
            background2.BorderStyle = BorderStyle.None;
            fillet2.BorderStyle = BorderStyle.None;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Senha")
            {
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {

            }

            

            background2.BackColor = SystemColors.ButtonFace;
            fillet2.BackColor = Color.SteelBlue;

            Background1.BackColor = Color.Transparent;
            fillet1.BackColor = Color.Transparent;

            Background1.BorderStyle = BorderStyle.None;
            fillet1.BorderStyle = BorderStyle.None;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            

            // inicia parametros do progressbar01
            timer1.Enabled = true;
            timer1.Start();

            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;
            }
            else
            {

                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private bool ValidaUsuario(string email, string password)
        {
            //variável que será testada para
            //informar o retorno
            int retorno = -1;
            ////instância da cocexão
            MySqlConnection conn = new MySqlConnection("Server=undeadbrasil.com; Database=undeadbr_refresh; Uid=undeadbr_test; Pwd=27091995");
            //comando sql que dá um count 
            //na tabela se existirem usuario e senha
            //com os dados informados
            string comando = "SELECT COUNT(*) FROM accounts WHERE email=@email AND password=@password";
            //instância do comando
            MySqlCommand cmd = new MySqlCommand(comando, conn);
            //preenchimento dos parâmetros
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            //abro conexão
            conn.Open();
            //retorno recebe o resultado do execute scalar
            retorno = Convert.ToInt32(cmd.ExecuteScalar());
            //fecho conexão
            conn.Close();
            //retorno true se retorno for maior que zero
            return retorno > 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = SystemColors.ButtonFace;
        }
              

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.SteelBlue;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterChoise reg = new RegisterChoise();
            reg.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;

            }
            else
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.TimeOfDay.ToString();
            label10.Text = DateTime.Today.Date.ToString();
        }


        int timeleft = 2;
        private void timer3_Tick(object sender, EventArgs e)
        {
            

            if (timeleft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeleft = timeleft - 1;
                label11.Text = timeleft + " seconds";
            }
            else
            {

                timer3.Stop();
                timer3.Enabled = false;

                

                // inicia parametros do progressbar01
                timer1.Enabled = true;
                timer1.Start();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // reseta campos ////////////////////////////////////////////////////////////////////////////

            label2.Visible = false;
            progressBar1.Value = 0;

            /////////////////////////////////////////////////////////////////////////////////////////////


            if (ValidaUsuario(textBox1.Text, textBox2.Text))
            {
                // Diretorios ///////////////////////////////////////////////////////////////////////////

                string InstalationPath = @"C:\Refresh\Refresh Financer Care 2015";
                string Bin64Path = @"C:\Refresh\Refresh Financer Care 2015\Bin64";
                string Bin32Path = @"C:\Refresh\Refresh Financer Care 2015\Bin32";
                string DocsPath = @"C:\Refresh\Refresh Financer Care 2015\Docs";

                /////////////////////////////////////////////////////////////////////////////////////////



                // Arquivos /////////////////////////////////////////////////////////////////////////////

                string LastLogin = @"C:\Refresh\Refresh Financer Care 2015\LastLogin.txt";
                string HardwareSpecs = @"C:\Refresh\Refresh Financer Care 2015\Hardware Specs.txt";

                /////////////////////////////////////////////////////////////////////////////////////////



                // Url´s ////////////////////////////////////////////////////////////////////////////////

                //executaveis ---------------------------------------------------------------

                string remoteUri = "https://github-windows.s3.amazonaws.com/GitHubSetup.exe";

                //////////////////////////////////////////////////////////////////////////////////////////



                // CRIA CAMINHOS /////////////////////////////////////////////////////////////////////////

                if (!Directory.Exists(InstalationPath))
                    Directory.CreateDirectory(InstalationPath);

                if (!Directory.Exists(Bin64Path))
                    Directory.CreateDirectory(Bin64Path);

                if (!Directory.Exists(Bin32Path))
                    Directory.CreateDirectory(Bin32Path);

                if (!Directory.Exists(DocsPath))
                    Directory.CreateDirectory(DocsPath);

                ///////////////////////////////////////////////////////////////////////////////////////////



                // LOGS ///////////////////////////////////////////////////////////////////////////////////

                // LAST LOGIN -----------------------------------------------------------------------------

                System.IO.File.Create(LastLogin).Close();

                System.IO.TextWriter arquivo = System.IO.File.AppendText(LastLogin);
                arquivo.WriteLine("LoginTime:" + label9.Text);
                arquivo.WriteLine("LoginDate:" + label10.Text);
                arquivo.WriteLine("LastUserLogin: " + textBox1.Text);
                arquivo.Close();

                // HARDWARE SPECS--------------------------------------------------------------------------

                ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

                foreach (ManagementObject mo in s2.Get())
                    Console.WriteLine("Processador: {0}", mo["Name"]);


                ManagementObjectSearcher objMOS = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM  Win32_BaseBoard");

                foreach (ManagementObject objManagemnet in objMOS.Get())
                {
                    try
                    {

                        System.IO.TextWriter arquivo2 = System.IO.File.AppendText(HardwareSpecs);
                        arquivo2.WriteLine("====================================================================================");
                        arquivo2.WriteLine("                Detalhes da Placa Mãe                                 ");
                        arquivo2.WriteLine("====================================================================================");
                        arquivo2.WriteLine("Caption             :" + objManagemnet.GetPropertyValue("Caption").ToString());
                        arquivo2.WriteLine("CreationClassName   :" + objManagemnet.GetPropertyValue("CreationClassName").ToString());
                        arquivo2.WriteLine("Description         :" + objManagemnet.GetPropertyValue("Description").ToString());
                        arquivo2.WriteLine("InstallDate         :" + Convert.ToDateTime(objManagemnet.GetPropertyValue("InstallDate")));
                        arquivo2.WriteLine("Manufacturer        :" + objManagemnet.GetPropertyValue("Manufacturer").ToString());
                        arquivo2.WriteLine("Model               :" + Convert.ToString(objManagemnet.GetPropertyValue("Model")));
                        arquivo2.WriteLine("Name                :" + objManagemnet.GetPropertyValue("Name").ToString());
                        arquivo2.WriteLine("PartNumber          :" + Convert.ToInt32(objManagemnet.GetPropertyValue("PartNumber")));
                        arquivo2.WriteLine("PoweredOn           :" + objManagemnet.GetPropertyValue("PoweredOn").ToString());
                        arquivo2.WriteLine("Product             :" + objManagemnet.GetPropertyValue("Product").ToString());
                        arquivo2.WriteLine("SerialNumber        :" + objManagemnet.GetPropertyValue("SerialNumber").ToString());
                        arquivo2.WriteLine("SKU                 :" + Convert.ToString(objManagemnet.GetPropertyValue("SKU")));
                        arquivo2.WriteLine("Status              :" + Convert.ToString(objManagemnet.GetPropertyValue("Status")));
                        arquivo2.WriteLine("Tag                 :" + Convert.ToString(objManagemnet.GetPropertyValue("Tag")));
                        arquivo2.WriteLine("Version             :" + Convert.ToString(objManagemnet.GetPropertyValue("Version")));
                        arquivo2.WriteLine("Weight              :" + Convert.ToString(objManagemnet.GetPropertyValue("Weight")));
                        arquivo2.WriteLine("Height              :" + Convert.ToString(objManagemnet.GetPropertyValue("Height")));
                        arquivo2.WriteLine("PoweredOn           :" + Convert.ToString(objManagemnet.GetPropertyValue("PoweredOn")));
                        arquivo2.WriteLine("=====================================================================================");
                        arquivo2.WriteLine("DADOS ADQUIRIDOS E ARMAZENADOS DE ACORDO COM OS TERMOS DE LICENÇA PRÉ-ESTABELECIDOS");
                        arquivo2.WriteLine("=====================================================================================");
                        arquivo2.WriteLine("BY REFRESH FINANCER CARE 2015");
                        arquivo2.WriteLine("");
                        arquivo2.WriteLine("");
                        arquivo2.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao gravar dados da placa mãe");
                    }
                }

                //-----------------------------------------------------------------------------------------

                ///////////////////////////////////////////////////////////////////////////////////////////



                ////////////////////////////////////////////////////////////////////////////////////////////



                // DOWNLOADS ///////////////////////////////////////////////////////////////////////////////

                // DOWNLOAD DOS ARQUIVOS--------------------------------------------------------------------

                string fileName = Bin32Path + @"\RFC_2015.exe";

                // Verfica a existencia do arquivo /////////////////////////////////////////////////////////
                if (File.Exists(fileName))
                {
                    

                    timer3.Enabled = true;
                    timer3.Start();



                }
                else
                {
                    // se o arquivo n existir, então se inicia o download //////////////////////////////////
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(remoteUri), Bin32Path + @"\RFC_2015.exe");
                }


                ////////////////////////////////////////////////////////////////////////////////////////////


            }
            else
            {
                //  AÇÃO AO ERRO DE LOGIN //////////////////////////////////////////////////////////////////

                label2.Text = "Usuário ou senha invalidos";
                label2.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";

                ////////////////////////////////////////////////////////////////////////////////////////////
            }


            
           
            

            

        }

        

        

        

        

        
        

        
    }
}

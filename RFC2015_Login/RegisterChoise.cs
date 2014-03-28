using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFC2015_Login
{
    public partial class RegisterChoise : Form
    {
        public RegisterChoise()
        {
            InitializeComponent();
        }

        private void Background1_MouseHover(object sender, EventArgs e)
        {
            Background1.BackColor = SystemColors.ButtonFace;
            fillet1.BackColor = Color.SteelBlue;

            background2.BackColor = Color.Transparent;
            fillet2.BackColor = Color.Transparent;

            background2.BorderStyle = BorderStyle.None;
            fillet2.BorderStyle = BorderStyle.None;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            Background1.BackColor = SystemColors.ButtonFace;
            fillet1.BackColor = Color.SteelBlue;

            background2.BackColor = Color.Transparent;
            fillet2.BackColor = Color.Transparent;

            background2.BorderStyle = BorderStyle.None;
            fillet2.BorderStyle = BorderStyle.None;
        }

        private void fillet1_MouseHover(object sender, EventArgs e)
        {
            Background1.BackColor = SystemColors.ButtonFace;
            fillet1.BackColor = Color.SteelBlue;

            background2.BackColor = Color.Transparent;
            fillet2.BackColor = Color.Transparent;

            background2.BorderStyle = BorderStyle.None;
            fillet2.BorderStyle = BorderStyle.None;
        }

        private void background2_MouseHover(object sender, EventArgs e)
        {
            background2.BackColor = SystemColors.ButtonFace;
            fillet2.BackColor = Color.SteelBlue;

            Background1.BackColor = Color.Transparent;
            fillet1.BackColor = Color.Transparent;

            Background1.BorderStyle = BorderStyle.None;
            fillet1.BorderStyle = BorderStyle.None;
        }

        private void fillet2_MouseHover(object sender, EventArgs e)
        {
            background2.BackColor = SystemColors.ButtonFace;
            fillet2.BackColor = Color.SteelBlue;

            Background1.BackColor = Color.Transparent;
            fillet1.BackColor = Color.Transparent;

            Background1.BorderStyle = BorderStyle.None;
            fillet1.BorderStyle = BorderStyle.None;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            background2.BackColor = SystemColors.ButtonFace;
            fillet2.BackColor = Color.SteelBlue;

            Background1.BackColor = Color.Transparent;
            fillet1.BackColor = Color.Transparent;

            Background1.BorderStyle = BorderStyle.None;
            fillet1.BorderStyle = BorderStyle.None;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = SystemColors.ButtonFace;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            RegWithKey regwithkey = new RegWithKey();
            regwithkey.Show();
            Hide();
        }

        

        

        

        
    }
}

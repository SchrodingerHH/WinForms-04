using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form form_game = new Form();

            form_game.Width = 1400;
            form_game.Height = 700;
            form_game.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            form_game.Show();
            Game.Init(form_game);
            Game.Draw();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
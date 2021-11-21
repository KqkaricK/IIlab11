using System;
using System.Windows.Forms;

namespace IIlab11
{
    public partial class Copyraight : Form
    {
        public Copyraight()
        {
            InitializeComponent();
        }

        private void Copyraight_Load(object sender, EventArgs e)
        {
            label1.Text = "  *на полу лужа крови*\n  << Похоже, тут кто-то ударился мизинчиком. >>\n\n                                              — Cyberpunk 2077";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kqkarick");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kqkarick");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default;
        }
    }
}

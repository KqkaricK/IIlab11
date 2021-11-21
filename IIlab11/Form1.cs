using System;
using System.Drawing;
using System.Windows.Forms;

namespace IIlab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] y = new int[100];

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 10;
            dataGridView1.ColumnCount = 10;
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.White)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Black;
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Black)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (dataGridView1.Rows[j].Cells[i].Style.BackColor == Color.White)
                    {
                        y[k] = -1;
                    }
                    else if (dataGridView1.Rows[j].Cells[i].Style.BackColor == Color.Black)
                    {
                        y[k] = 1;
                    }
                    k++;
                }
            }
            Bitmap bmp1 = new Bitmap(Image.FromFile("1.png"));
            Bitmap bmp2 = new Bitmap(Image.FromFile("2.png"));
            Bitmap bmp3 = new Bitmap(Image.FromFile("3.png"));
            Bitmap bmp4 = new Bitmap(Image.FromFile("4.png"));
            Bitmap bmp5 = new Bitmap(Image.FromFile("5.png"));
            Bitmap bmp6 = new Bitmap(Image.FromFile("6.png"));
            Bitmap bmp7 = new Bitmap(Image.FromFile("7.png"));
            Bitmap bmp8 = new Bitmap(Image.FromFile("8.png"));
            Bitmap bmp9 = new Bitmap(Image.FromFile("9.png"));
            Bitmap bmp10 = new Bitmap(Image.FromFile("10.png"));
            double[] x1 = new double[100];
            double[] x2 = new double[100];
            double[] x3 = new double[100];
            double[] x4 = new double[100];
            double[] x5 = new double[100];
            double[] x6 = new double[100];
            double[] x7 = new double[100];
            double[] x8 = new double[100];
            double[] x9 = new double[100];
            double[] x10 = new double[100];
            bitmp(bmp1, x1);
            bitmp(bmp2, x2);
            bitmp(bmp3, x3);
            bitmp(bmp4, x4);
            bitmp(bmp5, x5);
            bitmp(bmp6, x6);
            bitmp(bmp7, x7);
            bitmp(bmp8, x8);
            bitmp(bmp9, x9);
            bitmp(bmp10, x10);
            double[] w = new double[100];
            for (k = 0; k <= 99; k++)
            {
                w[k] = 0.1 * x1[k];
            }
            sum(w, x2);
            sum(w, x3);
            sum(w, x4);
            sum(w, x5);
            sum(w, x6);
            sum(w, x7);
            sum(w, x8);
            sum(w, x9);
            sum(w, x10);
            double[] ys = new double[100];
            for (k = 0; k <= 99; k++)
            {
                ys[k] =  y[k] * w[k];
            }
            for (k = 0; k <= 99; k++)
            {
                if (ys[k] >= 0)
                {
                    ys[k] = 1;
                }
                else
                {
                    ys[k] = -1;
                }
            }
            double r1 = rast(x1, ys);
            double r2 = rast(x2, ys);
            double r3 = rast(x3, ys);
            double r4 = rast(x4, ys);
            double r5 = rast(x5, ys);
            double r6 = rast(x6, ys);
            double r7 = rast(x7, ys);
            double r8 = rast(x8, ys);
            double r9 = rast(x9, ys);
            double r10 = rast(x10, ys);
            listBox1.Items.Add(r1);
            listBox1.Items.Add(r2);
            listBox1.Items.Add(r3);
            listBox1.Items.Add(r4);
            listBox1.Items.Add(r5);
            listBox1.Items.Add(r6);
            listBox1.Items.Add(r7);
            listBox1.Items.Add(r8);
            listBox1.Items.Add(r9);
            listBox1.Items.Add(r10);
            label1.Text = listBox1.Items[0].ToString();
            listBox1.Items.Clear();
            double result = Convert.ToDouble(label1.Text);
            if (result >= 16.6 && result <= 17.6)
            {
                label2.Text = "Yes";
            }
            else
            {
                label2.Text = "No";
            }
        }

        void bitmp(Bitmap x, double[] mas)
        {
            int k = 0;
            for (int i = 0; i < x.Width; i++)
            {
                for (int j = 0; j < x.Height; j++)
                {
                    if (x.GetPixel(i, j) == Color.FromArgb(255, 255, 255))
                    {
                        mas[k] = -1;
                    }
                    else if (x.GetPixel(i, j) == Color.FromArgb(0, 0, 0))
                    {
                        mas[k] = 1;
                    }
                    k++;
                }
            }
        }

        void sum(double[] w, double[] x)
        {
            for (int k = 0; k <= 99; k++)
            {
                w[k] += 0.1 * x[k];
            }
        }
        
        double rast(double[] x, double[] y)
        {
            double r = 0;
            for (int k = 0; k <= 99; k++)
            {
                r += (x[k] - y[k]) * (x[k] - y[k]);
            }
            r = Math.Sqrt(r);
            return r;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                Copyraight C = new Copyraight();
                C.Show();
            }
        }
    }
}

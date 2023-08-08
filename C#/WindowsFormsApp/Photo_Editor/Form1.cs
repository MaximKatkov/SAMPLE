using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private string namefile;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please,install a photo.");
                return;
            }                
            Bitmap screensaver = new Bitmap(namefile);
            pictureBox1.Image = screensaver;
            pictureBox1.Invalidate();
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Random rnd = new Random();
            int c = rnd.Next(200, 255), d = rnd.Next(0,255), f = rnd.Next(0,200);
            //разделим на 20 клеток 

            string w = textBox1.Text;
            string h = textBox2.Text;
            if (w == "0" && h == "0")
            {
                MessageBox.Show("Please,enter the width and height .");
                return;
            }
            int width = Convert.ToInt32(w);
            int height = Convert.ToInt32(h);

            int width1 = width / 20;
            int height1 = height / 20;
            //делим на 100 клеток
            int a = rnd.Next(5, 20);
            int x=0, y=0;

            for (int a1 = 0; a1 < a; a1++)
                {
                    int column = rnd.Next(0, 19);
                    int line = rnd.Next(0, 19);

                    for (int k1 = 0; k1 < 19; k1++)
                        for (int k2 = 0; k2 < 19; k2++)
                        {
                            if (column == k1 && line == k2)
                            {
                                x = width1 * k1;
                                y = height1 * k2;
                                for (int i = x; i < x + width1; i++)
                                    for (int j = y; j < y + height1; j++)
                                    { bmp.SetPixel(i, j, Color.FromArgb(c, d, f)); }
                                pictureBox1.Image = bmp;
                            }
                            else continue;
                        }
                }           
        }
            string getname(string fn)
        {
            namefile = fn;
            return namefile;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
     
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);

                    bmp.SetPixel(x, y, Color.FromArgb(250,250, c.G, c.B));

                }
            pictureBox1.Image = (Bitmap)bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    bmp = new Bitmap(open_dialog.FileName);
                    getname(open_dialog.FileName);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = bmp;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please,install a photo.");
                return;
            }
            Bitmap screensaver = new Bitmap(namefile);
            pictureBox1.Image = screensaver;
            pictureBox1.Invalidate();
        }
    }
    }


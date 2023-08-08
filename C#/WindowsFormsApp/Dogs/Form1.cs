using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dog Dog = new dog("Eva");

            Form2 f2 = new Form2();

            f2.pictureBox1.Image = Properties.Resources.HomeDog;
            f2.pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            Dog.dog_gav("C://file//HomeDog.wav");
            f2.label1.Text = Dog.info();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeDog homedog = new HomeDog("Luccia", "Mom");

            Form2 f2 = new Form2();

            f2.pictureBox1.Image = Properties.Resources.dog;
            f2.pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            homedog.dog_gav("C://file//dog.wav");
            f2.label1.Text=homedog.info();
            f2.Show();

        }
    }
}

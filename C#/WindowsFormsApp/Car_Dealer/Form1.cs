using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           sound sound = new sound();
            sound.soundcar1();

            Form2 f = new Form2();
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sound sound = new sound();
            sound.soundcar1();

            if (File.Exists(@"C:\File_Program\file1.txt"))
            {
                Form3 f = new Form3();
                f.Show();
            }
            else
            {
                MessageBox.Show("file not created");
                return;
            }
        }
    }
}

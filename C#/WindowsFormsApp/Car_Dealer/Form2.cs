using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http.Headers;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        string brend;
        string model;
        double year;
        string mileage;
        static string body;
        string engines_volume;
        double hp;
        static  string engines_type;
        static string transmissions_type;
        static string drive_unit;
        static string rudders_type;

        List<Car> car_list = new List<Car>();

        public Form2()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            sound sound = new sound();
            sound.soundcar3();

            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png";

            if(openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openPicture.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        
        static void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            engines_type = comboBox.SelectedItem.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            sound sound = new sound();
            sound.soundcar2();

            double bid;
            double tax;
            if(textBox6.Text!= String.Empty)
            {
                hp = Convert.ToDouble(textBox6.Text.Replace(',', '.'));
            }
            else
            {
                textBox6.Focus();
                MessageBox.Show("Please ,fill in the file.");
                    return;
            }
            if (hp < 100)
                bid = 12;
            else if (hp > 100 && hp < 125)
                bid = 25;
            else if (hp > 125 && hp < 150)
                bid = 35;
            else if (hp > 150 && hp < 175)
                bid = 45;
            else if (hp > 175 && hp < 200)
                bid = 50;
            else if (hp > 200 && hp < 225)
                bid = 65;
            else if (hp > 225 && hp < 250)
                bid = 75;
            else 
                bid = 150;

            tax = bid * hp;
            textBox7.Text = tax.ToString()+" руб";
        }

       static  void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            transmissions_type = comboBox.SelectedItem.ToString();
            
        }

       static  void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            drive_unit = comboBox.SelectedItem.ToString();
        }

       static  void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            rudders_type = comboBox.SelectedItem.ToString();
        }
      /*  private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != ',')
            
              e.Handled = true;
            
        }
        private void Mileage (object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != ',')

                e.Handled = true;

        }
        private void Engines_volume(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != ',')

                e.Handled = true;

        }
      */
      private void mark_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            textBox7.Text = "";
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            checkBox1.Checked = false;

            string[] enginestype = {" ", "Petrol", "Diesel", "Electrical", "Hybrid" };
            comboBox1.DataSource = enginestype;
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            string[] transmissionstype = {" ", "Manual gearbox", "Automatic gearbox", "Robotic gearbox", "Variable gearbox", "Electrical gearbox" };
            comboBox2.DataSource = transmissionstype;
            comboBox2.SelectedIndex = 0;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            string[] unitdrive = {" ", "Front drive", "Rear drive", "Full drive" };
            comboBox3.DataSource = unitdrive;
            comboBox3.SelectedIndex = 0;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;

            string[] rudderstype = {" ", "Left", "Right" };
            comboBox4.DataSource = rudderstype;
            comboBox4.SelectedIndex = 0;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;

            

            string[] body = { " ", "Sedan", "Hatchback","Station wagon","Coupe","Cabriolet","Three door Hatchback" };
            comboBox5.DataSource = body;
            comboBox5.SelectedIndex = 0;
            comboBox5.SelectedIndexChanged += comboBox4_SelectedIndexChanged;

            textBox6.TextChanged += mark_TextChanged;

        }
        private bool checkfield()
        {
            if (textBox1.Text != String.Empty)
            {
                brend = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the brend.");
                textBox1.Focus();
                return false;
            }

            if (textBox2.Text != String.Empty)
            {
                model = textBox2.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the model.");
                textBox2.Focus();
                return false;
            }
            if (textBox3.Text != String.Empty)
            {
                year = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Please ,fill in the year.");
                textBox3.Focus();
                return false;
            }
            if (textBox4.Text != String.Empty)
            {
                mileage = textBox4.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the mileage.");
                textBox4.Focus();
                return false;
            }
            if (comboBox5.Text != String.Empty)
            {
                body = comboBox5.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the body.");
                comboBox5.Focus();
                return false;
            }
            if (textBox5.Text != String.Empty)
            {
                engines_volume = textBox5.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the engine`s volume.");
                textBox5.Focus();
                return false;
            }
            if (textBox6.Text != String.Empty)
            {
                hp = Convert.ToDouble(textBox6.Text);
            }
            else
            {
                MessageBox.Show("Please ,fill in the hoursepower.");
                textBox6.Focus();
                return false;
            }
            if (comboBox1.Text != String.Empty)
            {
                engines_type = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the engine`s type.");
                comboBox1.Focus();
                return false;
            }
            if (comboBox2.Text != String.Empty)
            {
                transmissions_type = comboBox2.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the transmission`s type.");
                comboBox2.Focus();
                return false;
            }
            if (comboBox3.Text != String.Empty)
            {
                drive_unit = comboBox3.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the drive unit.");
                comboBox3.Focus();
                return false;
            }
            if (comboBox4.Text != String.Empty)
            {
                rudders_type = comboBox4.Text;
            }
            else
            {
                MessageBox.Show("Please ,fill in the rudder`s type.");
                comboBox4.Focus();
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {

             sound sound = new sound();
             sound.soundcar4();
            if (checkfield())
            {

                Car c = new Car(brend, model, year, mileage, body, engines_volume, hp, engines_type, transmissions_type, drive_unit, rudders_type);

                MessageBox.Show(c.info());

                string patch = @"C:\File_Program";
                DirectoryInfo dirInfo = new DirectoryInfo(patch);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    MessageBox.Show(@"Create dir C:\File_Program");
                }

                string fileName = " ";

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "txt";

                saveFileDialog.Title = "Сохранить ";
                saveFileDialog.Filter = "Текстовые файлы (*txt)|*/txt";
                saveFileDialog.FileName = @"C:\File_Program\file1.txt";

                string patch_images = @"C:\File_Program\images";

                DirectoryInfo dir_images = new DirectoryInfo(patch_images);
                if (!dirInfo.Exists)
                {
                    dir_images.Create();
                    MessageBox.Show(@"Craete dir C:\File_Program\images");
                }

                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    StreamWriter streamWriter = new StreamWriter(fileName, true, System.Text.Encoding.GetEncoding("utf-8"));

                    streamWriter.WriteLine(c.info());
                    streamWriter.Close();

                    pictureBox1.Image.Save(@"C:\File_Program\images\" + "car" + ".jpg");
                    {

                    }
                }
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
              sound sound = new sound();
             sound.soundcar4();

            // string message = " ";
            // foreach (var x in car_list) message += x.info() + "\n";
            // MessageBox.Show(message);
            if (checkfield())
            {
                Car cars = new Car(brend, model, year, mileage, body, engines_volume, hp, engines_type, transmissions_type, drive_unit, rudders_type);

                car_list.Add(cars);
                car_list.Sort();
                string message = "";
                foreach (var x in car_list) message += x.info() + "\n";
                MessageBox.Show(message);

                string path = @"C:\File_Program";
                DirectoryInfo dirinfo = new DirectoryInfo(path);

                if (!dirinfo.Exists)
                {
                    dirinfo.Create();
                    MessageBox.Show(@"Create dir C:\File_Program");
                }
                StreamWriter file = new StreamWriter(@"C:\File_Program\cars.txt", true);

                foreach (var x in car_list)
                    file.WriteLine(x.info());
                file.Close();
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            body = comboBox.SelectedItem.ToString();
        }
    }
}

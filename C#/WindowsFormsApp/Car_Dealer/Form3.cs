using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        DataTable dt;
        List<Car> car_lict;
        string filterField = "Brend";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dt = new DataTable();

            dt.Columns.Add("Brend");
            dt.Columns.Add("Model");
            dt.Columns.Add("Year");
            dt.Columns.Add("Mileage");
            dt.Columns.Add("Body");
            dt.Columns.Add("Engines_volume");
            dt.Columns.Add("Horsepower");
            dt.Columns.Add("Engines_type");
            dt.Columns.Add("Transmissions_type");
            dt.Columns.Add("Drive_unit");
            dt.Columns.Add("Rudders_type");

            string filename = @"C:\File_Program\file1.txt";

            if (File.Exists(filename))
            {
                StreamReader file = new StreamReader(filename);
                string[] values;
                string newline;

                while ((newline = file.ReadLine()) != null)
                {
                    DataRow dr = dt.NewRow();
                    values = newline.Split(' ');

                    for (int i = 0; i < 11; i++)
                    {
                        dr[i] = values[i];
                    }
                    dt.Rows.Add(dr);
                }
                file.Close();
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
            }
            else MessageBox.Show("No data file");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sound sound = new sound();
            sound.soundcar2();

            if (checkBox1.Checked)
            {
                dt.Columns.Add("Car Tax");
             
                int bid;
                int tax;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int hp = Convert.ToInt16(dt.Rows[i]["Horsepower"]);
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
                    dt.Rows[i]["Car Tax"]=tax;
                }
                dataGridView1.DataSource = dt;
            }
            else
            {
                dt.Columns.Remove("Car Tax");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'", filterField, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound sound = new sound();
            sound.soundcar4();
            string filename = @"C:\File_Program\file1.txt";

            if (File.Exists(filename))
            {
                StreamReader file = new StreamReader(filename);

                string[] values;
                string newline;

                string brend;
                string model;
                double year;
                string mileage;
                string body;
                string engines_volume;
                double hp;
                string engines_type;
                string transmissions_type;
                string drive_unit;
                string rudders_type;

                Car c;

                car_lict = new List<Car>();

                while ((newline = file.ReadLine()) != null)
                {
                    values = newline.Split(' ');

                    brend = values[0];
                    model = values[1];
                    year = Convert.ToDouble(values[2]);
                    mileage = values[3];
                    body = values[4];
                    engines_volume = values[5];
                    hp = Convert.ToDouble(values[6]);
                    engines_type = values[7];
                    transmissions_type = values[8];
                    drive_unit = values[9];
                    rudders_type = values[10];

                    c = new Car(brend, model, year, mileage, body, engines_volume, hp, engines_type, transmissions_type, drive_unit, rudders_type);
                    car_lict.Add(c);
                }
                file.Close();

                int j = 0;
                while (j < car_lict.Count)
                {
                    c = car_lict[j];
                    if (c.getBrend().Equals(textBox1.Text))
                    {
                        car_lict.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }

                j = 0;
                string data;
                while (j < dt.Rows.Count)
                {
                    data = dt.Rows[j][0].ToString();
                    if (data.Equals(textBox1.Text)) dt.Rows[j].Delete();
                    j++;
                }
                textBox1.Text = String.Empty;

                File.Delete(filename);
                file.Close();

                StreamWriter new_file = new StreamWriter(filename);
                foreach (var x in car_lict)
                    new_file.WriteLine(x.info());
                new_file.Close();
                dataGridView1.DataSource = dt;
            }

            else MessageBox.Show("No data file");
            
        }
    }
}

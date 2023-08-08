using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<PictureBox> items = new List<PictureBox>();

        int x, y,N=0;
        const int n = 1000;
        PictureBox hero;
        Bitmap hero_image;
        public Form1()
        {
            InitializeComponent();
        }

        private void MakePictureBox()
        {
            PictureBox mush = new PictureBox();
            mush.Height = 70;
            mush.Width = 70;
            mush.BackColor = Color.Transparent;

            mush.Image = Image.FromFile("c:\\File\\mushroom.png");
            mush.SizeMode = PictureBoxSizeMode.StretchImage;

            x = random.Next(10, this.ClientSize.Width - mush.Width);
            y = random.Next(10, this.ClientSize.Height - mush.Height);
            mush.Location = new Point(x, y);
            mush.Parent = this;
            mush.BackColor = Color.Transparent;
            items.Add(mush);
            this.Controls.Add(mush);

            mush.Click += Hero_in_Item;

        }
        private void TimerEvent(object sender, EventArgs e)
        {

            MakePictureBox();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(800, 800);
            this.MinimumSize = new Size(800, 800);

            
            hero = new PictureBox();

            // размеры PictureBox по размеру формы this
            hero.Width = this.Width / 10;
            hero.Height = this.Height / 10;
            // грузим рисунок в PictureBox и растягиваем размеры
            hero.Image = Image.FromFile("c:\\File\\hedgehog.gif");
            hero.Size = new Size(125, 125);
            hero.SizeMode = PictureBoxSizeMode.StretchImage;
            // Задаем начальное местоположениеPictureBox 
            hero.Location = new Point(100, 250);

            // задаем прозрачный фон PictureBox 
            // относительно фонового рисунка формы
            hero.Parent = this;
            hero.BackColor = Color.Transparent;
            // добавляем PictureBox в форму
            this.Controls.Add(hero);

            // регистрируем события клавиатуры
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
            hero_image = (Bitmap)hero.Image;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Если нажата клавиша "стрелка вправо"
            if (e.KeyCode == Keys.Right)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("c:\\File\\hedgehog.gif");
                //поворачиваем картинку
               // bitmap.RotateFlip(RotateFlipType.Rotate90FlipY);

                hero.Image = bitmap;
                //сдвигаем картинку
                hero.Left += 10;
                //запоминаем картинку для следующего поворота
                hero_image = bitmap;
            }

            else if (e.KeyCode == Keys.Left)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("c:\\File\\hedgehog.gif");
                //bitmap.RotateFlip(RotateFlipType.Rotate270FlipY);
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX); //зеркально отобразить картинку
                hero.Image = bitmap;
                hero.Left -= 10;
                hero_image = bitmap;
            }

            // Если нажата клавиша "стрелка вверх"
            else if (e.KeyCode == Keys.Up)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("c:\\File\\hedgehog.gif");
                hero.Image = bitmap;
                hero.Top -= 10;
                hero_image = bitmap;
            }

            else if (e.KeyCode == Keys.Down)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("c:\\File\\hedgehog.gif");
                hero.Image = bitmap;
                hero.Top += 10;
                hero_image = bitmap;
            }

            //Удаление картинки клада, когда ее задевает персонаж
            foreach (PictureBox item in items.ToList())
            {
                if (hero.Bounds.IntersectsWith(item.Bounds))
                {
                    items.Remove(item);
                    this.Controls.Remove(item);
                    N++;
                    SoundPlayer s = new SoundPlayer("C://Sound//s4.wav");
                    s.Play();
                }
               
                label1.Text ="      " + N.ToString();


            }
        }

       
        private void Hero_in_Item(object sender, EventArgs e)
        {

            PictureBox temPic = sender as PictureBox;
            items.Remove(temPic);
            this.Controls.Remove(temPic);

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

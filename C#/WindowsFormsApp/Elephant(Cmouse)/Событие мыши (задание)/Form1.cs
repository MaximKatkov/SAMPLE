using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

/* Бабочка ( PictureBox) должна все время «улетать» от указателя мышки (курсор мышки не может находиться на PictureBox с бабочкой, подводим курсор мыши к бабочке – бабочка улетает).*/

namespace Событие_мыши__задание_
{
    public partial class Form1 : Form
    {
        PictureBox elephant,bird;
        // Задаем начальные размеры PictureBox
        private int elephantWidth = 90, elephantHeight = 90;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            //ограничиваем размеры формы
            this.MinimumSize = new Size(700, 700);

            elephant = new PictureBox();
            bird = new PictureBox();
            elephant.Size = new Size(elephantWidth, elephantHeight);
            bird.Size = new Size(elephantWidth, elephantHeight);
            // грузим рисунок в PictureBox и растягиваем размеры
            elephant.Image = Image.FromFile("c:\\File\\elephant1.png");
            elephant.SizeMode = PictureBoxSizeMode.StretchImage;
            bird.Image = Image.FromFile("c:\\File\\bird.png");
            bird.SizeMode = PictureBoxSizeMode.StretchImage;
            // Задаем начальное местоположение PictureBox
            elephant.Location = new Point(250, 350);
            bird.Location = new Point(100, 100);
            //elephant.BorderStyle = BorderStyle.Fixed3D; //видимость границ картинки
            this.Controls.Add(elephant);
            this.Controls.Add(bird);
            bird.MouseClick += new MouseEventHandler(this.Form1_MouseClick);
            elephant.MouseLeave += new EventHandler(this.elephant_MouseLeave);
            elephant.MouseEnter += new EventHandler(this.elephant_MouseEnter);
            elephant.MouseMove += new MouseEventHandler(this.elephant_MouseMove);
        }

        private bool isDragging = true; //передвижение есть или нет

        public enum Elephant
        {
            Top1,Top2,Left1,Left2
        }

        private void elephant_MouseEnter(object sender,EventArgs e)
        {
            elephant.Image = Image.FromFile("c:\\File\\elephant1.png");
            elephant.SizeMode=PictureBoxSizeMode.StretchImage;
        }
        private void elephant_MouseLeave(object sender, EventArgs e)
        {
            elephant.Image = Image.FromFile("c:\\File\\elephant2.png");
            elephant.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x_elephant = e.X;
            int y_elephant = e.Y;

            elephant.Location = new Point(250, 350);
            elephant.Image = Image.FromFile("c:\\File\\elephant1.png");
            elephant.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void elephant_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Elephant b = (Elephant)(new Random()).Next(0, 4);
                switch (b)
                {
                    case Elephant.Top1:
                        elephant.Top = elephant.Top + 90;
                        break;
                    case Elephant.Top2:
                        elephant.Top = elephant.Top - 90;
                        break;
                    case Elephant.Left1:
                        elephant.Left = elephant.Left + 90;
                        break;
                    case Elephant.Left2:
                        elephant.Left = elephant.Left - 90;
                        break;
                }
                
            }
        }
    }
}
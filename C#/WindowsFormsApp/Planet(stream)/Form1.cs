using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Потоки
{
    public partial class Form1 : Form
    {
        Thread t1, t3, t2, t4,t5;
        int Angle;
        int r1 = 150, r2 = 260,r3=320;
        double x1 = 0, y1 = 0, x2 = 0, y2 = 0,x3=0,y3=0, angle1 = 0, angle2 = 0,angle3=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(800, 900);
            this.MinimumSize = new Size(800, 900);

            this.BackColor = Color.BlueViolet;

            this.DoubleBuffered = true;//убрать мерцание при прорисовки

            this.Paint += new PaintEventHandler(Form1_Paint);

            t1 = new Thread(new ThreadStart(Run1));
            t1.Start();
            t2 = new Thread(new ThreadStart(Run2));
            t2.Start();
            t3 = new Thread(new ThreadStart(Run3));
            t3.Start();
            t5 = new Thread(new ThreadStart(Run5));
            t5.Start();

            t4 = new Thread(new ThreadStart(Run4));
            t4.Start();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {


            //Image fon = Image.FromFile(@"c:\\images\\cosmos.png");
            //e.Graphics.DrawImage(fon, 0, 0, this.Width, this.Height);

            Image T1 = Image.FromFile(@"c:\\images\\planet1.png");
            Image T2 = Image.FromFile(@"c:\\images\\planet2.png");
            Image T3 = Image.FromFile(@"c:\\images\\planet3.png");
            Image T4 = Image.FromFile(@"c:\\images\\planet4.png");



            e.Graphics.DrawImage(T1, (float)x1, (float)y1, 80, 80);//движение планета 1
            e.Graphics.DrawImage(T3, (float)x2, (float)y2, 80, 80);
            e.Graphics.DrawImage(T4, (float)x3, (float)y3, 80, 80);


            e.Graphics.TranslateTransform(400, 400);//t2-солнце моё взгляни на меня 
            e.Graphics.RotateTransform(Angle);//моя ладонь превратилась в кулак и если есть порох дай огняяя
            e.Graphics.DrawImage(T2, -60, -60, 120, 120);// воот так
        }

        public void Run1()
        {
            while (true)
            {
                angle1 += 0.05;
                x1 = 355 - r1 * Math.Cos(angle1);
                y1 = 355 - r1 * Math.Sin(angle1);

                this.Invalidate();
                Thread.Sleep(15);
            }
        }
        public void Run2()
        {
            // пересчет угла поворота
            while (true)
            {
                Angle++;
                this.Invalidate();
                Thread.Sleep(20);
            }
        }
        public void Run3()
        {
            while (true)
            {
                angle2 += 0.04;
                x2 = 355 - r2 * Math.Cos(angle2);
                y2 = 355 - r2 * Math.Sin(angle2);

                this.Invalidate();
                Thread.Sleep(15);
            }
        }
        public void Run4()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "c:\\music\\GravityFalls.mp3";
            wplayer.settings.setMode("Loop", true);
            wplayer.controls.play();
        }
        public void Run5()
        {
            while (true)
            {
                angle3 += 0.03;
                x3 = 355 - r3 * Math.Cos(angle3);
                y3 = 355 - r3 * Math.Sin(angle3);

                this.Invalidate();
                Thread.Sleep(15);
            }
        }
    }
}

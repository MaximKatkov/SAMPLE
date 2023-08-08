using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace WindowsFormsApp2
{
    internal class sound
    {
        public void soundcar1()
        {
            SoundPlayer s = new SoundPlayer("C://Sound//s1.wav");
            s.Play();
        }
        public void soundcar2()
        {
            SoundPlayer s = new SoundPlayer("C://Sound//s2.wav");
            s.Play();
        }
        public void soundcar4()
        {
            SoundPlayer s = new SoundPlayer("C://Sound//s4.wav");
            s.Play();
        }
        public void soundcar3()
        {
            SoundPlayer s = new SoundPlayer("C://Sound//s3.wav");
            s.Play();
        }
    }
}

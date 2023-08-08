using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class dog
    {
        private string dog_breed;
        private string dog_image;

        public dog(string b)
        {
            dog_breed = b;
        }
        public void dog_gav(string sound_filename)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = sound_filename;
            sp.Load();
            sp.Play();
        }
        public void setdogimage(string filename)
        {
            dog_image = filename;
        }
        public string getdogimage()
        {
            return dog_image;
        }
        public string info()
        {
            return ("I live in nature \n"+"And i am free dog !");
        }

        
    }
}

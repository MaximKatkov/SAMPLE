using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class HomeDog :dog
    {
        private string dog_home_address;
        private string owner;
      

        public HomeDog(string b,string ow) : base(b)
        {
            owner = ow;
        }
        public new void dog_gav(string sound_filename)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = sound_filename;
            sp.Load();
            sp.Play();
        }
        public void setaddress(string ad)
        {
            dog_home_address = ad;
        }
        public string getaddress()
        {
            return dog_home_address;
        }
        public new string info()
        {
            string s;
            s = "I am home dog\n" + "My owner is " + owner;
            return s;
        }
    }
}

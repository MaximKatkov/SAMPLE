using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Car : IComparable<Car>
    {
        private string brend;
        private string model;
        private double year;
        private string mileage;
        private string body;
        private string engines_volume;
        private double horsepower;
        private string engines_type;
        private string transmissions_type;
        private string drive_unit;
        private string rudders_type;

        public Car(string br,string mod,double ye, string mil, string bo, string evol, double hp, string etyp, string trans, string driv, string rud)
        {
            brend= br;
            model = mod;
            year = ye;
            mileage = mil;
            body = bo;
            engines_volume = evol;
            horsepower = hp;
            engines_type = etyp;
            transmissions_type = trans;
            drive_unit = driv;
            rudders_type = rud;
        }

        public string info()
        {
            string str =brend+" "+model+" "+ year + " " + mileage + " " + body + " " + engines_volume + " " + horsepower + " " + engines_type + " " + transmissions_type + " " + drive_unit + " " + rudders_type;
            return str;
        }
        public string getBrend()
        {
            return brend;
        }
        public int CompareTo(Car obj)
        {
            int result=this.brend.CompareTo(obj.brend);
            if(result==0)
                result =this.model.CompareTo(obj.model);
            return result;
        }


    
    }
}

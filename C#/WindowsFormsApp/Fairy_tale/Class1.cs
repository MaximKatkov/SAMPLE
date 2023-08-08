using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Step
    {
     
        public string step1()
        {
            return ("Посадил дед репку и говорит:\r\n— Расти репка сладкая-сладкая! \r\nРасти большая-пребольшая!\r\nВыросла репка сладкая и большая-пребольшая.");
        }
        public string step2()
        {
            return ("Пошел дед репку рвать:тянет-потянет,вытянуть не может.\r\nПозвал дед бабку.\r\nБабка за дедку,\r\nДедка за репку — \r\nТянут-потянут,вытянуть не могут.");
        }
        public string step3()
        {
            return ("Позвала бабка внучку.\r\nВнучка за бабку,\r\nБабка за дедку,\r\nДедка за репку —\r\nТянут-потянут, вытянуть не могут.");
        }

        public string step4()
        {
            return (" Позвала внучка Жучку.\r\nЖучка за внучку,\r\nВнучка за бабку,\r\nБабка за дедку,\r\nДедка за репку —\r\nТянут-потянут -- и вытянули репку.");
        }
    }
}

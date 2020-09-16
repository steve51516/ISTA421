using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz20
{
    class Program
    {
        delegate void Del();
        static void Main(string[] args)
        {
            Del shotgunDel = new Del(Shotgun.Speak);
            shotgunDel();

            Del rifleDel = new Del(Rifle.Speak);
            rifleDel();

            Del pistolDel = new Del(Pistol.Speak);
            pistolDel();
        }
    }
}

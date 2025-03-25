using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Boat
    {
        string[] coordinat;
        int life;
        public Boat(string[] coordinatboat)
        {
            coordinat = coordinatboat;
            life = coordinat.Length;
        }
        public string[] Cord()
        {
            return coordinat;
        }
        public int Damage() {
            life--;
            return life;

        }
        public bool IsAlive()
        {

            if (life > 0)
            {
                return true;
            }
            else 
            return false;
        }
    }
}

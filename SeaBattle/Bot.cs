using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Bot
    {
        List<string> historybot = new List<string>();
        char[] bykv = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
        public List<Boat> botboat()
        {
            
            List<Boat> boats = new List<Boat>();
            boats.Add(createboat(4));
            Boat boat3_1 = createboat(3);
            while (intersec(boat3_1, boats))
            {
                boat3_1 = createboat(3);
            }
            boats.Add(boat3_1);
            Boat boat3_2 = createboat(3);
            while (intersec(boat3_2, boats))
            {
                boat3_2 = createboat(3);
            }
            boats.Add(boat3_2);
            Boat boat2_1 = createboat(2);
            while (intersec(boat2_1, boats))
            {
                boat2_1 = createboat(2);
            }
            boats.Add(boat2_1);

            Boat boat2_2 = createboat(2);
            while (intersec(boat2_2, boats))
            {
                boat2_2 = createboat(2);
            }
            boats.Add(boat2_2);

            Boat boat2_3 = createboat(2);
            while (intersec(boat2_3, boats))
            {
                boat2_3 = createboat(2);
            }
            boats.Add(boat2_3);

            Boat boat1_1 = createboat(1);
            while (intersec(boat1_1, boats))
            {
                boat1_1 = createboat(1);
            }
            boats.Add(boat1_1);

            Boat boat1_2 = createboat(1);
            while (intersec(boat1_2, boats))
            {
                boat1_2 = createboat(1);
            }
            boats.Add(boat1_2);

            Boat boat1_3 = createboat(1);
            while (intersec(boat1_3, boats))
            {
                boat1_3 = createboat(1);
            }
            boats.Add(boat1_3);

            Boat boat1_4 = createboat(1);
            while (intersec(boat1_4, boats))
            {
                boat1_4 = createboat(1);
            }
            boats.Add(boat1_4);
            return boats;
        }
        private char compass(string startcoordinat,int size)
        {
            
            List<char> nesw = new List<char>();
            int n_endcoordinat = Int32.Parse(startcoordinat.Substring(1)) - (size-1);
            if (n_endcoordinat >= 1)
            {
                nesw.Add('n');
            }
            int s_endcoordinat = Int32.Parse(startcoordinat.Substring(1)) + (size - 1);
            if (s_endcoordinat <= 10)
            {
                nesw.Add('s');
            }
            int e_endcoordinat = Array.IndexOf(bykv, startcoordinat.Substring(0, 1)[0])+ (size - 1);
            if (e_endcoordinat < bykv.Length)
            {
                nesw.Add('e');
            }
            int w_endcoordinat = Array.IndexOf(bykv, startcoordinat.Substring(0, 1)[0]) - (size - 1);
            if (w_endcoordinat >= 0)
            {
                nesw.Add('w');
            }
            Random rand = new Random();
            int randomindex = rand.Next(0,nesw.Count);
            return nesw[randomindex];
            
        }
        private Boat createboat(int size)
        {
            string[] coordinat = new string[size];


            Random random = new Random();
            int chislo = random.Next(1, 10);

            int randomindex = random.Next(0, 9);
            char randomChar = bykv[randomindex];



            string startcoordinat = "" + randomChar + chislo;
            coordinat[0] = startcoordinat;
            if (size > 1)
            {
                char naprav = compass(startcoordinat, size);

                switch (naprav)
                {
                    case 'n':
                        for (int i = 1; i < coordinat.Length; i++) {
                            coordinat[i] = "" + randomChar + (chislo - i);
                            
                        }
                        break;
                    case 'e':
                        for (int i = 1; i < coordinat.Length; i++)
                        {
                            coordinat[i] = "" + bykv[randomindex + i] + chislo;
                        }
                        break;
                    case 's':
                        for (int i = 1; i < coordinat.Length; i++)
                        {
                            coordinat[i] = "" + randomChar + (chislo + i);
                        }
                        break;
                    case 'w':
                        for (int i = 1; i < coordinat.Length; i++)
                        {
                            coordinat[i] = "" + bykv[randomindex - i] + chislo;
                        }
                        break;
                }
            }

            Boat randboat = new Boat(coordinat);

            return randboat;
        }
        private bool intersec(Boat boat , List<Boat> boats)
        {
            foreach (Boat boat2 in boats) {
                for (int i = 0; i < boat.Cord().Length; i++)

                {
                    for (int j = 0; j < boat2.Cord().Length; j++)
                    {
                        if (boat.Cord()[i] == boat2.Cord()[j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
            
        }
        public string hod()
        {
            string hod = " ";
            while (hod == " " || historybot.Contains(hod)){
                Random random = new Random();
                int chislo = random.Next(0, 9);

                int randomindex = random.Next(0, 9);
                char randomChar = bykv[randomindex];
                hod = "" + randomChar + chislo;
                
            }

            historybot.Add(hod);
            return hod;
        }

    }

}

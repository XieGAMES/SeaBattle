//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace SeaBattle
//{
//    internal class MyKart
//    {
//        Dictionary<string, bool> history = new Dictionary<string, bool>();
//        List<Boat> myBoats;
//        public MyKart()
//        {
//            myBoats = new List<Boat>();

//        }
//        public void Addboat(Boat boat)
//        {
//            myBoats.Add(boat);
//        }
//        private string Getkey(Dictionary<string, int> cord, int value)
//        {
//            foreach (var pair in cord)
//            {
//                if (pair.Value == value)
//                {
//                    return pair.Key;

//                }

//            }
//            return " ";
//        }
//        public void Print(bool showboat)
//        {
//            string[,] Karta = new string[10, 10];
//            Dictionary<string, int> cord = new Dictionary<string, int>();
//            cord.Add("А", 0);
//            cord.Add("Б", 1);
//            cord.Add("В", 2);
//            cord.Add("Г", 3);
//            cord.Add("Д", 4);
//            cord.Add("Е", 5);
//            cord.Add("Ж", 6);
//            cord.Add("З", 7);
//            cord.Add("И", 8);
//            cord.Add("К", 9);


//            for (int s = 0; s < 10; s++)
//            {

//                for (int k = 0; k < 10; k++)
//                {


//                    Karta[s, k] = "-";
//                    if (showboat)
//                    {
//                        foreach (Boat boat in myBoats)
//                        {


//                            string[] acord = boat.Cord();

//                            for (int n = 0; n < acord.Length; n++)

//                            {

//                                string bykva = acord[n].Substring(0, 1);
//                                int colindex = cord[bykva];
//                                int stroka;
//                                if (acord[n].Length == 2)
//                                {

//                                    stroka = Int32.Parse(acord[n].Substring(1, 1)) - 1;
//                                }
//                                else
//                                {
//                                    stroka = Int32.Parse(acord[n].Substring(1, 2)) - 1;
//                                }
//                                if (s == stroka && colindex == k)
//                                {

//                                    Karta[s, k] = "#";
//                                    break;
//                                }
//                            }

//                        }
//                    }




//                    string kartcord = Getkey(cord, k) + (s + 1);
//                    if (history.ContainsKey(kartcord))
//                    {
//                        if (history[kartcord])
//                        {
//                            Karta[s, k] = "x";
//                        }
//                        else
//                            Karta[s, k] = "*";

//                    }
//                }
//            }
//            Console.WriteLine("   А Б В Г Д Е Ж З И К");
//            for (int s = 0; s < 10; s++)
//            {
//                if (s < 9)
//                {
//                    Console.Write(" ");
//                }
//                Console.Write(s + 1 + " ");


//                for (int k = 0; k < 10; k++)
//                {

//                    Console.Write(Karta[s, k] + " ");

//                }
//                Console.WriteLine();
//            }

//        }
//        public int Fire(string firecord)
//        {
//            должен возвращать 0 если мимо 1 если попал -1 если убил

//            foreach (Boat boat in myBoats)
//            {

//                string[] cordboat = boat.Cord();
//                for (int i = 0; i < cordboat.Length; i++)
//                {
//                    if (firecord == cordboat[i])
//                    {
//                        history.Add(firecord, true);
//                        int lifeboat = boat.Damage();
//                        if (lifeboat > 0)
//                        {
//                            return 1;
//                        }
//                        else
//                        {
//                            return -1;
//                        }
//                    }



//                }

//            }
//            history.Add(firecord, false);
//            return 0;

//        }
//        public bool Alivefleet()
//        {
//            foreach (Boat boat in myBoats)
//            {
//                if (boat.IsAlive() == true)
//                {
//                    return true;
//                }

//            }
//            return false;
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattle
{
    internal class MyKart
    {
        Dictionary<string, bool> history = new Dictionary<string, bool>();
        List<Boat> myBoats;

        public MyKart()
        {
            myBoats = new List<Boat>();
        }

        public bool AddBoat(Boat boat)
        {
            
            if (!IsValidPlacement(boat))
            {
                return false;
            }

            myBoats.Add(boat);
            return true;
        }

        private bool IsValidPlacement(Boat newBoat)
        {
            
            HashSet<string> forbiddenCells = new HashSet<string>();

            foreach (Boat existingBoat in myBoats)
            {
                foreach (string cell in existingBoat.Cord())
                {
                    
                    AddCellAndNeighbors(forbiddenCells, cell);
                }
            }

            
            foreach (string newCell in newBoat.Cord())
            {
                if (forbiddenCells.Contains(newCell))
                {
                    return false;
                }
            }

            return true;
        }

        private void AddCellAndNeighbors(HashSet<string> forbiddenCells, string cell)
        {
            Dictionary<string, int> cord = new Dictionary<string, int>
            {
                {"А", 0}, {"Б", 1}, {"В", 2}, {"Г", 3}, {"Д", 4},
                {"Е", 5}, {"Ж", 6}, {"З", 7}, {"И", 8}, {"К", 9}
            };

            
            string letter = cell.Substring(0, 1);
            int number;
            if (cell.Length == 2)
            {
                number = int.Parse(cell.Substring(1, 1));
            }
            else
            {
                number = int.Parse(cell.Substring(1, 2));
            }

           
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newNumber = number + i;
                    int letterIndex = cord[letter] + j;

                    
                    if (newNumber >= 1 && newNumber <= 10 && letterIndex >= 0 && letterIndex < 10)
                    {
                        string newLetter = cord.FirstOrDefault(x => x.Value == letterIndex).Key;
                        string newCell = newLetter + newNumber;
                        forbiddenCells.Add(newCell);
                    }
                }
            }
        }

       
        private string Getkey(Dictionary<string, int> cord, int value)
        {
            foreach (var pair in cord)
            {
                if (pair.Value == value)
                {
                    return pair.Key;
                }
            }
            return " ";
        }

        public void Print(bool showboat)
        {
            string[,] Karta = new string[10, 10];
            Dictionary<string, int> cord = new Dictionary<string, int>
            {
                {"А", 0}, {"Б", 1}, {"В", 2}, {"Г", 3}, {"Д", 4},
                {"Е", 5}, {"Ж", 6}, {"З", 7}, {"И", 8}, {"К", 9}
            };

            for (int s = 0; s < 10; s++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Karta[s, k] = "-";
                    if (showboat)
                    {
                        foreach (Boat boat in myBoats)
                        {
                            string[] acord = boat.Cord();
                            for (int n = 0; n < acord.Length; n++)
                            {
                                string bykva = acord[n].Substring(0, 1);
                                int colindex = cord[bykva];
                                int stroka;
                                if (acord[n].Length == 2)
                                {
                                    stroka = Int32.Parse(acord[n].Substring(1, 1)) - 1;
                                }
                                else
                                {
                                    stroka = Int32.Parse(acord[n].Substring(1, 2)) - 1;
                                }
                                if (s == stroka && colindex == k)
                                {
                                    Karta[s, k] = "#";
                                    break;
                                }
                            }
                        }
                    }

                    string kartcord = Getkey(cord, k) + (s + 1);
                    if (history.ContainsKey(kartcord))
                    {
                        if (history[kartcord])
                        {
                            Karta[s, k] = "x";
                        }
                        else
                            Karta[s, k] = "*";
                    }
                }
            }

            Console.WriteLine("   А Б В Г Д Е Ж З И К");
            for (int s = 0; s < 10; s++)
            {
                if (s < 9)
                {
                    Console.Write(" ");
                }
                Console.Write(s + 1 + " ");

                for (int k = 0; k < 10; k++)
                {
                    Console.Write(Karta[s, k] + " ");
                }
                Console.WriteLine();
            }
        }

        public int Fire(string firecord)
        {
            foreach (Boat boat in myBoats)
            {
                string[] cordboat = boat.Cord();
                for (int i = 0; i < cordboat.Length; i++)
                {
                    if (firecord == cordboat[i])
                    {
                        history.Add(firecord, true);
                        int lifeboat = boat.Damage();
                        if (lifeboat > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            history.Add(firecord, false);
            return 0;
        }

        public bool Alivefleet()
        {
            foreach (Boat boat in myBoats)
            {
                if (boat.IsAlive())
                {
                    return true;
                }
            }
            return false;
        }
    }
}



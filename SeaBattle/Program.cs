//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace SeaBattle
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            MyKart p = new MyKart();
//            Console.WriteLine("Привет! Введи свои корабли:");
//            Console.WriteLine("Введи координаты 4-х палубного. Пример:А1 Б1 В1 Г1");

//            Boat boat4 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat4);
//            p.Print(true);
//            Console.WriteLine("Введи координаты  3-х палубного. Пример:А1 Б1 В1");
//            Boat boat3 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat3);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 3-х палубного. Пример:А1 Б1 В1");
//            Boat boat31 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat31);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 2-х палубного. Пример:А1 Б1");
//            Boat boat21 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat21);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 2-х палубного. Пример:А1 Б1");
//            Boat boat22 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat22);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 2-х палубного. Пример:А1 Б1");
//            Boat boat23 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat23);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 1-х палубного. Пример:А1");
//            Boat boat11 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat11);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 1-х палубного. Пример:А1");
//            Boat boat12 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat12);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 1-х палубного. Пример:А1");
//            Boat boat13 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat13);
//            p.Print(true);
//            Console.WriteLine("Введи координаты 1-х палубного. Пример:А1");
//            Boat boat14 = new Boat(Console.ReadLine().Split(' '));
//            p.Addboat(boat14);
//            p.Print(true);
//            Bot bot = new Bot();
//            List<Boat> botboats = bot.botboat();

//            MyKart botkart = new MyKart();
//            foreach (Boat boat in botboats)
//            {
//                botkart.Addboat((Boat)boat);
//            }
//            botkart.Print(false);
//            while(botkart.Alivefleet() && p.Alivefleet()) { 
//                int fireresult = 1;
//                while (fireresult != 0 && botkart.Alivefleet())
//                {

//                    Console.WriteLine("Сделайте ход");
//                    string hod = Console.ReadLine();
//                    fireresult = botkart.Fire(hod);

//                    if (fireresult == 1)
//                    {
//                        Console.WriteLine("попал!!!");

//                    }
//                    else if (fireresult == 0)
//                    {
//                        Console.WriteLine("мимо :( ");
//                    }
//                    else if (fireresult == -1)
//                    {
//                        Console.WriteLine("ЕСС ПОТОПЛЕН");

//                    }
//                    botkart.Print(false);
//                }

//                int botFireResult = 1;
//                while (botFireResult != 0 && p.Alivefleet())
//                {
//                    Console.WriteLine("Соперник делает ход");
//                    botFireResult = p.Fire(bot.hod());
//                    if (botFireResult == 1)
//                    {
//                        Console.WriteLine("о нет в нас попали");
//                    }
//                    else if (botFireResult == 0)
//                    {
//                        Console.WriteLine("мимо");
//                    }
//                    else if (botFireResult == -1)
//                    {
//                        Console.WriteLine("КАПИТАН МЫ ПОТЕРЯЛИ КОРАБЛЬ, понял вычеркиваю");

//                    }
//                    p.Print(true);

//                }
//            }


//           if ( botkart.Alivefleet())
//            {
//                Console.WriteLine("Победил соперник");
//                Console.WriteLine("НАЖМИТЕ ENTER ДЛЯ ВЫХОДА");
//                Console.ReadLine();
//            }
//            if (p.Alivefleet())
//            {
//                Console.WriteLine("Победа товарищи!");
//                Console.WriteLine("НАЖМИТЕ ENTER ДЛЯ ВЫХОДА");
//                Console.ReadLine();
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;

namespace SeaBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyKart p = new MyKart();
            Console.WriteLine("Привет! Введи свои корабли:");

            
            void AddBoatWithCheck(string prompt, int expectedLength)
            {
                while (true)
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine();
                    string[] coords = input.Split(' ');

                    if (coords.Length != expectedLength)
                    {
                        Console.WriteLine($"Неверное количество координат. Ожидается {expectedLength}.");
                        continue;
                    }

                    Boat boat = new Boat(coords);
                    if (p.AddBoat(boat))
                    {
                        p.Print(true);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Нельзя разместить корабль здесь или рядом с другим кораблем");
                    }
                }
            }

            AddBoatWithCheck("Введи координаты 4-х палубного. Пример: А1 Б1 В1 Г1", 4);
            AddBoatWithCheck("Введи координаты 3-х палубного. Пример: А1 Б1 В1", 3);
            AddBoatWithCheck("Введи координаты 3-х палубного. Пример: А1 Б1 В1", 3);
            AddBoatWithCheck("Введи координаты 2-х палубного. Пример: А1 Б1", 2);
            AddBoatWithCheck("Введи координаты 2-х палубного. Пример: А1 Б1", 2);
            AddBoatWithCheck("Введи координаты 2-х палубного. Пример: А1 Б1", 2);
            AddBoatWithCheck("Введи координаты 1-х палубного. Пример: А1", 1);
            AddBoatWithCheck("Введи координаты 1-х палубного. Пример: А1", 1);
            AddBoatWithCheck("Введи координаты 1-х палубного. Пример: А1", 1);
            AddBoatWithCheck("Введи координаты 1-х палубного. Пример: А1", 1);

            
            Bot bot = new Bot();
            List<Boat> botboats = bot.botboat();

            MyKart botkart = new MyKart();
            foreach (Boat boat in botboats)
            {
                botkart.AddBoat(boat);
            }
            botkart.Print(false);
            while (botkart.Alivefleet() && p.Alivefleet())
            {
                int fireresult = 1;
                while (fireresult != 0 && botkart.Alivefleet())
                {

                    Console.WriteLine("Сделайте ход");
                    string hod = Console.ReadLine();
                    fireresult = botkart.Fire(hod);

                    if (fireresult == 1)
                    {
                        Console.WriteLine("попал!!!");

                    }
                    else if (fireresult == 0)
                    {
                        Console.WriteLine("мимо :( ");
                    }
                    else if (fireresult == -1)
                    {
                        Console.WriteLine("ЕСС ПОТОПЛЕН");

                    }
                    botkart.Print(false);
                }

                int botFireResult = 1;
                while (botFireResult != 0 && p.Alivefleet())
                {
                    Console.WriteLine("Соперник делает ход");
                    botFireResult = p.Fire(bot.hod());
                    if (botFireResult == 1)
                    {
                        Console.WriteLine("о нет в нас попали");
                    }
                    else if (botFireResult == 0)
                    {
                        Console.WriteLine("мимо");
                    }
                    else if (botFireResult == -1)
                    {
                        Console.WriteLine("КАПИТАН МЫ ПОТЕРЯЛИ КОРАБЛЬ, понял вычеркиваю");

                    }
                    p.Print(true);

                }
            }


            if (botkart.Alivefleet())
            {
                Console.WriteLine("Победил соперник");
                Console.WriteLine("НАЖМИТЕ ENTER ДЛЯ ВЫХОДА");
                Console.ReadLine();
            }
            if (p.Alivefleet())
            {
                Console.WriteLine("Победа товарищи!");
                Console.WriteLine("НАЖМИТЕ ENTER ДЛЯ ВЫХОДА");
                Console.ReadLine();
            }
        }
    }
}
      


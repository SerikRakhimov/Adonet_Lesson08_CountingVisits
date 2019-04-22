using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingVisits
{
    class Program
    {
        static void Main(string[] args)
        {

            string menu;

            var choice = new Choice();

            Console.WriteLine("\n\t\tУчет посетителей");

            while (true)
            {
                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\n\t\tГлавное меню:\n");
                Console.WriteLine("\t1 - Зарегистрировать вход");
                Console.WriteLine("\t2 - Зарегистрировать выход");
                Console.WriteLine("\t3 - Вывести журнал посещений");
                Console.WriteLine("\t0 - Выход\n");
                Console.Write("\tВаш выбор = ");
                menu = Console.ReadLine();

                if (menu == "0")
                {
                    break;
                }
                else if (menu == "1")
                {
                    choice.Input();
                }
                else if (menu == "2")
                {
                    choice.Output();
                }
                else if (menu == "3")
                {
                    choice.List();
                }

            };

        }
    }
}

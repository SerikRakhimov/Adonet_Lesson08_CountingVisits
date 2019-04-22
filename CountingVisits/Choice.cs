using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingVisits
{
    public class Choice
    {
        public void Input()
        {
            string fio, document, purpose;
            fio = "";
            document = "";
            purpose = "";
            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n\tРегистрация посещения:\n");

            while (fio == "")
            {
                Console.Write("\tФамилия И.О. = ");
                fio = Console.ReadLine();
            }
            Console.WriteLine();
            while (document == "")
            {
                Console.Write("\tУдостоверение личности = ");
                document = Console.ReadLine();
            }
            Console.WriteLine();
            while (purpose == "")
            {
                Console.Write("\tЦель визита = ");
                purpose = Console.ReadLine();
            }

            var visit = new Visit
            {
                DateIn = DateTime.Now,
                DateOut = null,
                Fio = fio,
                Document = document,
                Purpose = purpose
            };

            using (var contex = new Context())
            {
                contex.Visits.Add(visit);
                contex.SaveChanges();
                Console.WriteLine("\n\tДанные добавлены.");
            }
        }

        public void Output()
        {
            int countAll;
            int countFilter;
            int number;
            string check;

            countAll = 0;
            countFilter = 0;
            number = 0;
            using (var contex = new Context())
            {
                Dictionary<int,int> listScreen= new Dictionary<int, int>();
                List<Visit> listVisits = contex.Visits.ToList();
                //                listVisits.Sort();

                listVisits.Sort(delegate (Visit listVisit1, Visit listVisit2)  // про сортировку см. http://www.skillcoding.com/Default.aspx?id=198
                { return listVisit1.DateIn.CompareTo(listVisit2.DateIn); });

                Console.WriteLine("\n\n\t\tПосещения");
                Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"\tНомер ~    Вход      ~   Фамилия ~ Удост.личности ~ Цель визита");
                Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                foreach (var item in listVisits)
                {
                    if (item.DateOut==null)
                    {
                        Console.WriteLine($"\t{countFilter + 1} ~ {item.DateIn} ~ {item.Fio} ~ {item.Document} ~ {item.Purpose}");
                        listScreen.Add(countFilter, countAll);
                        countFilter++;
                    }
                    countAll++;
                }
                if (countFilter == 0)
                {
                    Console.WriteLine("\n\tДанных нет.");
                    return;
                }

                while (true)
                {
                    Console.Write($"\n\tВыберите номер посещения (1-{countFilter}, 0 - выход) = ");
                    check = Console.ReadLine();
                   
                    try
                    {
                        number = int.Parse(check);
                        if (0 <= number && number <= (countFilter))
                        {
                            break;
                        }

                    }
                    catch
                    {
                    }
                }
                if (check != "0")
                {
                    number = listScreen[number-1];
                    listVisits[number].DateOut = DateTime.Now;
                    contex.SaveChanges();

                    Console.WriteLine($"\n\tВыход посетителя '{listVisits[number].Fio}' зафиксирован.");
                }
            }

        }


        public void List()
        {
            int number;
            number = 0;

            using (var contex = new Context())
            {
                List<Visit> listVisits = contex.Visits.ToList();

                listVisits.Sort(delegate (Visit listVisit1, Visit listVisit2)  // про сортировку см. http://www.skillcoding.com/Default.aspx?id=198
                { return listVisit1.DateIn.CompareTo(listVisit2.DateIn); });

                Console.WriteLine("\n\n\tПолный список посещений");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"Номер ~ Вход        ~      Выход     ~       Фамилия ~ Уд/личн. ~ Цель визита");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                foreach (var item in listVisits)
                {
                    number++;
                    Console.Write($"{number} ~ {item.DateIn} ~");
                    if (item.DateOut == null)
                    {
                        Console.Write(" ---------------- ");
                    }
                    else
                    {
                        Console.Write($"{item.DateOut}");
                    }
                    Console.WriteLine($" ~ {item.Fio} ~ {item.Document} ~ {item.Purpose}");
                }
                Console.WriteLine();
            }

        }

    }
}

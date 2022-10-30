using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Collections.Specialized.BitVector32;

namespace CPP_Lab_1._2
{
    public class Program
    {

        static void printTable(List<Police_file<string, DateTime>> list)
        {
            
            Police_file<string, DateTime>.PrintLine();
            Police_file<string, DateTime>.PrintRow("П.І.П", "Дата народження ", "Дати ув'язнень", "Дата ост ув'язнення", "Дата ост звільнення");
            Police_file<string, DateTime>.PrintLine();
            foreach (var item in list)
            {
                item.Display();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(172, 50);
            List<Police_file<string, DateTime>> prisoners = new List<Police_file<string, DateTime>>();

            try
            {
                string filePfth = "..//..//police_file.txt";
                List<string> lines = File.ReadAllLines(filePfth).ToList();

                

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');


                    Police_file<string, DateTime> newPrisoner = new Police_file<string, DateTime>();
                    newPrisoner.Surname = entries[0];
                    newPrisoner.Name = entries[1];
                    newPrisoner.Middle_Name = entries[2];
                    newPrisoner.Birthday = Convert.ToDateTime(entries[3]);


                    string[] date = new string[entries.Length-4];
                    int i = 4, j = 0;
                    
                    while (i < entries.Length)
                    { 
                        date[j] = entries[i];
                        i++;
                        j++;
                       
                    }
                    newPrisoner.Dates_of_Convictions = date;
                    newPrisoner.Date_of_Last_Imprisonment = Convert.ToDateTime(date[j - 2]);
                    newPrisoner.Date_of_Last_Dismissal = Convert.ToDateTime(date[j - 1]);


                    prisoners.Add(newPrisoner);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            printTable(prisoners);
                List<Police_file<string, DateTime>> sortedList = new List<Police_file<string, DateTime>>();

                bool exit = false;
                do
                {
                    int action = -1;
                    Console.WriteLine(" Сортувати:");
                    Console.WriteLine("  [1] - за Прізвищем");
                    Console.WriteLine("  [2] -за Датаою народження");
                    Console.WriteLine("  [3] -за Дата ост ув'язнення");
                    Console.WriteLine("  [4] -за:Дата ост звільнення"); 
                    Console.WriteLine("  [0] -Завершити роботу");
                    Console.Write("  Виберіть дію: "); action = Convert.ToInt32(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            {
                                Console.Clear();
                                sortedList = prisoners[0].Sort_by(prisoners, action);
                                Console.WriteLine("\n Відсортовано за Прізвищем");
                                printTable(sortedList);
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                sortedList = prisoners[0].Sort_by(prisoners, action);
                                Console.WriteLine("\n Відсортовано за Датаою народження");
                                printTable(sortedList);
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                sortedList = prisoners[0].Sort_by(prisoners, action);
                                Console.WriteLine("\n Відсортовано за Дата ост ув'язнення");
                                printTable(sortedList);
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                sortedList = prisoners[0].Sort_by(prisoners, action);
                                Console.WriteLine("\n Відсортовано pf Дата ост звільнення");
                                printTable(sortedList);
                                break;
                            }
                        case 0:
                            {
                                exit = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\nНевідома дія!");
                                printTable(prisoners);
                            break;
                            }

                    }


                } while (exit == false);

           



        }
    }
}

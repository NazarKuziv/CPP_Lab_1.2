using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CPP_Lab_1._2
{

    public class Police_file<T1, T2>
    {
        
        public T1 Surname { get; set; }
        public T1 Name { get; set; }
        public T1 Middle_Name { get; set; }
        public T2 Birthday { get; set; }
        public T1[] Dates_of_Convictions { get; set; }
        public T2 Date_of_Last_Imprisonment { get; set; }
        public T2 Date_of_Last_Dismissal { get; set; }

        static int tableWidth = 170;

        public  List<Police_file<T1, T2>> Sort_by(List<Police_file<T1, T2>> prisonersList,int sort_by)
        {
            switch(sort_by)
            {
                case 1: return prisonersList.OrderBy(order => order.Surname).ToList();
                case 2: return prisonersList.OrderBy(order => order.Birthday).ToList();
                case 3: return prisonersList.OrderBy(order => order.Date_of_Last_Imprisonment).ToList();
                case 4: return prisonersList.OrderBy(order => order.Date_of_Last_Dismissal).ToList();
                default: return prisonersList;

            }  
        }


        public void Display()
        {
            Console.OutputEncoding = Encoding.UTF8;


            if (Dates_of_Convictions.Length == 2)
            {
                string[] str = {Surname+" "+Name+" "+ Middle_Name,String.Format("{0:dd/MM/yyyy}", Birthday),
                Dates_of_Convictions[0]+"-"+ Dates_of_Convictions[1],String.Format("{0:dd/MM/yyyy}",
                Date_of_Last_Imprisonment),String.Format("{0:dd/MM/yyyy}", Date_of_Last_Dismissal)};

                PrintRow(str);
               
            }
            else
            {
                string[] str = {Surname+" "+Name+" "+ Middle_Name,String.Format("{0:dd/MM/yyyy}", Birthday),
                Dates_of_Convictions[0]+"-"+ Dates_of_Convictions[1],String.Format("{0:dd/MM/yyyy}",
                Date_of_Last_Imprisonment),String.Format("{0:dd/MM/yyyy}", Date_of_Last_Dismissal)};
                PrintRow(str);

                for(int i = 2; i < Dates_of_Convictions.Length-1;i++)
                {
                    PrintRow("","", Dates_of_Convictions[i] + "-" + Dates_of_Convictions[i+1], "","");
                }

                
            }
            PrintLine();



        }
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (var column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }


    }
}

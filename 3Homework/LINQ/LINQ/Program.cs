using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a,b,c");
            char s =Convert.ToChar(Console.ReadLine());
            switch(s)
            {
                case 'a':Method1();break;
                case 'b':Method2();break;
                case 'c':Method3();break;
            }
            
            Console.ReadKey();
        }
        public static void Method1()
        {
            string name = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            //разделить на масив по запятой,создать новый масив добавляя инкримент + елемент первого масива
            string[] mas = name.Split(',').ToArray();
            var s = mas.Select((n, x) => String.Concat(Convert.ToString(++x) + ".", n));
            string s1 = string.Join(",", s);
            Console.WriteLine(s1);
            //string s1=s.Select(x=> Arrays.toString(s))
            //foreach (var l in s)
            //{
            //    Console.WriteLine(l);
            //}
            // //обычный способ
            // string[] mas2 = new string[mas.Length];
            // int k = 1;
            // for(int i=0;i<mas.Length;i++)
            // {
            //     mas2[i] = Convert.ToString(k++ + "." + mas[i]);
            // }
            //linq
            //// IEnumerable<int> nums = Enumerable.Range(1, 11);
            //// Convert.ToString(Enumerable.Range(1, 11) + "."),n)
        }
        public static void Method2()
        {
            string s = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";
           //разделить по ; на отдельные объекты,разделить по запятой 
           string[] mas= s.Split(';').ToArray();
            List<Person> p = new List<Person>();
            foreach (var k in mas)
            {
                Person a = new Person(k);
                p.Add(a);
            }
            DateTime date = DateTime.Today;
            var stroka1 = p.OrderBy(x => x.Date).Select(x => x);
            foreach(var k in stroka1)
            {
                Console.WriteLine(k.Name+" "+ (date.Year-k.Date.Year));
            }
            
        }
        public class Person
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
           public  Person(string str)
            {  
               string[]mas= str.Split(',');
                Name = mas[0];
                Date = Convert.ToDateTime(mas[1]);
            }
        }
        public static void Method3()
        {
            string s = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            string[] mas = s.Split(',').ToArray();
            //Simple
            //List<TimeSpan> t = new List<TimeSpan>();
            //TimeSpan sum=new TimeSpan(0,0,0);
            //foreach(var k in  mas)
            //{
            //    string[] mas2 = k.Split(':').ToArray();
            //    TimeSpan span = new TimeSpan(0,Convert.ToInt32(mas2[0]), Convert.ToInt32(mas2[1]));
            //    t.Add(span);
            //    sum = sum + span;

            //}
            //Console.WriteLine("hours "+sum.Hours+" minutes "+ sum.Minutes+" seconds "+ sum.Seconds);
            //LINQ
            List<Time> times = new List<Time>();
            foreach (var k in mas)
            {
                Time t = new Time();
                string[] mas2 = k.Split(':').ToArray();
                t.Minutes =Convert.ToInt32(mas2[0]);
                t.Second = Convert.ToInt32(mas2[1]);
                times.Add(t);
            }
            int k1 = times.Sum(x => x.Minutes);
            int k2 = times.Sum(x => x.Second);
            TimeSpan timeSpan = new TimeSpan(0, k1, k2);
            Console.WriteLine(timeSpan);
        }
        public class Time
        {
            public int Minutes { get; set; }
            public int Second { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        public delegate void AddStroka(string s);
        public static event AddStroka EventAdd;
        static void Main(string[] args)
        {
            bool f = true;
            StringCollector s = new StringCollector();
            AlphaNumbericCollector a = new AlphaNumbericCollector();
            
           
            while (f)
            {
                Console.WriteLine("Введите строку");
                string stroka = Console.ReadLine();
                if (Check(stroka) == true)
                {  
                    EventAdd = s.Add;
                }
                else
                {
                    EventAdd = a.Add;
                }
                EventAdd.Invoke(stroka);
                Console.WriteLine("Закночить?Y/N");
                string simbol = Console.ReadLine();
                if (simbol.ToLower() == "y")
                {
                    f = false;
                }
            }
                Console.WriteLine("StringCollector");
                foreach (var t in s.elements)
                {
                    Console.WriteLine(t);
                }
                Console.WriteLine("AlphaNumbericCollector");
                foreach (var t in a.elements)
                {
                    Console.WriteLine(t);
                }
                Console.ReadKey();
            
        }
            public static bool Check(string s)
            {
                bool f = false;
                char[] arr = s.ToCharArray();
                foreach (char c in arr)
                {
                        if (int.TryParse(c.ToString(),out int k))
                           {
                                     f = false;break;
                           }
                        else { f = true; }
                }
                return f;
            }
        class StringCollector
        {
            public List<string> elements = new List<string>();
            public void Add(string s)
            {
                elements.Add(s);
            }
        }
        class AlphaNumbericCollector
        {
            public List<string> elements = new List<string>();
            public void Add(string s)
            {
                elements.Add(s);
            }

        }
    }
}

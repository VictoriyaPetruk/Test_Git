using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystruct
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<Person> p = new MyCollection<Person>();
            Person[] persons = new[] {
            new Person() { Name = "Vika", Age = 19, Weight = 50 },
            new Person() { Name = "Vika", Age = 19, Weight = 50 },
            new Person() { Name = "Vika", Age = 19, Weight = 50 },
            new Person() { Name = "Vika", Age = 19, Weight = 50 },
            new Person() { Name = "Vika", Age = 19, Weight = 50 }
            };
            foreach(var a in persons)//добавили 
            {
                p.Add(a);
            }
            Console.WriteLine("добавили ");
            Show(p);
            p.Remove(persons[2]);//удалили по объекту
            Console.WriteLine("удалили по объекту ");
            Show(p);
            p.RemoveAt(1);//удалили по индексу
            Console.WriteLine("удалили по индексу");
            Show(p);
            Console.WriteLine("Поиск:");
            Console.WriteLine(p.Find(1).Name);
            Console.WriteLine(p.FindIndex(persons[0]));
            Person person = new Person();
            person.Name = "Kate";
            person.Age = 20;
            person.Weight = 60;
            p.Insert(0, person);
            Console.WriteLine("Вставка");
            Show(p);
            p.RemoveAll();
            Console.WriteLine("Удалили все");
            
            Console.ReadKey();
           
        }
        public static void Show(MyCollection<Person> p)
        {foreach(var k in p)
            {
                Console.WriteLine(k.Name+" "+ k.Age + " " + k.Weight);
            }
        }




    }
}

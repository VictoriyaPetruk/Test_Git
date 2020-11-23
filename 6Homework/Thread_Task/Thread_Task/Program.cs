using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Task
{
    class Program
    {
        static List<string> contents = new List<string>();
        static void Main(string[] args)
        {
            string[] lines = 
            {
                "https://docs.microsoft.com/ru-ru/welcome-to-docs" ,
                "https://docs.microsoft.com/ru-ru/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-5.0",
                "https://docs.microsoft.com/ru-ru/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio",
                "https://docs.microsoft.com/ru-ru/dotnet/csharp/whats-new/csharp-9",
                "https://docs.microsoft.com/ru-ru/dotnet/csharp/whats-new/csharp-8",
                "https://docs.microsoft.com/ru-ru/dotnet/csharp/whats-new/csharp-7",
                "https://docs.microsoft.com/ru-ru/dotnet/csharp/whats-new/csharp-6",
                "https://docs.microsoft.com/ru-ru/dotnet/csharp/whats-new/breaking-changes",
                "https://docs.microsoft.com/ru-ru/dotnet/csharp/whats-new/csharp-version-history",
                "https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/"
            };
            ////1 задание -2 способ(с использованием Thread.Sleep)
            Download_From_Site_Thread(lines);
            ////2 задание (2 способом-с использованием Thread.Sleep)
            Download_From_Site_Task(lines);
            ////1 задание -1 способ(c использованием класса и  ParameterizedThreadStart
           Download_From_Site_Thread_With_Class(lines);
            //метод с помощью Thread поочередное скачивание
           Download_From_Site_Thread_After_Thread(lines);
            //метод с помощью Task поочередное скачивание
           Download_From_Site_Task_After_Task(lines);
            Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("Exit");
        }
        //1 и 2 задание 
                //1 задание -1 способ(c использованием класса и  ParameterizedThreadStart
                class Parametrs
                {
                    public int i;
                    public string str;
                }
                static void Download_From_Site_Thread_With_Class(string[] lines)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        Parametrs p = new Parametrs();
                        p.i = i;
                        p.str = lines[i];
                         new Thread(new ParameterizedThreadStart(Download_From_Site_With_Class)).Start(p);
               
                    }
                }
                static void Download_From_Site_With_Class(object k)
                {
                    Parametrs p = (Parametrs)k;
                    using (WebClient ws = new WebClient())
                    {
                        contents.Add(ws.DownloadString(p.str));
                        Console.WriteLine(p.i + "-" + "Data is download" + " " + p.str + " Thread Id-" + Thread.CurrentThread.ManagedThreadId);

                    }
                }

                //2 задание (2 способом-с использованием Thread.Sleep)
                static void Download_From_Site_Task(string[] lines)
                {
            
                    for (int i = 0; i < lines.Length; i++)
                    {
                        Task task = Task.Run(() => Download_From_Site(lines[i], i));
                        Thread.Sleep(1000);
                    }

            
                }
                // static object locker = new object();

                //1 задание -2 способ(с использованием Thread.Sleep)
                static void Download_From_Site_Thread(string[]lines)
                {
         
                    for (int i = 0; i < 10; i++)
                    {
               
                            var thread = new Thread(() => Download_From_Site(lines[i], i));
                            thread.IsBackground = true;
                            thread.Start();

                
                       Thread.Sleep(100);
                    }
                    
                }

                //метод скачивания для 2 способа 1 и 2 задания
                static void Download_From_Site(string str,int i)
                {
                        using (WebClient ws = new WebClient())
                        {
                            contents.Add(ws.DownloadString(str));
                            Console.WriteLine(i + "-" + "Data is download" + " " + str + " Thread Id-" + Thread.CurrentThread.ManagedThreadId);

                        }
                }
        //2 и 3 задание
                static ManualResetEvent signal = new ManualResetEvent(false);
                //метод с помощью Thread поочередное скачивание
                static void Download_From_Site_Thread_After_Thread(string[] lines)
                {
                    
                    for (int i = 0; i < 10; i++)
                    {
                        var thread = new Thread(() => Download_From_Site_One_After_One(lines[i], i));
                        thread.IsBackground = true;
                        //signal.Dispose();
                        thread.Start();
                        Thread.Sleep(2000);
                        signal.WaitOne();
                    }
                   
                }
                //метод с помощью Task поочередное скачивание
                static void Download_From_Site_Task_After_Task(string[] lines)
                 {
                            for (int i = 0; i < 10; i++)
                            {
                                Task task = Task.Run(() => Download_From_Site_One_After_One(lines[i], i));
                                Console.WriteLine("Task");
                                Thread.Sleep(3000);
                                signal.WaitOne();
                            }
                }
                //метод для скачивания, немного измененный 
                static void Download_From_Site_One_After_One(string str, int i)
                {
                    using (WebClient ws = new WebClient())
                    {
                        contents.Add(ws.DownloadString(str));
                        Console.WriteLine(i + "-" + "Data is download" + " " + str + " Thread Id-" + Thread.CurrentThread.ManagedThreadId);
                     
                        signal.Set();
                        Thread.Sleep(5000);
                    }
                }
    }
}

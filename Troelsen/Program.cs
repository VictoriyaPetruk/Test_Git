using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Troelsen
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("What do you want?\n1- InternalProgram\n2- CommandLine\n3 ShowEnvironmentDetails\n4GetUserData\n5- FormatNumericalData");
            int result = Convert.ToInt32(Console.ReadLine());
            switch (result)
            {
                case 1: InternalProgram(); break;
                case 2: CommandLine(args); break;
                case 3: ShowEnvironmentDetails(); break;
                case 4: GetUserData(); break;
                case 5: FormatNumericalData(); break;
                case 6: ObjectFunctionality(); break;
                case 7: DataTypeFunctionality();break;
                case 8:CharFunctionality();break;
            }

            Console.ReadLine();

            return 0;
        }
        static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit ( 'a') : {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter ( 'a' ) : {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}",char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}",char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation(’?'): {0}", char.IsPunctuation('?'));
            Console.WriteLine(); }
            static void DataTypeFunctionality()
        {
            Console.WriteLine("=> Data type Functionality:");
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
           
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}",  double.PositiveInfinity);
            Console.WriteLine("double.Negativelnfinity: {0}", double.NegativeInfinity);
            Console.WriteLine();
        }
    
        static void DefaultDeclarations()
        {
            Console.WriteLine("=> Default Declarations:");
            int mylnt = default;
            bool b = new bool(); // Устанавливается в false.
            int l = new int(); // Устанавливается в 0.
            double d = new double(); // Устанавливается в 0.
            DateTime dt = new DateTime(); // Устанавливается в 1/1/0001 12:00:00 AM
        }        static void ObjectFunctionality() { 
            Console.WriteLine("=> System.Object Functionality:");
            // Ключевое слово int языка C# - это в действительности сокращение для
            // типа System.Int32, который наследует от System.Object следующие члены:
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals (23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString () = {0}", 12.ToString());
            Console.WriteLine("12.GetType () = {0}", 12L.GetType());
            Console.WriteLine();}
        static void CommandLine(string []args)
        {
            // Настройка консольного пользовательского интерфейса.
            // string[] theArgs = Environment.GetCommandLineArgs();
            //foreach (string arg in theArgs)
            //    Console.WriteLine("Arg: {0}", arg);
            for (int i = 0; i < args.Length; i++)
            { Console.WriteLine("Arg: {0}", args[i]); }
           
        }
        static void InternalProgram()
        {
            Console.Title = "My Rocking App";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("*************************************");
            Console.WriteLine("***** Welcome to My Rocking App *****");
            Console.WriteLine("*******************★*****************");
            Console.BackgroundColor = ConsoleColor.Black;
            // Ожидание нажатия клавиши <Enter>.
            MessageBox.Show("Done!");

        }

        static void ShowEnvironmentDetails()
        {
            
            // Вывести информацию о дисковых устройствах
            // данной машины и другие интересные детали,
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Drive: {0}", drive); // Логические устройства
            Console.WriteLine("OS: {0}", Environment.OSVersion); // Версия
                                                                 // операционной системы
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount); // Количество процессоров
            Console.WriteLine(".NET Version: {0}", Environment.Version);
            Console.WriteLine("name machine: {0}", Environment.MachineName);
            Console.WriteLine("name user: {0}", Environment.UserName);
           ;
            Console.Beep();

        }
        private static void GetUserData()
        {
            Console.Write("Please enter your name: "); // Предложить ввести имя
            string userName = Console.ReadLine();
            Console.Write("Please enter your age: "); // Предложить ввести возраст
            string userAge = Console.ReadLine();
            // Просто ради забавы изменить цвет переднего плана.
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            // Вывести полученную информацию на консоль.
            Console.WriteLine("Hello {0}' You are {1} years old.",userName, userAge);
            // Восстановить предыдущий цвет переднего плана.
            Console.ForegroundColor = prevColor;
        }
        static void FormatNumericalData()
        { Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
            // Обратите внимание, что использование для символа шестнадцатеричного формата
            // верхнего или нижнего регистра определяет регистр отображаемых символов.
            Console.WriteLine("Е format: {0:E}", 99999);
            Console.WriteLine("е format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
        }
    }
}

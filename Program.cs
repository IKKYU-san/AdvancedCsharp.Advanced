
namespace AdvancedCsharp.Advanced
{
    using Delegate;
    using Encapsulation;
    using Event;

    using System;

    class Program
    {

        static void Main(string[] args)
        {
            SetupConsoleWindow();

            new DelegateAssignement().Run();

        }

        static public void SetupConsoleWindow()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 70;
            Console.WindowHeight = 30;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

    }

}

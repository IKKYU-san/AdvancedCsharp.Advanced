
namespace AdvancedCsharp.Advanced.Delegate
{
    using System;

    public class DelegateAssignement
    {
        void AskUserAndDoubleString()
        {

            Console.WriteLine("====== Hej och välkommen! =======");
            Console.Write("Ange en sträng: ");
            var answer = Console.ReadLine();

            var newString = DoubleString(answer);

            Console.Write($"Resultatet efter strängmanipulationen: {newString}");
            Console.WriteLine();
            Console.WriteLine();
        }


        void AskUserAndFirstFiveCharacters()
        {

            Console.WriteLine("====== Hej och välkommen! =======");
            Console.Write("Ange en sträng: ");
            var answer = Console.ReadLine();

            var newString = FirstFiveCharacters(answer);
            
            Console.Write($"Resultatet efter strängmanipulationen: {newString}");
            Console.WriteLine();
            Console.WriteLine();
        }

        void AskUserAndToUpper()
        {

            Console.WriteLine("====== Hej och välkommen! =======");
            Console.Write("Ange en sträng: ");
            var answer = Console.ReadLine();

            var newString = ToUpper(answer);

            Console.Write($"Resultatet efter strängmanipulationen: {newString}");
            Console.WriteLine();
            Console.WriteLine();
        }

        string DoubleString(string s)
        {
            return s + s;
        }

        string FirstFiveCharacters(string s)
        {
            if (s.Length < 5)
            {
                return s;
            }
            return s.Substring(0, 5);
        }

        string ToUpper(string s)
        {
            return s.ToUpper();
        }

        public void Run()
        {
            // UPPGIFT DELEGATE 

            // Skriv om koden och använd "delegates" för att förbättra koden. (Koden innehåller en del upprepningar vilket inte är så snyggt)
            // Programmet ska fungera precis som innan.

            AskUserAndDoubleString();
            AskUserAndFirstFiveCharacters();
            AskUserAndToUpper();
        }
    }
}

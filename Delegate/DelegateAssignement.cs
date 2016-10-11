
namespace AdvancedCsharp.Advanced.Delegate
{
    using System;

    public class DelegateAssignement
    {
        delegate string FilterStringInput(string _string);

        void FilterUserInput(FilterStringInput filterMethod)
        {

            Console.WriteLine("====== Hej och välkommen! =======");
            Console.Write("Ange en sträng: ");
            var answer = Console.ReadLine();

            var newString = filterMethod(answer);

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

            FilterUserInput(DoubleString);
            FilterUserInput(FirstFiveCharacters);
            FilterUserInput(ToUpper);
        }
    }
}

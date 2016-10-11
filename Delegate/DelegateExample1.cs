
namespace AdvancedCsharp.Advanced.Delegate
{
    using System;
    using System.Collections.Generic;

    public class DelegateExample1
    {
        // Här definieras en delegate. Det är en funktion som tar ett heltal som inparameter och returnerar true/false

        delegate bool FilterNumberMethod(int number); 

        // Dessa metoder låter vi vara kvar

        bool GreaterThan30(int number)
        {
            return number > 30;
        }

        bool EvenNumber(int number)
        {
            return number % 2 == 0;
        }

        bool DividableByThree(int number)
        {
            return number % 3 == 0;
        }

        // Här skapar vi en generell metod som tar en annan metod som inparameter (vi slipper tre stycken snarlika metoder)

        List<int> FilterListOfIntegers(List<int> integerList, FilterNumberMethod filterMethod) 
        {
            var returnList = new List<int>();
            foreach (var number in integerList)
            {
                if (filterMethod(number))
                {
                    returnList.Add(number);
                }
            }

            return returnList;
        }

        // Hjälpfunktioner

        string ListToString(List<int> list)
        {
            return $"[{string.Join(",", list)}]";
        }

        private void PrintList(string listname, List<int> list1)
        {
            Console.WriteLine($"{listname}: {ListToString(list1)}");
        }

        public void Run()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 30, 40, 50, 60 };

            var list1 = FilterListOfIntegers(list, GreaterThan30);
            var list2 = FilterListOfIntegers(list, EvenNumber);
            var list3 = FilterListOfIntegers(list, DividableByThree);

            PrintList("List1", list1);
            PrintList("List2", list2);
            PrintList("List3", list3);

            Console.ReadKey();
        }
    }
}

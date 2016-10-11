
namespace AdvancedCsharp.Advanced.Delegate
{
    using System;
    using System.Collections.Generic;

    public class DelegateExample1Bad
    {
        // Dessa metoder är bra och enkla

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

        // I filter-funktionerna nedan så sker en hel del upprepning, det går att göra på ett snyggare sätt med delegate's

        List<int> FilterListOfIntegersGreaterThan30(List<int> integerList)
        {
            var returnList = new List<int>();
            foreach (var number in integerList)
            {
                if (GreaterThan30(number))
                {
                    returnList.Add(number);
                }
            }
            return returnList;
        }

        List<int> FilterListOfIntegersEvenNumber(List<int> integerList)
        {
            var returnList = new List<int>();
            foreach (var number in integerList)
            {
                if (EvenNumber(number))
                {
                    returnList.Add(number);
                }
            }
            return returnList;
        }

        List<int> FilterListOfIntegersDividableByThree(List<int> integerList)
        {
            var returnList = new List<int>();
            foreach (var number in integerList)
            {
                if (DividableByThree(number))
                {
                    returnList.Add(number);
                }
            }
            return returnList;
        }

        // Hjälpmetoder

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
            // Exempel på ett program som inte använder delegate's

            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 30, 40, 50, 60 };

            var list1 = FilterListOfIntegersGreaterThan30(list);
            var list2 = FilterListOfIntegersEvenNumber(list);
            var list3 = FilterListOfIntegersDividableByThree(list);

            PrintList("List1", list1);
            PrintList("List2", list2);
            PrintList("List3", list3);

        }

    }
}

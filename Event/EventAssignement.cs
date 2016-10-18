
namespace AdvancedCsharp.Advanced.Event
{

    using System;

    class EventAssignement
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        class StringParser
        {
            public delegate string ProcessNameHandler(string name);
            public event ProcessNameHandler ProcessName;
            public event ProcessNameHandler ProcessAge;

            public delegate void ProcessErrorHandler(string error);
            public event ProcessErrorHandler ErrorOccured;

            public Person ParsePerson(string s)
            {
                string name;
                int age;

                try
                {
                    if (s == null)
                    {
                        if (ErrorOccured != null)
                        {
                            OnError("Strängen är null");
                        }
                        return null;
                    }

                    var person = s.Split(',');
                    if (person.Length > 2)
                    {
                        if (ErrorOccured != null)
                        {
                            OnError();
                        }
                        return null;
                    }

                    name = person[0];
                    if (ProcessName != null)
                    {
                        name = ProcessName(name);
                    }

                    string ageInput = person[1];
                    if (ProcessAge != null)
                    {
                        ageInput = ProcessAge(ageInput);
                    }
                    bool hasAge = int.TryParse(ageInput, out age);
                }
                catch
                {
                    if (ErrorOccured != null)
                    {
                        OnError();
                    }
                    return null;
                }
                return new Person { Name = name, Age = age };
            }

            private void OnError()
            {
                ReportErrorToUser("En sträng i formen NAMN,ÅLDER förväntas. 'T.ex Maria,26'");
            }

            private void OnError(string s)
            {
                ReportErrorToUser(s);
            }
        }

        void DisplayPerson(Person p)
        {
            if (p != null)
            {
                Console.WriteLine($"En person med namn {p.Name} och ålder {p.Age}");
            }
        }

        // Efter att du avkommentera koden i Run() så ska du inte lägga till eller ändra något i denna metod
        // I think the naming of Delegates and Events are wrong. Would be better to follow Microsofts naming conventions. Maybe also use the new EventHandler.

        public void Run()
        {

            var sp = new StringParser();

            var test1 = "Lisa,37";              // Detta är en idealisk indatasträng till ParsePerson              
            var test2 = "    Lisa   ,   37  ";
            var test3 = "Lisa";                 // ogiltig indata
            var test4 = "Lisa,37,Kjell";        // ogiltig indata
            string test5 = null;                // ogiltig indata

            Console.WriteLine("\n----- Utan events -----");

            // Avkommentera koden:
            DisplayPerson(sp.ParsePerson(test1));
            DisplayPerson(sp.ParsePerson(test2));
            DisplayPerson(sp.ParsePerson(test3));             // Ska inte skriva ut någonting
            DisplayPerson(sp.ParsePerson(test4));             // Ska inte skriva ut någonting
            DisplayPerson(sp.ParsePerson(test5));             // Ska inte skriva ut någonting

            Console.WriteLine("\n----- Med events -----");

            // Avkommentera koden:
            sp.ProcessName += CleanupAndUpperCase;             // Här förändrar vi beteendet på ParsePerson genom att haka på en egen metod (som tar bort mellanslag och gör VERSALER)
            sp.ProcessAge += Cleanup;                          // Här förändrar vi beteendet på ParsePerson genom att haka på en egen metod (som tar bort mellanslag)
            sp.ErrorOccured += ReportErrorToUser;              // Här förändrar vi beteendet på ParsePerson genom att tala om vad som händer om indata har fel format
            DisplayPerson(sp.ParsePerson(test1));
            DisplayPerson(sp.ParsePerson(test2));
            DisplayPerson(sp.ParsePerson(test3));             // Ska ge felmeddelande till användaren
            DisplayPerson(sp.ParsePerson(test4));             // Ska ge felmeddelande till användaren
            DisplayPerson(sp.ParsePerson(test5));             // Ska ge felmeddelande till användaren

        }

        private static void ReportErrorToUser(string s)
        {
            // Implementera denna metod
            // Skriv ut texten med röd färg
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        private string CleanupAndUpperCase(string s)
        {
            // Implementera denna metod
            // Ta bort mellanslag före och efter strängen + gör om strängen till versaler
            return s.Trim().ToUpper();
        }

        private string Cleanup(string s)
        {
            // Implementera denna metod
            // Ta bort mellanslag före och efter strängen
            string name = s.Trim();
            return name;
        }
    }
}

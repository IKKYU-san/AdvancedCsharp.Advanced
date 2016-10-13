
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

            public Person ParsePerson(string s)
            {
                string name;
                int age;

                try
                {
                    var person = s.Split(',');
                    if (person.Length > 2)
                    {
                        return null;
                    }

                    name = person[0];
                    if (ProcessName != null)
                    {
                        name = ProcessName(name);
                    }
                    bool hasAge = int.TryParse(person[1], out age);       
                }
                catch
                {
                    return null;
                }
                return new Person { Name = name, Age = age };
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
            //sp.ProcessAge += Cleanup;                          // Här förändrar vi beteendet på ParsePerson genom att haka på en egen metod (som tar bort mellanslag)
            //sp.ErrorOccured += ReportErrorToUser;              // Här förändrar vi beteendet på ParsePerson genom att tala om vad som händer om indata har fel format
            DisplayPerson(sp.ParsePerson(test1));
            DisplayPerson(sp.ParsePerson(test2));
            //DisplayPerson(sp.ParsePerson(test3));             // Ska ge felmeddelande till användaren
            //DisplayPerson(sp.ParsePerson(test4));             // Ska ge felmeddelande till användaren
            //DisplayPerson(sp.ParsePerson(test5));             // Ska ge felmeddelande till användaren

        }

        private void ReportErrorToUser(string s)
        {
            // Implementera denna metod
            // Skriv ut texten med röd färg
            throw new NotImplementedException();
        }

        private string CleanupAndUpperCase(string s)
        {
            // Implementera denna metod
            // Ta bort mellanslag före och efter strängen + gör om strängen till versaler
            return s.Trim().ToUpper();
            //throw new NotImplementedException();
        }

        private string Cleanup(string s)
        {
            // Implementera denna metod
            // Ta bort mellanslag före och efter strängen
            string name = s.Trim();
            return name;
            throw new NotImplementedException();
        }

    }
}

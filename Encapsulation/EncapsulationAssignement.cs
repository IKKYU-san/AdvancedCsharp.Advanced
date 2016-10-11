
namespace AdvancedCsharp.Advanced.Encapsulation
{
    using AdvancedCsharp.Advanced.Encapsulation.Domain;
    using AdvancedCsharp.Advanced.Encapsulation.Service;
    using System.Collections.Generic;
    using System;

    public class EncapsulationAssignement
    {
        public void Run()
        {
            var book = new Book(123);
            
            //book.Isbn = 333; // Detta ska INTE vara tillåtet

            Console.WriteLine($"Den nyss skapade boken har isbn-nummer: {book.Isbn}"); 

            var library = new Library("Kreativa vägen 123");

            library.ChangeAddress("Linnegatan 20");

            //library.Address = "Storgatan 14";               // Detta ska INTE vara tillåtet
            //library.i = 3;                                  // Detta ska INTE vara tillåtet
            //library.hungerGamesPrefix ="Kalle kula";        // Detta ska INTE vara tillåtet
            //library.hungerGamesStartIsbn = 2000000;         // Detta ska INTE vara tillåtet

            //var test1 = library.hungerGamesPrefix;          // Detta ska INTE vara tillåtet
            //var test2 = library.hungerGamesStartIsbn;       // Detta ska INTE vara tillåtet
            //var test3 = library.i;                          // Detta ska INTE vara tillåtet
            //var test4 = library.Address;                    // Detta ska INTE vara tillåtet

            library.ChangeHungerGamesStartIsbn();  // Det ska vara möjligt att anropa ChangeHungerGamesStartIsbn

            library.AddHungerGamesBooks();

            library.DisplayLibrary();

            library.AllBooks = new List<Book>();            // Detta ska INTE vara tillåtet
        }
    }
}

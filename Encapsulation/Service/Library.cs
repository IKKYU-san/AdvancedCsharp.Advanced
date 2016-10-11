
namespace AdvancedCsharp.Advanced.Encapsulation.Service
{
    using AdvancedCsharp.Advanced.Encapsulation.Domain;
    using System.Collections.Generic;
    using System;

    public class Library : Facility
    {

        public List<Book> AllBooks;

        private int i=0; 

        private string hungerGamesPrefix = "Hunger Games";
        private long hungerGamesStartIsbn = 1000000;

        public Library(string address)
        {
            Address = address;
            AllBooks = new List<Book>();
        }

        public void ChangeAddress(string address)
        {
            Address = address;
        }

        public void ChangeHungerGamesStartIsbn()
        {
            hungerGamesStartIsbn = 5000000;
        }

        public void AddHungerGamesBooks()
        {
            while(i<=5)
            {
                var bookName = hungerGamesPrefix + " " + i;
                var isbn = hungerGamesStartIsbn + i;

                var book = new Book(isbn);

                book.Title = bookName;

                AllBooks.Add(book);
                i++;
            }
        }

        public void DisplayLibrary()
        {
            Console.WriteLine($"Detta bibliotek är på addressen {Address} och har följande böcker:");
            foreach (var book in AllBooks)
            {
                Console.WriteLine($"Bok\t{book.Isbn}\t{book.Title}");
            }
        }
    }
}

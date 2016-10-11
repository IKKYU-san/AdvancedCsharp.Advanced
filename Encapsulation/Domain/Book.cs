namespace AdvancedCsharp.Advanced.Encapsulation.Domain
{
    public class Book
    {
        public Book(long isbn)
        {
            Isbn = isbn;
        }

        public long Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}




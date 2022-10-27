using DatabaseSeeder.Context;
using DatabaseSeeder.Models;

namespace DatabaseSeeder.Seeder
{
    public class DbSeeder
    {
        private static bool _generatingData;


        private LibraryContext _libraryContext;

        public DbSeeder(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public bool DatabaseIsEmpty()
        {
            return _libraryContext is { } && !_libraryContext.Authors.Any() && !_libraryContext.Books.Any() && !_generatingData;
        }

        public void SeedData()
        {
            if (_generatingData)
                return;

            _generatingData = true;

            var books = CreateBooks();
            var authors = CreateAuthors();

            try
            {
                _libraryContext.AddRange(authors);
                _libraryContext.AddRange(books);

                Console.WriteLine("Save Changes");
                var entries = _libraryContext.SaveChanges();
                Console.WriteLine($"Done! - Wrote {entries} entries");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _generatingData = false;
            }
        }

        private List<Author> CreateAuthors()
        {
            Console.WriteLine("Create Authors");
            var authors = new List<Author>();

            authors.Add(new Author("Fyodor Dostoevsky"));
            authors.Add(new Author("Leo Tolstoy"));
            authors.Add(new Author("Anton Chekhov"));
            authors.Add(new Author("Herman Melville"));
            authors.Add(new Author("Alexander Pushkin"));
            authors.Add(new Author("J. R. R. Tolkien"));
            authors.Add(new Author("William Shakespeare"));
            authors.Add(new Author("Ernest Hemingway"));
            authors.Add(new Author("George Orwell"));
            authors.Add(new Author("Stephen King"));

            return authors;
        }

        private List<Book> CreateBooks()
        {
            Console.WriteLine("Create Books");
            var books = new List<Book>();

            books.Add(new Book("Crime and Punishment", 1));
            books.Add(new Book("The Brothers Karamazov", 1));
            books.Add(new Book("Demons", 1));
            books.Add(new Book("The Idiot", 1));
            books.Add(new Book("War and Peace", 2));
            books.Add(new Book("Anna Karenina", 2));
            books.Add(new Book("Childhood", 2));
            books.Add(new Book("The Death of Ivan Illyich", 2));
            books.Add(new Book("Boys", 3));
            books.Add(new Book("The Bet", 3));
            books.Add(new Book("The Chameleon", 3));
            books.Add(new Book("Three Sisters", 3));
            books.Add(new Book("Moby-Dick", 4));
            books.Add(new Book("Billy Budd", 4));
            books.Add(new Book("The Confidence", 4));
            books.Add(new Book("Bartleby", 4));
            books.Add(new Book("The Captain's Daugther", 5));
            books.Add(new Book("Dubrovsky", 5));
            books.Add(new Book("I Loved You", 5));
            books.Add(new Book("The Bronze Horseman", 5));
            books.Add(new Book("The Lord of the Rings", 6));
            books.Add(new Book("The Hobbit", 6));
            books.Add(new Book("The Silmarillion", 6));
            books.Add(new Book("Beren and Luthien", 6));
            books.Add(new Book("Hamlet", 7));
            books.Add(new Book("Romeo and Juliet", 7));
            books.Add(new Book("King Lear", 7));
            books.Add(new Book("A Midsummer Night's Dream", 7));
            books.Add(new Book("The Old Man and the Sea", 8));
            books.Add(new Book("For Whom the Bell Tolls", 8));
            books.Add(new Book("A Farewell to Arms", 8));
            books.Add(new Book("The Sun Also Rises", 8));
            books.Add(new Book("Nineteen Eighty-Four", 9));
            books.Add(new Book("Animal Farm", 9));
            books.Add(new Book("Homage To Catalonia", 9));
            books.Add(new Book("Politics and the English", 9));
            books.Add(new Book("It", 10));
            books.Add(new Book("Cujo", 10));
            books.Add(new Book("Fairy Tale", 10));
            books.Add(new Book("1408", 10));

            return books;
        }
    }
}

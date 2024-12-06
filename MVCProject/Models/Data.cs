namespace MVCProject.Models
{
    public class Data
    {
        #region Yazarlar
        public static List<Author> Authors { get; set; } = new() // Yazarlar listesini başlatıyoruz. Yazarlar, Id, FirstName, LastName ve DateOfBirth özelliklerine sahip.
        {
            new Author { Id = 1, FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
            new Author { Id = 2, FirstName = "Jane", LastName = "Austen", DateOfBirth = new DateTime(1775, 12, 16) },
            new Author { Id = 3, FirstName = "J.K.", LastName = "Rowling", DateOfBirth = new DateTime(1965, 7, 31) },
            new Author { Id = 4, FirstName = "Mark", LastName = "Twain", DateOfBirth = new DateTime(1835, 11, 30) },
            new Author { Id = 5, FirstName = "Harper", LastName = "Lee", DateOfBirth = new DateTime(1926, 4, 28) },

        };
        #endregion
        #region Kitaplar
        public static List<Book> Books { get; set; } = new() // Kitaplar listesini başlatıyoruz. Kitaplar, Id, Title, AuthorId, Genre, PublishDate, ISBN ve CopiesAvailable özelliklerine sahip.
        {
            new Book { Id = 1, Title = "1984", AuthorId = 1, Genre = "Dystopian", PublishDate = new DateTime(1949, 6, 8), ISBN = "9780451524935", CopiesAvailable = 10 },
            new Book { Id = 2, Title = "Animal Farm", AuthorId = 1, Genre = "Political Satire", PublishDate = new DateTime(1945, 8, 17), ISBN = "9780451526342", CopiesAvailable = 8 },
            new Book { Id = 3, Title = "Pride and Prejudice", AuthorId = 2, Genre = "Romance", PublishDate = new DateTime(1813, 1, 28), ISBN = "9780141439518", CopiesAvailable = 15 },
            new Book { Id = 4, Title = "Sense and Sensibility", AuthorId = 2, Genre = "Romance", PublishDate = new DateTime(1811, 10, 30), ISBN = "9780141439662", CopiesAvailable = 7 },
            new Book { Id = 5, Title = "Emma", AuthorId = 2, Genre = "Romance", PublishDate = new DateTime(1815, 12, 23), ISBN = "9780141439587", CopiesAvailable = 6 },
            new Book { Id = 6, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 3, Genre = "Fantasy", PublishDate = new DateTime(1997, 6, 26), ISBN = "9780747532743", CopiesAvailable = 20 },
            new Book { Id = 7, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 3, Genre = "Fantasy", PublishDate = new DateTime(1998, 7, 2), ISBN = "9780747538486", CopiesAvailable = 18 },
            new Book { Id = 8, Title = "Harry Potter and the Prisoner of Azkaban", AuthorId = 3, Genre = "Fantasy", PublishDate = new DateTime(1999, 7, 8), ISBN = "9780747542155", CopiesAvailable = 16 },
            new Book { Id = 9, Title = "Adventures of Huckleberry Finn", AuthorId = 4, Genre = "Adventure", PublishDate = new DateTime(1884, 12, 10), ISBN = "9780486280615", CopiesAvailable = 12 },
            new Book { Id = 10, Title = "The Adventures of Tom Sawyer", AuthorId = 4, Genre = "Adventure", PublishDate = new DateTime(1876, 6, 1), ISBN = "9780486400778", CopiesAvailable = 10 },
            new Book { Id = 11, Title = "Life on the Mississippi", AuthorId = 4, Genre = "Memoir", PublishDate = new DateTime(1883, 2, 1), ISBN = "9780486414263", CopiesAvailable = 5 },
            new Book { Id = 12, Title = "To Kill a Mockingbird", AuthorId = 5, Genre = "Classic", PublishDate = new DateTime(1960, 7, 11), ISBN = "9780061120084", CopiesAvailable = 10 },
            new Book { Id = 13, Title = "Go Set a Watchman", AuthorId = 5, Genre = "Classic", PublishDate = new DateTime(2015, 7, 14), ISBN = "9780062409850", CopiesAvailable = 7 },
            new Book { Id = 14, Title = "The Complete Works of Mark Twain", AuthorId = 4, Genre = "Collection", PublishDate = new DateTime(1969, 1, 1), ISBN = "9780517203295", CopiesAvailable = 3 },
            new Book { Id = 15, Title = "Harry Potter and the Goblet of Fire", AuthorId = 3, Genre = "Fantasy", PublishDate = new DateTime(2000, 7, 8), ISBN = "9780747546245", CopiesAvailable = 15 },
        };
        #endregion
    }
}
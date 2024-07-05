using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime CreatedAt { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static List<Book> books = new List<Book>()
    {
        new Book() { Id = 1, Title = "The Great Gatsby", Description = "A novel by F. Scott Fitzgerald", Author = "F. Scott Fitzgerald", CreatedAt = new DateTime(1925, 4, 10) },
        new Book() { Id = 2, Title = "To Kill a Mockingbird", Description = "A novel by Harper Lee", Author = "Harper Lee", CreatedAt = new DateTime(1960, 7, 11) },
        new Book() { Id = 3, Title = "1984", Description = "A dystopian novel by George Orwell", Author = "George Orwell", CreatedAt = new DateTime(1949, 6, 8) },
        new Book() { Id = 4, Title = "Pride and Prejudice", Description = "A romantic novel by Jane Austen", Author = "Jane Austen", CreatedAt = new DateTime(1813, 1, 28) },
        new Book() { Id = 5, Title = "The Catcher in the Rye", Description = "A novel by J.D. Salinger", Author = "J.D. Salinger", CreatedAt = new DateTime(1951, 7, 16) },
        new Book() { Id = 6, Title = "Harry Potter and the Philosopher's Stone", Description = "A fantasy novel by J.K. Rowling", Author = "J.K. Rowling", CreatedAt = new DateTime(1997, 6, 26) },
        new Book() { Id = 7, Title = "The Hobbit", Description = "A fantasy novel by J.R.R. Tolkien", Author = "J.R.R. Tolkien", CreatedAt = new DateTime(1937, 9, 21) },
        new Book() { Id = 8, Title = "The Da Vinci Code", Description = "A mystery thriller novel by Dan Brown", Author = "Dan Brown", CreatedAt = new DateTime(2003, 3, 18) },
        new Book() { Id = 9, Title = "The Hunger Games", Description = "A dystopian novel by Suzanne Collins", Author = "Suzanne Collins", CreatedAt = new DateTime(2008, 9, 14) },
        new Book() { Id = 10, Title = "The Lord of the Rings", Description = "An epic high-fantasy novel by J.R.R. Tolkien", Author = "J.R.R. Tolkien", CreatedAt = new DateTime(1954, 7, 29) }
    };

        [HttpGet]
        [Route("/GetBooks")]
        public List<Book> GetBooks()
        {
            return books;
        }

        [HttpGet]
        [Route("/GetBook/{id}")]
        public Book GetBook(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete]
        [Route("/DeleteBook/{id}")]
        public int DeleteBook(int id) 
        { 
            var result = books.FirstOrDefault(x => x.Id == id);
            if(result != null)
            {
                books.Remove(result);
                return 1;
            }
            return 0;
        }

        [HttpPost]
        [Route("/AddBook")]
        public int AddBook(string title, string description, string author)
        {
            var result = books.FirstOrDefault(x => x.Title == title);
            if(result == null)
            {
                books.Add(new Book() { Id = books.Count() + 1, Title = title, Description = description, Author = author, CreatedAt = DateTime.Now });
                return 1;
            }
            return 0;
        }

        [HttpPut]
        [Route("/EditBook/{id}")]
        public Book EditBook(int id, string author, string desc, string title)
        {
            var result = books.FirstOrDefault(x => x.Id == id);
            if(result != null)
            {
                result.Author = author;
                result.Description = desc;
                result.Title = title;
                result.CreatedAt = DateTime.Now;
                return result;
            }
            return new Book();

        }

    }
}

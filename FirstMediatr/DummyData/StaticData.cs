using FirstMediatr.Model;

namespace FirstMediatr.DummyData
{
    public static class StaticData
    {
        public static List<Category> Categories { get; set; } = new List<Category>()
        {
            new Category { Id = 1, Name = "Adventure" },
            new Category { Id = 2, Name = "Crime" },
            new Category { Id = 3, Name = "Fantasy" },
            new Category { Id = 4, Name = "Horror" },
        };

        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Author = "John",
                CategoryId = 1,
                Date = DateTime.UtcNow.AddDays(-1000),
                Description = "test",
                Title = "jungle adventures",
                Rate = 23
            },
            new Book
            {
                Id = 2,
                Author = "Thomas",
                CategoryId = 4,
                Date = DateTime.UtcNow.AddDays(-2233),
                Description = "some looong descripton of horror",
                Title = "how to use hungarian notation in c#",
                Rate = 1
            },
            new Book
            {
                Id = 3,
                Author = "Robert",
                CategoryId = 2,
                Date = DateTime.UtcNow.AddDays(-342),
                Description = "Illegal operations",
                Title = "Dividing by zero",
                Rate = 67
            },
            new Book
            {
                Id = 4,
                Author = "Criss",
                CategoryId = 1,
                Date = DateTime.UtcNow.AddDays(-666),
                Description = "Man describes his first days in new companies",
                Title = "Adventures of the newbie",
                Rate = 44
            },
            new Book
            {
                Id = 5,
                Author = "Paul",
                CategoryId = 3,
                Date = DateTime.UtcNow.AddDays(43534),
                Description = "how to build flying car",
                Title = "Flying car step by step",
                Rate = 98
            }
        };

    }
}

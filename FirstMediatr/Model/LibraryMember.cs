using FirstMediatr.Enum;

namespace FirstMediatr.Model
{
    public class LibraryMember
    {
        public string Name { get; set; } = string.Empty;
        public int KnowledgeLevel { get; set; }
        public Book? FavouriteBook { get; set; }
        public BookCategory FavouriteCategory { get; set; }
        public BookCategory HatedCategory { get; set; }
        public bool WearingGlasses { get; set; }
        public int Age { get; set; }
        public string MemberCardNumber { get; set; } = string.Empty;
        public IEnumerable<Book>? ReadedBooks { get; set; }

        public int RandomValue { get; set; }
    }
}

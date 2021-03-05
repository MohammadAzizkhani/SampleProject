using Domain.Enum;

namespace Domain.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public byte PublishedTime { get; set; }
        public int PublishedCount { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public bool CanBorrow { get; set; }
        public BookType? BookType { get; set; }
        public string Name { get; set; }
        public BookFile BookFile { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

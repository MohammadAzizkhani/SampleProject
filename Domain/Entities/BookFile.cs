namespace Domain.Entities
{
    public class BookFile
    {
        public long Id { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public Book Book { get; set; }
    }
}

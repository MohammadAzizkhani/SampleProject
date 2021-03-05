using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }

        private IEnumerable<Book> Books { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class BookViewModel
    {
        public string ISBN { get; set; }

        public string Author { get; set; }
        public byte PublishedTime { get; set; }
        public int PublishedCount { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public bool CanBorrow { get; set; }
        public string BookType { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}

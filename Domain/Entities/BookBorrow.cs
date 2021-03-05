using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BookBorrow
    {
        public long  Id { get; set; }

        public DateTime ReturnDateTime { get; set; }

        public Book Book { get; set; }
        public long BookId { get; set; }


        public User User { get; set; }
        public int UserId { get; set; }
    }
}

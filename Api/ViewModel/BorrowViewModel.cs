using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class BorrowViewModel
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }
    }
}

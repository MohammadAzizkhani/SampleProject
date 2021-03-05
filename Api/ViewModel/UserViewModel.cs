using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class UserViewModel
    {
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string FatherName { get; set; }
        [MaxLength(10)]
        [Required]
        public string NationalCode { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}

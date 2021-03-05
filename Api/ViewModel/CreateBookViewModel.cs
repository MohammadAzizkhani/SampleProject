using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class CreateBookViewModel
    {
        [MaxLength(50)]
        public string ISBN { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        public byte PublishedTime { get; set; }
        [Required]
        public int PublishedCount { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public bool CanBorrow { get; set; }
        public int BookType { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long CategoryId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class CategoryViewModel
    {
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public long Id { get; set; }
    }
}

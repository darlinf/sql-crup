using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sql_crup.Models
{
    public class Persons
    {
        public int PersonID { get; set; } 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
    }
}

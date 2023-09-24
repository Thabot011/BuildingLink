using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class CreateDriverDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
    }
}

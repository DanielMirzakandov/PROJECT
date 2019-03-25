using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_proj.Models
{
    public class User
    {
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "ID should contain 4 digits")]
        public string ID { get; set; }

        [Required]
        [RegularExpression("^[a-z]{4}$", ErrorMessage = "ID should contain 4 chars")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50,MinimumLength =2,ErrorMessage = "length must be 2 and 50 chars")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mail is incorrect")]
        public string Email { get; set; }
    }
}
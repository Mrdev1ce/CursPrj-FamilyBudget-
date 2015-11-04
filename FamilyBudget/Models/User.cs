using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Required"), 
        StringLength(20, MinimumLength = 3, ErrorMessage = "Login must be between 3 and 20 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Required"),
        StringLength(20, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 20 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required"),
        RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not valid E-mail")]
        public string Mail { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsRemember { get; set; }
    }
}
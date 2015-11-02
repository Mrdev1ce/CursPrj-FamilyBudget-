using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsAdmin { get; set; }
    }
}
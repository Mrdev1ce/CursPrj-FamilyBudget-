using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models.HelpModels
{
    public class ChangeRole
    {
        public string UserForChangeLogin { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
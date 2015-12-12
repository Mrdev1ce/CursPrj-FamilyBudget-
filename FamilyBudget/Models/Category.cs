using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public class Category
    {
        public Category()
        {
            ID = -1;
            Name = "";
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
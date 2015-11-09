using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public class Wallet
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Funds { get; set; }

        public int OwnerID { get; set; }
    }
}
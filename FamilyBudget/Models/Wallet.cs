using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public class Wallet
    {
        public Wallet()
        {
            ID = -1;
            Name = "";
            Funds = 0;
            OwnerID = -1;
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public int Funds { get; set; }

        public int OwnerID { get; set; }
    }
}
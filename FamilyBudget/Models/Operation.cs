using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public class Operation
    {
        public int ID { get; set; }

        public int WalletID { get; set; }

        public string WalletName { get; set; }

        public bool Type { get; set; }

        public int Sum { get; set; }

        public DateTime Date { get; set; }

        public string CategoryName { get; set; }

        public int CategoryID { get; set; }
    }
}
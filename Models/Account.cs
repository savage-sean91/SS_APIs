using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS_APIs.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal ReconciledBalance { get; set; }
    }
}
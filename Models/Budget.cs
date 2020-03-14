using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS_APIs.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseholdId { get; set; }
    }
}
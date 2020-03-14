using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SS_APIs.Models
{
    public class PersonalAccount
    {
        public int Id { get; set; }
        /// <summary>
        /// ID of Parent Household
        /// </summary>
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        [Display(Name = "Reconciled Balance")]
        public decimal ReconciledBalance { get; set; }
        public string CreatedById { get; set; }
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsKomodo
{
    
        public enum ClaimTypeVar {Car = 1, Home, Theft}
        public class ClaimInfo
        {
            public int ClaimID { get; set; }
            public ClaimTypeVar ClaimType { get; set; }
            public string Description { get; set; }
            public decimal ClaimAmount { get; set; }
            public DateTime DateOfIncident { get; set; }
            public DateTime DateOfClaim { get; set; }
            public bool IsValid { get; set; }

            public ClaimInfo() {}

            public ClaimInfo(int claimID, ClaimTypeVar claimtype, string description,
                decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
            {
                ClaimID = claimID;
                ClaimType = claimtype;
                Description = description;
                ClaimAmount = claimAmount;
                DateOfIncident = dateOfIncident;
                DateOfClaim = dateOfClaim;
                IsValid = isValid;
            }

        }
}

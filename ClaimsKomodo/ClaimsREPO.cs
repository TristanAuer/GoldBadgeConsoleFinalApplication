using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsKomodo
{
    public class ClaimsREPO
    {
        private List<ClaimInfo> _listOfClaimInfo = new List<ClaimInfo>();
        private Queue<ClaimInfo> queue = new Queue<ClaimInfo>();
        
        //See all Claims
        public List<ClaimInfo> GetClaimInfo()
        {
            return _listOfClaimInfo;
        }
        
        //Take Next Claim
        public Queue<ClaimInfo> NextClaimInQueue()
        {
            return queue;
        }

        //update Claims Queued
        public bool UpdateClaimContent(int origionalInfo, ClaimInfo newInfo)
        {
            ClaimInfo oldInfo = GetClaimInfo(origionalInfo);
            if(oldInfo != null)
            {
                oldInfo.ClaimID = newInfo.ClaimID;
                oldInfo.ClaimType = newInfo.ClaimType;
                oldInfo.Description = newInfo.Description;
                oldInfo.ClaimAmount = newInfo.ClaimAmount;
                oldInfo.DateOfIncident = newInfo.DateOfIncident;
                oldInfo.DateOfClaim = newInfo.DateOfClaim;
                oldInfo.IsValid = newInfo.IsValid;
                return true;
            }
            else { return false; }
        }
        //New Claim
        public void AddClaimInfoToList(ClaimInfo info)
        {
            _listOfClaimInfo.Add(info);
            queue = new Queue<ClaimInfo>(_listOfClaimInfo);
        }

        //Delete invalid claim
        public bool RemoveClaimInfo(int claimID)
        {
            ClaimInfo info = GetClaimInfo(claimID);
            if (info == null)
            {
                return false;
            }
            int initialCount = _listOfClaimInfo.Count;
            _listOfClaimInfo.Remove(info);
            if(initialCount > _listOfClaimInfo.Count)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        //Helper Method
        public ClaimInfo GetClaimInfo(int claimID)
        {
            foreach (ClaimInfo info in _listOfClaimInfo)
            {
                if (info.ClaimID == claimID)
                {
                    return info;
                }
            }

            return null;
        }

    }
}

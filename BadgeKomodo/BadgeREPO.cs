using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeKomodo
{
    class BadgeREPO
    {
        private List<Badge> _listOfBadgeInfo = new List<Badge>();
        public Dictionary<int, Badge> badgeDict = new Dictionary<int, Badge>();
        public Dictionary<string, int> badgeLUT = new Dictionary<string, int>();
        //Create New Badge
        public void AddBadgeInfo(Badge badgeInfo) //Method
        {
            badgeDict.Add(badgeInfo.BadgeID, badgeInfo);
            badgeLUT.Add(badgeInfo.BadgeName, badgeInfo.BadgeID);
        }
        public List<Badge> GetBadgeInfo()
        {

            return _listOfBadgeInfo;
        }
    }
}

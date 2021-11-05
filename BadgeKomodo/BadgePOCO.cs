using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeKomodo
{
    public class Badge //Class
    {
        public int BadgeID { get; set; } //Attribute
        public List<string> DoorName { get; set; }
        public string BadgeName { get; set; }


        public Badge() { } //Constructor

        public Badge(int badgeID, List<string> doorName, string badgeName) //Constructor
        {
            DoorName = new List<string>();
            foreach (string door in doorName)
            {
                DoorName.Add(door);
            }

            BadgeID = badgeID;
            BadgeName = badgeName;


        }


    }
}

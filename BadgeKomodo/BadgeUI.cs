using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeKomodo
{
    class BadgeUI
    {
        private BadgeREPO _badgeRepo = new BadgeREPO();
        public void Run()
        {
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to user
                Console.WriteLine("Hello System Admin.  What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Delete all doors from a badge\n" +
                    "5. Exit application");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        CreateNewBadge();
                        break;
                    case "2":
                        Console.Clear();
                        //EditBadge();
                        break;
                    case "3":
                        Console.Clear();
                        ViewAllBadges();
                        break;
                    case "4":
                        Console.Clear();
                        //DeleteDoors();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Confirm you want to end program (Y/N)");
                        string Leave = Console.ReadLine().ToLower();
                        if (Leave == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Thank you good bye. press any button to exit");
                            Console.ReadKey();
                            keepRunning = false;

                        }
                        else
                        {
                            Console.Clear();
                            Menu();

                        }

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input (1-4).");
                        Menu();
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            

         
        }
        private void CreateNewBadge()
        {
            Badge badgeInfo = new Badge();

            //Badge Name
            Console.WriteLine("Input the new badge name: ");
            badgeInfo.BadgeName = Console.ReadLine();

            //Badge Number/ID
            Console.WriteLine("Input the new badge number/ID: ");
            string stringBadgeNumber = Console.ReadLine();
            int intBadgeNumber = int.Parse(stringBadgeNumber);
            badgeInfo.BadgeID = intBadgeNumber;
            AddDoorsMenu();

            void AddDoorsMenu()
            {
                //Accessable doors
                Console.WriteLine("List a door that this badge will have access to: ");

                //find and add door info
                string doorInput = Console.ReadLine();
                badgeInfo.DoorName.Add(doorInput);

                Console.WriteLine("Would you like to:\n" +
                    "1. Add another door to this badge?\n" +
                    "2. Return to the System Admin menu?");
                string addAnotherDoorInput = Console.ReadLine();
                switch (addAnotherDoorInput)
                {
                    case "1":
                        Console.Clear();
                        AddDoorsMenu();
                        break;
                    case "2":
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine("Now that you're finished, what would you like to do?\n" +
                "1. Create another badge\n" +
                "2. Return to the System Admin menu");
            string createDoorInput = Console.ReadLine();
            switch (createDoorInput)
            {
                case "1":
                    Console.Clear();
                    CreateNewBadge();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Not sure what you meant by that input, so we're going back to the System Admin menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        private void ViewAllBadges()
        {
            //I should be able to view the dictionary exactly how I have it in the Repo, but the method

            Console.WriteLine("All Badges");
            List<Badge> listOfAllBadges = _badgeRepo.GetBadgeInfo();
            foreach (Badge badgeInfo in listOfAllBadges)
            {
                Console.WriteLine($"BadgeID: {badgeInfo.BadgeID}\n" +
                    $"Doors: {badgeInfo.DoorName}");
            }

            Console.WriteLine("Now that you're finished, what would you like to do?\n" +
                "1. Create another badge\n" +
                "2. Return to the System Admin menu");
            string createDoorInput = Console.ReadLine();
            switch (createDoorInput)
            {
                case "1":
                    Console.Clear();
                    CreateNewBadge();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Not sure what you meant by that input, so we're going back to the System Admin menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }

        }
    }
}

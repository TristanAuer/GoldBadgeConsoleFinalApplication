using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsKomodo
{
    class ClaimsUI
    {
        private ClaimsREPO _infoRepo = new ClaimsREPO();

        //method that runs application
        public void Run() { SeedClaim(); Menu();}

        public void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {

                //Create Claim prerun file to fill up claims to work on

                //Claims Agent Menu

                Console.WriteLine("welcome please choose the following items: \n " +
                    "1. See all claims\n " +
                    "2. Take care of next queued claim\n " +
                    "3. Enter a new claim\n " +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        ViewAllClaims();
                        break;
                    case "2":
                        Console.Clear();
                        NextClaim();
                        break;
                    case "3":
                        Console.Clear();
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.Clear();
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void ViewAllClaims()
            {
                    // 1. See all claims
                    Console.WriteLine("The following is all active Claims");
                    List<ClaimInfo> viewClaimInfo = _infoRepo.GetClaimInfo();

            /*For #1, a claims agent could see all items in the queue listed out like this:
            ClaimID 	Type 	Description 	Amount 	DateOfAccident 	DateOfClaim 	IsValid
            1 	Car 	Car accident on 465. 	$400.00 	4/25/18 	4/27/18 	true
            2 	Home 	House fire in kitchen. 	$4000.00 	4/11/18 	4/12/18 	true
            3 	Theft 	Stolen pancakes. 	$4.00 	4/27/18 	6/01/18 	false*/

            
            //figure out how to format correctly
            foreach (ClaimInfo claimInfo in viewClaimInfo)
            {
                Console.WriteLine("Claim ID..Type...Description...............................................Amount...DateOFAccident..DateOfClaim..IsValid" +
                    $"{claimInfo.ClaimID}.{claimInfo.ClaimType}.{claimInfo.Description} ..{claimInfo.ClaimAmount}..{claimInfo.DateOfIncident}.{claimInfo.DateOfClaim}.{claimInfo.IsValid}");
                //Console.WriteLine("{0,-20} {1, 3} {0,-20:N1} {0:0.##} {0:d} {0:d} {%b}", claimContent.ClaimID, 
                //claimContent.ClaimType, claimContent.Description, claimContent.ClaimAmount, claimContent.DateOfIncident, claimContent.DateOfClaim, claimContent.IsValid);
            }

            Console.WriteLine("After viewing all current claims, choose one of the following:\n" +
                "1. Take care of next claim in queue\n" +
                "2. Return to the Claims Agent menu");
            string viewAllClaimsInput = Console.ReadLine();
            switch (viewAllClaimsInput)
            {
                case "1":
                    Console.Clear();
                    NextClaim();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was an invalid option.  Returning to Claims Agent menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        public void NextClaim()
        {
            // 2. Take care of next queued claim

            /* For #2, when a claims agent needs to deal with an item they see the next item in the queue.
            Here are the details for the next claim to be handled:
            ClaimID: 1
            Type: Car
            Description: Car Accident on 464.
            Amount: $400.00
            DateOfAccident: 4/25/18
            DateOfClaim: 4/27/18
            IsValid: True
            Do you want to deal with this claim now(y/n)? y

            When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.*/

            //List<ClaimContent> viewLastClaimContent = _contentRepo.GetClaimContents();

            //Console.WriteLine(viewLastClaimContent.Last());

            Queue<ClaimInfo> viewClaimInfo = _infoRepo.NextClaimInQueue();
            var queue = new Queue<ClaimInfo>(viewClaimInfo);

            //figure out how to format correctly and get the last item

            foreach (ClaimInfo claimContent in queue)
            {
                Console.WriteLine($"Claim ID {claimContent.ClaimID} \n" +
                    $"Claim Type {claimContent.ClaimType} \n" +
                    $"Description {claimContent.Description} \n" +
                    $"Claim Amount {claimContent.ClaimAmount} \n" +
                    $"Date of Incident {claimContent.DateOfIncident} \n" +
                    $"Date of Claim {claimContent.DateOfClaim} \n" +
                    $"Valid Claim? {claimContent.IsValid}");
            }

            Console.WriteLine("Would you like to delete this claim?\n" +
                "1. Yes\n" +
                "2. No, I would like to update the claim\n" +
                "3. No, I would like to move to the next claim in queue" +
                "4. No, take me back to the Claims Agent menu");

            string nextClaimInput = Console.ReadLine();
            switch (nextClaimInput)
            {
                case "1":

                    string deleteInput = Console.ReadLine();
                    int deleteInputAsInt = int.Parse(deleteInput);

                    //call delete method
                    bool wasDeleted = _infoRepo.RemoveClaimInfo(deleteInputAsInt);

                    // if content was deleted, say so
                    // otherwise state it could not be deleted
                    if (wasDeleted)
                    {
                        Console.Clear();
                        Console.WriteLine("The claim was successfully deleted. \n" +
                            "Returning to the Claims Agent menu.");
                        Menu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry, the claim could not be deleted.\n" +
                            "Returning to the Claims Agent menu.");
                        Menu();
                    }
                    break;
                case "2":
                    Console.Clear();
                    
                Console.Clear();


                string updateInput = Console.ReadLine();
                int updateInputAsInt = int.Parse(updateInput);

                ClaimInfo updateClaimContent = new ClaimInfo();

                Console.WriteLine("Enter the new ClaimID:");
                string idAsString = Console.ReadLine();
                updateClaimContent.ClaimAmount = int.Parse(idAsString);


                Console.WriteLine("Enter the new Claim Type:\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft");
                string claimTypeInput = Console.ReadLine();
                int claimTypeAsInt = int.Parse(claimTypeInput);
                updateClaimContent.ClaimType = (ClaimTypeVar)claimTypeAsInt;


                Console.WriteLine("Enter the new Claim Description:");
                updateClaimContent.Description = Console.ReadLine();

                Console.WriteLine("Enter the new Claim Amount:");
                string updateAmountAsString = Console.ReadLine();
                updateClaimContent.ClaimAmount = decimal.Parse(updateAmountAsString);

                Console.WriteLine("Enter the new Date of Incident (YYYY,MM,DD):");
                string dateOfIncAsString = Console.ReadLine();
                updateClaimContent.DateOfIncident = DateTime.Parse(dateOfIncAsString);

                Console.WriteLine($"Date of Claim Update:{DateTime.Today}");
                updateClaimContent.DateOfClaim = DateTime.Today;

                Console.WriteLine("Enter the new claim validity (y / n):");
                string validityAsString = Console.ReadLine();
                updateClaimContent.IsValid = bool.Parse(validityAsString.ToLower());

                bool wasUpdated = _infoRepo.UpdateClaimContent(updateInputAsInt, updateClaimContent);
                if (wasUpdated)
                {
                    Console.WriteLine("Claim has been successfully updated.\n" +
                        "Returning to the Claims Agent menu. Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Sorry, claim could not be updated.\n" +
                        "Returning to the Claims Agent menu. Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                break;
                case "3":
                    //next claim in queue
                    Console.Clear();
                    foreach (ClaimInfo queuedInfo in queue)
                    {
                        Console.WriteLine($"Claim ID {queuedInfo.ClaimID} \n" +
                    $"Claim Type {queuedInfo.ClaimType} \n" +
                    $"Description {queuedInfo.Description} \n" +
                    $"Claim Amount {queuedInfo.ClaimAmount} \n" +
                    $"Date of Incident {queuedInfo.DateOfIncident} \n" +
                    $"Date of Claim {queuedInfo.DateOfClaim} \n" +
                    $"Valid Claim? {queuedInfo.IsValid}");
                    }
                    Console.WriteLine("What would you like to do?\n" +
                    "1. Update claim\n" +
                    "2. Return to the Claims Agent Menu");
                    string moreInput = Console.ReadLine();
                    switch (moreInput)
                    {
                        case "1":
                            Console.Clear();
                            UpdateClaim();
                            break;
                        case "2":
                            Console.Clear();
                            Menu();
                            break;
                        default:
                            Console.Clear();
                            Menu();
                            break;
                    }


                    break;
                case "4":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was an invalid choice.  Bringing you back to the Claims Agent Menu.");
                    Menu();
                    break;
            }
        }
        public void CreateNewClaim()
            {
                // 3.  Enter a new claim

                /* For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:
                Enter the claim id: 4
                Enter the claim type: Car
                Enter a claim description: Wreck on I-70.
                Amount of Damage: $2000.00
                Date Of Accident: 4/27/18
                Date of Claim: 4/28/18
                This claim is valid. */
                ClaimInfo newClaimInfo = new ClaimInfo();

                //Claim ID
                Console.WriteLine("Enter new ClaimID: ");
                string claimIdAsString = Console.ReadLine();
                newClaimInfo.ClaimID = int.Parse(claimIdAsString);

                //Claim type
                Console.WriteLine("Enter new ClaimType:\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft ");
                string claimTypeAsString = Console.ReadLine();
                int claimTypeAsInt = int.Parse(claimTypeAsString);
                newClaimInfo.ClaimType = (ClaimTypeVar)claimTypeAsInt;

                //Description
                Console.WriteLine("Enter new Claim Description: ");
                newClaimInfo.Description = Console.ReadLine();

                //ClaimAmount
                Console.WriteLine("Enter new Claim Amount (Do not use dollar sign [$]): ");
                string claimAmountAsString = Console.ReadLine();
                newClaimInfo.ClaimAmount = decimal.Parse(claimAmountAsString);

                //Date Of Incident
                Console.WriteLine("Enter Date of Incident in [YYYY,MM,DD] format: ");
                string incidentDate = Console.ReadLine();
                newClaimInfo.DateOfIncident = DateTime.Parse(incidentDate);

                //Date of Claim
                DateTime today = DateTime.Today;
                Console.WriteLine($"Date of Claim: {today}");
                newClaimInfo.DateOfClaim = today;

                //Isvalid
                Console.WriteLine("Is the new claim valid? (Y/N) ");
                string validAsString = Console.ReadLine().ToLower();

                if (validAsString == "y")
                {
                    newClaimInfo.IsValid = true;
                }
                else
                {
                    newClaimInfo.IsValid = false;
                }

                _infoRepo.AddClaimInfoToList(newClaimInfo);

                Console.WriteLine("New claim created! Would you like to:\n" +
                    "1. Create another new claim\n" +
                    "2. Take care of next claim in queue\n" +
                    "3. Return to Claims Agent menu");
                string newClaimInput = Console.ReadLine();
                switch (newClaimInput)
                {
                    case "1":
                        Console.Clear();
                        CreateNewClaim();
                        break;
                    case "2":
                        Console.Clear();
                        NextClaim();
                        break;
                    case "3":
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("That was not a valid option.  Returning to menu.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                        break;
                }

            }
        public void UpdateClaim()
        {
            List<ClaimInfo> viewClaimContent = _infoRepo.GetClaimInfo();

            //figure out how to format correctly
            foreach (ClaimInfo claimContent in viewClaimContent)
            {
                Console.WriteLine($"Claim ID {claimContent.ClaimID} \n" +
                    $"Claim Type {claimContent.ClaimType} \n" +
                    $"Description {claimContent.Description} \n" +
                    $"Claim Amount {claimContent.ClaimAmount} \n" +
                    $"Date of Incident {claimContent.DateOfIncident} \n" +
                    $"Date of Claim {claimContent.DateOfClaim} \n" +
                    $"Valid Claim? {claimContent.IsValid}\n" +
                    $"......");
            }

            Console.WriteLine("Enter the Claim ID of the claim you'd like to update:");

            string updateInput = Console.ReadLine();
            int updateInputAsInt = int.Parse(updateInput);

            ClaimInfo updateClaimContent = new ClaimInfo();

            Console.WriteLine("Enter the new ClaimID:");
            string idAsString = Console.ReadLine();
            updateClaimContent.ClaimAmount = int.Parse(idAsString);

            Console.WriteLine("Enter the new Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeInput = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeInput);
            updateClaimContent.ClaimType = (ClaimTypeVar)claimTypeAsInt;


            Console.WriteLine("Enter the new Claim Description:");
            updateClaimContent.Description = Console.ReadLine();

            Console.WriteLine("Enter the new Claim Amount:");
            string updateAmountAsString = Console.ReadLine();
            updateClaimContent.ClaimAmount = decimal.Parse(updateAmountAsString);

            Console.WriteLine("Enter the new Date of Incident (YYYY,MM,DD):");
            string dateOfIncAsString = Console.ReadLine();
            updateClaimContent.DateOfIncident = DateTime.Parse(dateOfIncAsString);

            Console.WriteLine($"Date of Claim Update:{DateTime.Today}");
            updateClaimContent.DateOfClaim = DateTime.Today;

            Console.WriteLine("Enter the new claim validity (y / n):");
            string validityAsString = Console.ReadLine();
            updateClaimContent.IsValid = bool.Parse(validityAsString.ToLower());

            bool wasUpdated = _infoRepo.UpdateClaimContent(updateInputAsInt, updateClaimContent);
            if (wasUpdated)
            {
                Console.WriteLine("Claim has been successfully updated.");
            }
            else
            {
                Console.WriteLine("Sorry, claim could not be updated.");
            }
            Console.WriteLine(" ......\n" +
                "Now that you've updated a claim, what would you like to do?\n" +
                "1. Return to Claim Agent menu\n" +
                "2. Update another claim");
            string doneUpdatingInput = Console.ReadLine();
            switch (doneUpdatingInput)
            {
                case "1":
                    Console.Clear();
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    UpdateClaim();
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        private void SeedClaim()
        { 
            ClaimInfo SeedClaim1 = new ClaimInfo(12345678, ClaimTypeVar.Home, 
                "High winds from storm pulled roofing off, rain got in.", 8000m,
                DateTime.ParseExact("20071122", "yyyyMMdd", null, System.Globalization.DateTimeStyles.None),
                DateTime.Now, true);
            ClaimInfo SeedClaim2 = new ClaimInfo(12324566, ClaimTypeVar.Car,
                "Fender Bender. front end collison on highway", 500m,
                DateTime.ParseExact("20161208", "yyyyMMdd", null, System.Globalization.DateTimeStyles.None),
                DateTime.Now, true);
            ClaimInfo SeedClaim3 = new ClaimInfo(93842753, ClaimTypeVar.Theft,
                "home invasion, back from vacation missing all TVs and other electronics", 2000m,
                DateTime.ParseExact("20201229", "yyyyMMdd", null, System.Globalization.DateTimeStyles.None),
                DateTime.Now, true);

            _infoRepo.AddClaimInfoToList(SeedClaim1);
            _infoRepo.AddClaimInfoToList(SeedClaim2);
            _infoRepo.AddClaimInfoToList(SeedClaim3);
        }
    }
}

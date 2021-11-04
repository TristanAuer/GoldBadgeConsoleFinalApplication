using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanKomodo
{
    class GreenUI
    {
        private GreenREPO _carInfoRepo = new GreenREPO();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                Console.WriteLine("Insurance Agent menu.  What would you like to do?\n" +
                    "1. Create new car profile\n" +
                    "2. Update a car profile\n" +
                    "3. Delete a car profile\n" +
                    "4. View all car profiles\n" +
                    "5. Exit application");
                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        Console.Clear();
                        CreateCarProfile();
                        break;
                    case "2":
                        Console.Clear();
                        UpdateCarProfile();
                        break;
                    case "3":
                        Console.Clear();
                        DeleteCarProfile();
                        break;
                    case "4":
                        Console.Clear();
                        ListAllCarProfiles();
                        break;
                    case "5":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
            }
        }

        public void CreateCarProfile()
        {
            CarInformation newCarInfo = new CarInformation();

            // car make
            Console.WriteLine("Car make/manufacturer: ");
            newCarInfo.CarMake = Console.ReadLine();

            // car name
            Console.WriteLine("Car name: ");
            newCarInfo.CarName = Console.ReadLine();

            // car year
            Console.WriteLine("Car year (YYYY): ");
            string yearAsString = Console.ReadLine();
            newCarInfo.CarYear = int.Parse(yearAsString);

            // car type
            Console.WriteLine("Car type:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas ");
            string carTypeInput = Console.ReadLine();
            int carTypeAsInt = int.Parse(carTypeInput);
            newCarInfo.CarType = (CarType)carTypeAsInt;


            // car size
            Console.WriteLine("Car size:\n" +
                "1. Wagon\n" +
                "2. Sedan\n" +
                "3. Crossover\n" +
                "4. Coupe\n" +
                "5. Hatchback\n" +
                "6. Minivan\n" +
                "7. SUV\n" +
                "8. Truck ");
            string carSizeInput = Console.ReadLine();
            int carSizeAsInt = int.Parse(carSizeInput);
            newCarInfo.CarSize = (CarSize)carSizeAsInt;

            // mpg
            Console.WriteLine("Car Miles Per Gallon (MPG) [Input whole number]: ");
            string mpgAsString = Console.ReadLine();
            newCarInfo.MilesPerGallon = int.Parse(mpgAsString);

            //range per charge
            Console.WriteLine("Car Range Per Charge (RPC) [Input whole number]: ");
            string rpcAsString = Console.ReadLine();
            newCarInfo.RangePerCharge = int.Parse(rpcAsString);

            // engine size
            Console.WriteLine("Car engine size (Ex: 3.0L V6): ");
            newCarInfo.EngineSize = Console.ReadLine();

            _carInfoRepo.AddCarInfoToList(newCarInfo);

            Console.WriteLine(" \n" +
                "//////\n" +
                " \n" +
                "Now that you've created a car profile, what would you like to do?\n" +
                "1. Return to Insurance Agent menu\n" +
                "2. Create another new car profile");
            string listAllInput = Console.ReadLine();
            switch (listAllInput)
            {
                case "1":
                    Console.Clear();
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    CreateCarProfile();
                    break;
                default:
                    Console.WriteLine("That was not a valid input.  Taking you back to the Insurance Agent menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        public void UpdateCarProfile()
        {
            //display all car profiles
            List<CarInformation> listOfAllCarInfo = _carInfoRepo.GetCarInformation();

            foreach (CarInformation carInformation in listOfAllCarInfo)
            {

                Console.WriteLine($"Make: {carInformation.CarMake} \n" +
                    $"Name: {carInformation.CarName} \n" +
                    $"Year: {carInformation.CarYear} \n" +
                    $"Size: {carInformation.CarSize} \n" +
                    $"Type: {carInformation.CarType} \n" +
                    $"MPG: {carInformation.MilesPerGallon} \n" +
                    $"Range: {carInformation.RangePerCharge} \n" +
                    $"Engine Size: {carInformation.EngineSize} \n" +
                    $" \n" +
                    $"......\n" +
                    $" ");

            }

            //ask for name looking to update
            Console.WriteLine("Enter the name of the car you would like to update:");

            //get the name
            string updateInput = Console.ReadLine();

            //build a new object (override)
            CarInformation newCarInfo = new CarInformation();

            // car make
            Console.WriteLine("Car make/manufacturer: ");
            newCarInfo.CarMake = Console.ReadLine();

            // car name
            Console.WriteLine("Car name: ");
            newCarInfo.CarName = Console.ReadLine();

            // car year
            Console.WriteLine("Car year (YYYY): ");
            string yearAsString = Console.ReadLine();
            newCarInfo.CarYear = int.Parse(yearAsString);

            // car type
            Console.WriteLine("Car type:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas ");
            string carTypeInput = Console.ReadLine();
            int carTypeAsInt = int.Parse(carTypeInput);
            newCarInfo.CarType = (CarType)carTypeAsInt;


            // car size
            Console.WriteLine("Car size:\n" +
                "1. Wagon\n" +
                "2. Sedan\n" +
                "3. Crossover\n" +
                "4. Coupe\n" +
                "5. Hatchback\n" +
                "6. Minivan\n" +
                "7. SUV\n" +
                "8. Truck ");
            string carSizeInput = Console.ReadLine();
            int carSizeAsInt = int.Parse(carSizeInput);
            newCarInfo.CarSize = (CarSize)carSizeAsInt;

            // mpg
            Console.WriteLine("Car Miles Per Gallon (MPG) [Input whole number]: ");
            string mpgAsString = Console.ReadLine();
            newCarInfo.MilesPerGallon = int.Parse(mpgAsString);

            //range per charge
            Console.WriteLine("Car Range Per Charge (RPC) [Input whole number]: ");
            string rpcAsString = Console.ReadLine();
            newCarInfo.RangePerCharge = int.Parse(rpcAsString);

            // engine size
            Console.WriteLine("Car engine size (Ex: 3.0L V6): ");
            newCarInfo.EngineSize = Console.ReadLine();

            //Verify update worked
            bool wasUpdated = _carInfoRepo.UpdateExistingCarInfo(updateInput, newCarInfo);

            if (wasUpdated)
            {
                Console.WriteLine("Car profile has been successfully updated.");
            }
            else
            {
                Console.WriteLine("Sorry, the car profile could not be updated.");
            }
            Console.WriteLine(" \n" +
                "//////\n" +
                " \n" +
                "Now that you've updated a car profile, what would you like to do?\n" +
                "1. Return to Insurance Agent menu\n" +
                "2. Update another car profile");
            string listAllInput = Console.ReadLine();
            switch (listAllInput)
            {
                case "1":
                    Console.Clear();
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    UpdateCarProfile();
                    break;
                default:
                    Console.WriteLine("That was not a valid input.  Taking you back to the Insurance Agent menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        public void DeleteCarProfile()
        {
            //Listing all car profiles
            List<CarInformation> listOfAllCarInfo = _carInfoRepo.GetCarInformation();

            foreach (CarInformation carInformation in listOfAllCarInfo)
            {

                Console.WriteLine($"Make: {carInformation.CarMake} \n" +
                    $"Name: {carInformation.CarName} \n" +
                    $"Year: {carInformation.CarYear} \n" +
                    $"Size: {carInformation.CarSize} \n" +
                    $"Type: {carInformation.CarType} \n" +
                    $"MPG: {carInformation.MilesPerGallon} \n" +
                    $"Range: {carInformation.RangePerCharge} \n" +
                    $"Engine Size: {carInformation.EngineSize} \n" +
                    $" \n" +
                    $"......\n" +
                    $" ");

            }

            // Get the name they want to delete
            Console.WriteLine("\nEnter the name of the car you would like to remove:");

            string deleteInput = Console.ReadLine();

            //call delete method
            bool wasDeleted = _carInfoRepo.RemoveCarInfoFromList(deleteInput);

            // if content was deleted, say so
            // otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The car profile was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Sorry, the car name was not found and the car profile could not be deleted.");
            }

            Console.WriteLine(" \n" +
                "//////\n" +
                " \n" +
                "Now that you've deleted a car profile, what would you like to do?\n" +
                "1. Return to Insurance Agent menu\n" +
                "2. View all car profiles");
            string listAllInput = Console.ReadLine();
            switch (listAllInput)
            {
                case "1":
                    Console.Clear();
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    ListAllCarProfiles();
                    break;
                default:
                    Console.WriteLine("That was not a valid input.  Taking you back to the Insurance Agent menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        public void ListAllCarProfiles()
        {
            List<CarInformation> listOfAllCarInfo = _carInfoRepo.GetCarInformation();
            Console.WriteLine("Please enter a car profile(s) before viewing all car profiles.\n" +
                    " \n" +
                    "//////\n" +
                    " ");

            foreach (CarInformation carInformation in listOfAllCarInfo)
            {

                Console.WriteLine($"Make: {carInformation.CarMake} \n" +
                    $"Name: {carInformation.CarName} \n" +
                    $"Year: {carInformation.CarYear} \n" +
                    $"Size: {carInformation.CarSize} \n" +
                    $"Type: {carInformation.CarType} \n" +
                    $"MPG: {carInformation.MilesPerGallon} \n" +
                    $"Range: {carInformation.RangePerCharge} \n" +
                    $"Engine Size: {carInformation.EngineSize} \n" +
                    $" \n" +
                    $"......\n" +
                    $" ");

            }
            Console.WriteLine(" \n" +
                "//////\n" +
                " \n" +
                "Now that you've viewed all car profiles, what would you like to do?\n" +
                "1. Return to Insurance Agent menu\n" +
                "2. Create a new car profile");
            string listAllInput = Console.ReadLine();
            switch (listAllInput)
            {
                case "1":
                    Console.Clear();
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    CreateCarProfile();
                    break;
                default:
                    Console.WriteLine("That was not a valid input.  Taking you back to the Insurance Agent menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }
}

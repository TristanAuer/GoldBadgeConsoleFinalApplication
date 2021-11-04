using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanKomodo
{
    public enum CarType
    {
        Electric = 1,
        Hybrid,
        Gas
    }

    public enum CarSize
    {
        Wagon = 1,
        Sedan = 2,
        Crossover = 3,
        Coupe = 4,
        Hatchback = 5,
        Minivan = 6,
        SUV = 7,
        Truck = 8
    }

    public class CarInformation
    {
        public string CarMake { get; set; }
        public string CarName { get; set; }
        public int CarYear { get; set; }
        public CarSize CarSize { get; set; }
        public CarType CarType { get; set; }
        public int MilesPerGallon { get; set; }
        public int RangePerCharge { get; set; }
        public string EngineSize { get; set; }

        public CarInformation() { }

        public CarInformation(string carMake, string carName, int carYear, CarSize carSize, CarType carType, int milesPerGallon, int rangePerCharge, string engineSize)
        {
            CarMake = carMake;
            CarName = carName;
            CarYear = carYear;
            CarSize = carSize;
            CarType = carType;
            MilesPerGallon = milesPerGallon;
            RangePerCharge = rangePerCharge;
            EngineSize = engineSize;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanKomodo
{
    public class GreenREPO
    {
        private List<CarInformation> _listOfCarInformation = new List<CarInformation>();

        //Create
        public void AddCarInfoToList(CarInformation info)
        {
            _listOfCarInformation.Add(info);
        }

        //Read
        public List<CarInformation> GetCarInformation()
        {
            return _listOfCarInformation;
        }

        //Update and/or Pull
        public bool UpdateExistingCarInfo(string originalInfo, CarInformation newInfo)
        {
            //find the info
            CarInformation oldInfo = GetInfoByName(originalInfo);

            //update the info
            if (oldInfo != null)
            {
                oldInfo.CarMake = newInfo.CarMake;
                oldInfo.CarName = newInfo.CarName;
                oldInfo.CarYear = newInfo.CarYear;
                oldInfo.CarType = newInfo.CarType;
                oldInfo.CarSize = newInfo.CarSize;
                oldInfo.MilesPerGallon = newInfo.MilesPerGallon;
                oldInfo.RangePerCharge = newInfo.RangePerCharge;
                oldInfo.EngineSize = newInfo.EngineSize;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveCarInfoFromList(string name)
        {
            CarInformation info = GetInfoByName(name);

            if (info == null)
            {
                return false;
            }

            int initialCount = _listOfCarInformation.Count;
            _listOfCarInformation.Remove(info);

            if (initialCount > _listOfCarInformation.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper method
        public CarInformation GetInfoByName(string name)
        {
            foreach (CarInformation info in _listOfCarInformation)
            {
                if (info.CarName == name)
                {
                    return info;
                }
            }

            return null;
        }
    }
}

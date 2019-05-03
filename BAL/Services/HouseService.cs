using System.Collections.Generic;
using BAL.Exceptions;
using DAL.Operations;
using Shared.DTOs;

namespace BAL.Services
{
    public class HouseService
    {
        private HouseOperations op;
        public HouseService()
        {
            op = new HouseOperations();
        }

        public List<HouseDTO> GetAllHouses()
        {
            return op.GetAllHouses();
        }

        public HouseDTO GetHouseByID(int id)
        {
            var house = op.GetHouseByID(id);
            if (house != null)
            {
                return house;
            }
            else
            {
                throw new HouseDoesNotExistException(id);
            }
        }

        public HouseDTO AddUpdateHouse(HouseDTO u)
        {
            return op.AddUpdateHouse(u);
        }

        public HouseDTO DeleteHouse(int id)
        {
            var house = GetHouseByID(id);
            if (house != null)
            {
                return op.DeleteHouse(house);
            }
            else
            {
                throw new HouseDoesNotExistException(id);
            }
        }

        public Dictionary<string,int> GetStateWisePopulation()
        {
            return op.GetStateWisePopulation();
        }

    }
}

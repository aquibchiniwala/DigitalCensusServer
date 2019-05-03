using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Helpers;
using Shared.DTOs;

namespace DAL.Operations
{
    public class HouseOperations
    {
        private CensusContext db;

        public HouseOperations()
        {
            db = new CensusContext();
        }

        public List<HouseDTO> GetAllHouses()
        {
            return HouseMapper.EntitytoDTOHouseList(db.Houses.ToList());
        }

        public HouseDTO GetHouseByID(int id)
        {
            var house = db.Houses.Find(id);
            return HouseMapper.EntitytoDTOHouse(house);
        }

        public HouseDTO AddUpdateHouse(HouseDTO u)
        {
            var newHouse = HouseMapper.DTOtoEntityHouse(u);
            db.Houses.AddOrUpdate(newHouse);
            db.SaveChanges();
            return HouseMapper.EntitytoDTOHouse(newHouse);
        }

        public HouseDTO DeleteHouse(HouseDTO u)
        {
            var house = db.Houses.Find(u.CensusHouseNumber);
            house = db.Houses.Remove(house);
            db.SaveChanges();
            return HouseMapper.EntitytoDTOHouse(house);
        }

        public Dictionary<string, int> GetStateWisePopulation()
        {
            Dictionary<string, int> population = new Dictionary<string, int>();
            var groupState = db.Houses.GroupBy(x => x.State).
                             Select(g => new { g.Key, TotalPopulation = g.Sum(x => x.Persons.Count) }).ToArray();

            foreach (var state in groupState)
            {
                population.Add(state.Key, state.TotalPopulation);
            }


            return population;
        }
    }
}

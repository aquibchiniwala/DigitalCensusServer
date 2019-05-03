using System.Collections.Generic;
using AutoMapper;
using DAL.Entities;
using Shared.DTOs;

namespace DAL.Helpers
{
    public static class HouseMapper
    {
        private static MapperConfiguration config = new MapperConfiguration(c =>
        {
            c.CreateMap<House, HouseDTO>().ReverseMap();
        });
        private static IMapper mapper = config.CreateMapper();

        public static House DTOtoEntityHouse(HouseDTO u)
        {
            return mapper.Map<House>(u);
        }
        public static HouseDTO EntitytoDTOHouse(House u)
        {
            return mapper.Map<HouseDTO>(u);
        }
        public static List<House> DTOtoEntityHouseList(List<HouseDTO> u)
        {
            return mapper.Map<List<House>>(u);
        }
        public static List<HouseDTO> EntitytoDTOHouseList(List<House> u)
        {
            return mapper.Map<List<HouseDTO>>(u);
        }

    }
}
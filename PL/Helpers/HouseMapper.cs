using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PL.Models;
using Shared.DTOs;

namespace MVC.Helpers
{
    public static class HouseMapper
    {
        private static MapperConfiguration config = new MapperConfiguration(c =>
        {
            c.CreateMap<HouseViewModel, HouseDTO>().ReverseMap();
        });
        private static IMapper mapper = config.CreateMapper();

        public static HouseViewModel DTOtoVMHouse(HouseDTO h)
        {
            return mapper.Map<HouseViewModel>(h);
        }
        public static HouseDTO VMtoDTOHouse(HouseViewModel h)
        {
            return mapper.Map<HouseDTO>(h);
        }
        public static List<HouseViewModel> DTOtoVMHouseList(List<HouseDTO> h)
        {
            return mapper.Map<List<HouseViewModel>>(h);
        }
        public static List<HouseDTO> VMtoDTOHouseList(List<HouseViewModel> h)
        {
            return mapper.Map<List<HouseDTO>>(h);
        }
    }
}
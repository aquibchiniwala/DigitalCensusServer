using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PL.Models;
using Shared.DTOs;

namespace MVC.Helpers
{
    public static class UserMapper
    {
        private static MapperConfiguration config = new MapperConfiguration(c =>
        {
            c.CreateMap<UserViewModel, UserDTO>().ReverseMap();
        });
        private static IMapper mapper = config.CreateMapper();

        public static UserViewModel DTOtoVMUser(UserDTO u)
        {
            return mapper.Map<UserViewModel>(u);
        }
        public static UserDTO VMtoDTOUser(UserViewModel u)
        {
            return mapper.Map<UserDTO>(u);
        }
        public static List<UserViewModel> DTOtoVMUserList(List<UserDTO> u)
        {
            return mapper.Map<List<UserViewModel>>(u);
        }
        public static List<UserDTO> VMtoDTOUserList(List<UserViewModel> u)
        {
            return mapper.Map<List<UserDTO>>(u);
        }
    }
}
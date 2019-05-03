using System.Collections.Generic;
using AutoMapper;
using DAL.Entities;
using Shared.DTOs;

namespace DAL.Helpers
{
    public static class UserMapper
    {
        private static MapperConfiguration config = new MapperConfiguration(c =>
        {
            c.CreateMap<User, UserDTO>().ReverseMap();
        });
        private static IMapper mapper = config.CreateMapper();

        public static User DTOtoEntityUser(UserDTO u)
        {
            return mapper.Map<User>(u);
        }
        public static UserDTO EntitytoDTOUser(User u)
        {
            return mapper.Map<UserDTO>(u);
        }
        public static List<User> DTOtoEntityUserList(List<UserDTO> u)
        {
            return mapper.Map<List<User>>(u);
        }
        public static List<UserDTO> EntitytoDTOUserList(List<User> u)
        {
            return mapper.Map<List<UserDTO>>(u);
        }

    }
}
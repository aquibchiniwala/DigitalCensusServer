using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVC.Models;
using Shared.DTOs;

namespace MVC.Helper
{
    public static class LoginMapper
    {
        private static MapperConfiguration config = new MapperConfiguration(c =>
        {
            c.CreateMap<LoginViewModel, UserDTO>().ReverseMap();
        });
        private static IMapper mapper = config.CreateMapper();

        public static LoginViewModel DTOtoVMLogin(UserDTO u)
        {
            return mapper.Map<LoginViewModel>(u);
        }
        public static UserDTO VMtoDTOLogin(LoginViewModel u)
        {
            return mapper.Map<UserDTO>(u);
        }
    }
}
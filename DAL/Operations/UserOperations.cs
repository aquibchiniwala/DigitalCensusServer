using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Entities;
using DAL.Helpers;
using Shared.DTOs;
using Shared.Enums;

namespace DAL.Operations
{
    public class UserOperations
    {
        private CensusContext db;

        public UserOperations()
        {
            db = new CensusContext();
        }

        public List<UserDTO> GetAllUsers(ApprovalStatus status)
        {
            return UserMapper.EntitytoDTOUserList(db.Users.Where(s=>s.ApprovalStatus==status).ToList());
        }
        public UserDTO GetUserByID(int id)
        {
            var user = db.Users.Find(id);
            return UserMapper.EntitytoDTOUser(user);
        }
        public UserDTO AddUpdateUser(UserDTO u)
        {
            var newUser = UserMapper.DTOtoEntityUser(u);
            db.Users.AddOrUpdate(newUser);
            db.SaveChanges();
            return UserMapper.EntitytoDTOUser(newUser);
        }
        public UserDTO GetUserByEmail(string email)
        {
            var user = db.Users.Where(e => e.Email == email).Select(u => u).FirstOrDefault<User>() ?? null;
            return UserMapper.EntitytoDTOUser(user);
        }
        public UserDTO GetUserByAadhar(string aadharNumber)
        {
            var user = db.Users.Where(e => e.AadharNumber == aadharNumber).Select(u => u).FirstOrDefault<User>() ?? null;
            return UserMapper.EntitytoDTOUser(user);
        }
        public UserDTO Login(UserDTO u)
        {
            using (CensusContext dbContext = new CensusContext())
            {
                var user = dbContext.Users.Where(x => x.Email == u.Email && x.Password == u.Password).Select(x => x).FirstOrDefault<User>() ?? null;
                var userDTO = UserMapper.EntitytoDTOUser(user);
                return userDTO;
            }
        }
        public UserDTO DeleteUser(UserDTO u)
        {
            var user = db.Users.Find(u.UserID);
            user = db.Users.Remove(user);
            db.SaveChanges();
            return UserMapper.EntitytoDTOUser(user);
        }
    }
}

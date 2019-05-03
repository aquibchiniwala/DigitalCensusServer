using System.Collections.Generic;
using BAL.Exceptions;
using DAL.Operations;
using Shared.DTOs;
using Shared.Enums;

namespace BAL.Services
{
    public class UserService
    {
        private UserOperations op;
        public UserService()
        {
            op = new UserOperations();
        }

        public List<UserDTO> GetAllUsers(ApprovalStatus status)
        {
            return op.GetAllUsers(status);
        }
        public UserDTO GetUserByID(int id)
        {
            var user = op.GetUserByID(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserDoesNotExistException(id);
            }
        }
        private bool DoesUserExist(string email)
        {
            var user = op.GetUserByEmail(email);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool DoesAadharExist(string aadharNumber)
        {
            var user = op.GetUserByAadhar(aadharNumber);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public UserDTO AddUser(UserDTO u)
        {
            
            if (DoesUserExist(u.Email))
            {
                throw new UserAlreadyExistsException("EmailID Already Exist, Try another email.");
            }
            else if (DoesAadharExist(u.AadharNumber))
            {
                throw new UserAlreadyExistsException("Aadhar Number Already Exist.");
            }
            else
            {
                return op.AddUpdateUser(u);
            }

        }
        public UserDTO EditUser(UserDTO u)
        {
            var oldEmail = op.GetUserByID(u.UserID).Email;
            var newEmail = u.Email;
            if (!oldEmail.Equals(newEmail))
            {
                return AddUser(u);
            }
            else
            {
                return op.AddUpdateUser(u);
            }
        }
        public UserDTO Login(UserDTO u)
        {
            var user = op.Login(u);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        public UserDTO DeleteUser(int id)
        {
            var user = GetUserByID(id);
            if (user != null)
            {
                 return op.DeleteUser(user);
            }
            else
            {
                throw new UserDoesNotExistException(id);
            }
        }

        public UserDTO ChangeApprovalStatus(int id, ApprovalStatus newStatus)
        {
            var user = GetUserByID(id);
            if (user != null)
            {
                user.ApprovalStatus = newStatus;
                return op.AddUpdateUser(user);
            }
            else
            {
                throw new UserDoesNotExistException(id);
            }
        }

    }
}

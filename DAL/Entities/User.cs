using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;
using Shared.Enums;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string AadharNumber { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}

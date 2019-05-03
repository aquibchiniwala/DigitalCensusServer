using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Shared.Enums;

namespace PL.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Za-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string Password { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Image is Required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Aadhar Number is Required")]
        [RegularExpression(".{12}")]
        public string AadharNumber { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<HouseViewModel> Houses { get; set; }
    }
}
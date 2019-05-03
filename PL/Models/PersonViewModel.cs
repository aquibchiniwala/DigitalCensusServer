using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Shared.Enums;

namespace PL.Models
{
    public class PersonViewModel
    {
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Full Name is Required")]
        public string FullName { get; set; }
        //[Required(ErrorMessage = "Census House Number is Required")]
        public int CensusHouseNumber { get; set; }
        [Required(ErrorMessage = "Relation To Head is Required")]
        public RelationToHead RelationToHead { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Date Of Birth is Required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Marital Status is Required")]
        public MaritalStatus MaritalStatus { get; set; }
        public int? AgeAtMarriage { get; set; }
        [Required(ErrorMessage = "Occupation is Required")]
        public Occupation Occupation { get; set; }
        public string OccupationIndustry { get; set; }
        public HouseViewModel House { get; set; }
    }
}
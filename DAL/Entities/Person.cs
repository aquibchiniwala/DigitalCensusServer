using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Entities
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public int CensusHouseNumber { get; set; }
        public RelationToHead RelationToHead { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth {get;set;}
        public MaritalStatus MaritalStatus { get; set; }
        public int? AgeAtMarriage { get; set; }
        public Occupation Occupation { get; set; }
        public string OccupationIndustry { get; set; }
        public House House { get; set; }
    }
}

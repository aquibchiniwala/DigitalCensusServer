using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.DTOs
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public int CensusHouseNumber { get; set; }
        public RelationToHead RelationToHead { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int? AgeAtMarriage { get; set; }
        public Occupation Occupation { get; set; }
        public string OccupationIndustry { get; set; }
        public HouseDTO House { get; set; }
    }
}

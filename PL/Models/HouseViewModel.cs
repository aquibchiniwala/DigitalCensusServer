using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Shared.Enums;

namespace PL.Models
{
    public class HouseViewModel
    {
        public int CensusHouseNumber { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string HeadFullName { get; set; }
        public OwnershipStatus OwnershipStatus { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        public UserViewModel User { get; set; }
        [Required]
        public PersonViewModel[] Persons { get; set; }
    }
}
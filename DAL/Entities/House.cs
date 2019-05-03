using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Entities
{
    public class House
    {
        [Key]
        public int CensusHouseNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string HeadFullName { get; set; }
        public OwnershipStatus OwnershipStatus { get; set; }
        public int NumberOfRooms { get; set; }
        public User User { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

    }
}

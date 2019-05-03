using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.DTOs
{
    public class HouseDTO
    {
        public int CensusHouseNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string HeadFullName { get; set; }
        public OwnershipStatus OwnershipStatus { get; set; }
        public int NumberOfRooms { get; set; }
        public UserDTO User { get; set; }
        public virtual ICollection<PersonDTO> Persons { get; set; }
    }
}

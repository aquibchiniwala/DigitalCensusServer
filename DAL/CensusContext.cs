using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class CensusContext : DbContext
    {
    
        public CensusContext() : base("name=DigitalCensus")
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
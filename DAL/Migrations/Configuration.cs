using System.Data.Entity.Migrations;
using DAL.Entities;
using Shared.Enums;
namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.CensusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CensusContext context)
        {
            User approver = new User { Email = "approver@census.com", Password = "password", FirstName = "Aquib", LastName = "Chiniwala", AadharNumber = "123456789012", Role = Role.Volunteer };
            context.Users.Add(approver);
            context.SaveChanges();
        }
    }
}

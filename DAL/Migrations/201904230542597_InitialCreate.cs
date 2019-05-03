namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        CensusHouseNumber = c.Int(nullable: false, identity: true),
                        BuildingNumber = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        HeadFullName = c.String(),
                        OwnershipStatus = c.Int(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CensusHouseNumber)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        CensusHouseNumber = c.Int(nullable: false),
                        RelationToHead = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        AgeAtMarriage = c.Int(),
                        Occupation = c.Int(nullable: false),
                        OccupationIndustry = c.String(),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Houses", t => t.CensusHouseNumber, cascadeDelete: true)
                .Index(t => t.CensusHouseNumber);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Image = c.String(),
                        AadharNumber = c.String(),
                        ApprovalStatus = c.Int(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.People", "CensusHouseNumber", "dbo.Houses");
            DropIndex("dbo.People", new[] { "CensusHouseNumber" });
            DropIndex("dbo.Houses", new[] { "User_UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.People");
            DropTable("dbo.Houses");
        }
    }
}

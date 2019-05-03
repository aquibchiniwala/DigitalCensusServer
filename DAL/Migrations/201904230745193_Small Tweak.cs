namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallTweak : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ApprovalStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ApprovalStatus", c => c.Int());
        }
    }
}

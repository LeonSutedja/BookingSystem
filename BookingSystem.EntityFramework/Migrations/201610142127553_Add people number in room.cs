namespace BookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpeoplenumberinroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "NumberOfPeople", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "NumberOfPeople");
        }
    }
}

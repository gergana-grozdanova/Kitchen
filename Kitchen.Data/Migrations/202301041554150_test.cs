namespace Kitchen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Level", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Level");
        }
    }
}

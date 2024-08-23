namespace mvcAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumnsToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Photo", c => c.String());
            AddColumn("dbo.Employees", "AlternateText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "AlternateText");
            DropColumn("dbo.Employees", "Photo");
        }
    }
}

namespace mvcAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdaugaConfirmEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ConfirmEmailAdress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ConfirmEmailAdress");
        }
    }
}

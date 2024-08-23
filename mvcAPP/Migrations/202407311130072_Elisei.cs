namespace mvcAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Elisei : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Salary = c.Int(nullable: false),
                        PersonalWebSite = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}

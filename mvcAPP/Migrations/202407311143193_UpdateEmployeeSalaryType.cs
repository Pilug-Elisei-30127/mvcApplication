namespace mvcAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeSalaryType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Salary", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Gender", c => c.String());
            AlterColumn("dbo.Employees", "FullName", c => c.String());
        }
    }
}

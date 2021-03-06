namespace MVC_Garage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class garage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleType = c.Int(nullable: false),
                        RegNum = c.String(nullable: false, maxLength: 10),
                        Color = c.Int(nullable: false),
                        Brand = c.String(nullable: false, maxLength: 10),
                        Model = c.String(nullable: false, maxLength: 10),
                        NumOfWheels = c.Int(nullable: false),
                        ParkedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkedVehicles");
        }
    }
}

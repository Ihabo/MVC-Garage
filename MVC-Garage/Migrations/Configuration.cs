namespace MVC_Garage.Migrations
{
    using MVC_Garage.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Garage.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_Garage.DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            ParkedVehicle vehicle = new ParkedVehicle()
            {
                VehicleType = VehicleType.Car,
                RegNum = "WWE-324",
                Color = Color.Brown,
                Brand = "Volvo",
                Model = "V70",
                NumOfWheels = 4,
                ParkedTime = DateTime.Now
            };

            context.ParkedVehicles.AddOrUpdate(v => v.RegNum, vehicle);
        
        }
    }
}

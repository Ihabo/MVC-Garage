using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Garage.DataAccessLayer
{
    public class GarageContext: DbContext
    {
        public GarageContext(): base("GarageConnection")
        {

        }

        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }

    }
}
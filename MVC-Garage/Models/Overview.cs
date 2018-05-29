using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Garage.Models
{
    public class Overview
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display (Name ="Type")]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Registration Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string RegNum { get; set; }

        [Display(Name = "Color")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public Color Color { get; set; }

        [Display(Name = "Parking Time")]
        public DateTime ParkedTime { get; set; }



        public Overview(ParkedVehicle v)
        {
            Id = v.Id;
            VehicleType = v.VehicleType;
            RegNum = v.RegNum;
            Color = v.Color;
            ParkedTime = v.ParkedTime;
        }
    }


}
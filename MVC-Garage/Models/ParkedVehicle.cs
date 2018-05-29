using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Garage.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "Type")]
        public VehicleType VehicleType { get; set; }

       
        [StringLength(10, MinimumLength = 2)]
        [Display(Name = "Reg Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]         
        public string RegNum { get; set; }

       
        [Display(Name = "Color")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public Color Color { get; set; }

        [StringLength(10, MinimumLength = 2)]
        //[RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Brand!")]
        [Display(Name = "Brand")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Brand { get; set; }

        [StringLength(10, MinimumLength = 2)]
        [Display(Name = "Model")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Model { get; set; }

        [Display(Name = "Wheels")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public int NumOfWheels { get; set; }


        [Display(Name = "Parking Time")]
        public DateTime ParkedTime { get; set; }

        //public double CalculatePrice;
        [Display(Name = "Total Time")]

       
        public TimeSpan ComparedTime
        {
            get
            {

                TimeSpan result = DateTime.Now.Subtract(ParkedTime);

                return result;
            }
        }

        [Display(Name = "Price")]
        public int Price
        {
            get
            {

                return Convert.ToInt32( (ComparedTime.TotalMinutes * 0.5));
            }
                
        }

        //[Display(Name = "Price")]
        //public string Price
        //{
        //    get
        //    {
        //        return $"The price is 30Kr for 1 hour./n Your bill is at : {ComparedTime.TotalMinutes*0.5} Kr";
        //    }

        //}


    }

    public enum VehicleType
    {
        Boat,
        Bus,
        Car,
        MotoCyckle,
        Plane
    }

    public enum Color
    {
        Black,
        Bronze,
        Brown,
        Blue,
        Gold,
        Gray,
        Green,
        Lilac,
        Orange,
        Pink,
        Red,
        Silver,
        White,
        Yellow
    }


}
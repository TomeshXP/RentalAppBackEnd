using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalBackEnd.Custom_Model
{
    public class UpdatePostModel
    {
        public string PropertyName { get; set; }
        public string SquareFeet { get; set; }
        public decimal RentalCost { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string LandLordName { get; set; }
        public string PropertyImage { get; set; }

    }
}
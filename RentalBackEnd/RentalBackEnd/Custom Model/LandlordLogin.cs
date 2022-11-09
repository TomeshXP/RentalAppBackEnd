using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalBackEnd.Custom_Model
{
    public class LandlordLogin
    {
        public int RentarId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
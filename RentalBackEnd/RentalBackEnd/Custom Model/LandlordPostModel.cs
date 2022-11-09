using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalBackEnd.Custom_Model
{
    public class LandlordPostModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
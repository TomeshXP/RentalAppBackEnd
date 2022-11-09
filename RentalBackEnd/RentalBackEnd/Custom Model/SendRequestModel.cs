using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalBackEnd.Custom_Model
{
    public class SendRequestModel
    {
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int PropertyId { get; set; }
        public string LandLordName { get; set; }
        public decimal RentAmount { get; set; }
        public decimal SecurityDeposit { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalBackEnd.Custom_Model
{
    public class GetBuyerRequestResoponseModel
    {
        public string BuyerName { get; set; }
        public string Address { get; set; }
        public string BuyerdImage { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerMobile { get; set; }
        public decimal RentAmount { get; set; }
        public decimal SecurityDeposit { get; set; }
    }
}
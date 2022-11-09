﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalBackEnd.Custom_Method
{
    public class Response<X>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public X Data { get; set; }
        
    }
}
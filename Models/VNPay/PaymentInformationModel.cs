using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenPet.Models.VNPay
{
    public class PaymentInformationModel
    {
        public string OrderType { get; set; }
        public double Amount { get; set; }
        public string OrderDescription { get; set; }
        public string Name { get; set; }

    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenPet.Models.VNPay
{
    public class PaymentResponseModel
    {
        public string OrderDescription { get; set; }
        public string TransactionId { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentId { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }
        public double VnPayAmount { get; set; }
        public string vnp_PayDate { get; set; }
        public string vnp_BankCode { get; set; }

    }
}




using GoldenPet.Models.VNPay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoldenPet.Service.VnPay
{
    internal interface IVnPayService
    {
        string CreatePaymentUrl(PaymentInformationModel model, HttpRequestBase request);
        PaymentResponseModel PaymentExecute(NameValueCollection queryString);
    }

}

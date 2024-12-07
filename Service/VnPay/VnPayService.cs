using GoldenPet.Libraries;
using GoldenPet.Models;
using GoldenPet.Models.VNPay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoldenPet.Service.VnPay
{
    public class VnPayService : IVnPayService
    {
        goldenpetEntities _db = new goldenpetEntities();

        public VnPayService( )
        {
        }


        public string CreatePaymentUrl(PaymentInformationModel model, HttpRequestBase request)
        {
            var txtExpire = DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss");

            var timeZoneId = ConfigurationManager.AppSettings["TimeZoneId"];
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);

            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();

            var urlCallBack = ConfigurationManager.AppSettings["Vnpay.PaymentBackReturnUrl"];

            pay.AddRequestData("vnp_Version", ConfigurationManager.AppSettings["Vnpay.Version"]);
            pay.AddRequestData("vnp_Command", ConfigurationManager.AppSettings["Vnpay.Command"]);
            pay.AddRequestData("vnp_TmnCode", ConfigurationManager.AppSettings["Vnpay.TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((double)model.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", ConfigurationManager.AppSettings["Vnpay.CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(request)); // Lấy IP từ HttpRequestBase
            pay.AddRequestData("vnp_Locale", ConfigurationManager.AppSettings["Vnpay.Locale"]);
            pay.AddRequestData("vnp_OrderInfo", $"{model.Name} {model.OrderDescription} {model.Amount}");
            pay.AddRequestData("vnp_OrderType", model.OrderType);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);
            pay.AddRequestData("vnp_ExpireDate", txtExpire);

            var paymentUrl = pay.CreateRequestUrl(
                ConfigurationManager.AppSettings["Vnpay.BaseUrl"],
                ConfigurationManager.AppSettings["Vnpay.HashSecret"]
            );

           
            return paymentUrl;
        }
        public PaymentResponseModel PaymentExecute(NameValueCollection queryString)
        {
            Order order = new Order();
            var pay = new VnPayLibrary();

            // Lấy khóa bảo mật từ cấu hình
            var hashSecret = ConfigurationManager.AppSettings["Vnpay.HashSecret"];

            // Gọi phương thức GetFullResponseData
            var response = pay.GetFullResponseData(queryString, hashSecret);
            order.Status=pay.GetResponseData("vnp_ResponseCode");

            return response;
        }

    }

}

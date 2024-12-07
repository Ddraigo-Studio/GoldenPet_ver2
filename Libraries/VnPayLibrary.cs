using GoldenPet.Models.VNPay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using GoldenPet.Models;

namespace GoldenPet.Libraries
{
    public class VnPayLibrary
    {
        goldenpetEntities _db = new goldenpetEntities();

        public SortedList<string, string> GetRequestData()
        {
            return _requestData;
        }
        public void LogData(Dictionary<string, string> requestData)
        {
            string logPath = HttpContext.Current.Server.MapPath("~/App_Data/RequestLog.txt");
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                foreach (var kvp in requestData)
                {
                    writer.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
                }
                writer.WriteLine("-----");
            }
        }
        private readonly SortedList<string, string> _requestData = new SortedList<string, string>(new VnPayCompare());
        private readonly SortedList<string, string> _responseData = new SortedList<string, string>(new VnPayCompare());
        public PaymentResponseModel GetFullResponseData(NameValueCollection queryString, string hashSecret)
        {
            Order order = new Order();

            var vnPay = new VnPayLibrary();

            // Duyệt qua các cặp key-value trong queryString
            foreach (string key in queryString.AllKeys)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnPay.AddResponseData(key, queryString[key]);
                }
            }

            var orderId = Convert.ToInt64(vnPay.GetResponseData("vnp_TxnRef"));
            var vnPayTranId = Convert.ToInt64(vnPay.GetResponseData("vnp_TransactionNo"));
            var vnpResponseCode = vnPay.GetResponseData("vnp_ResponseCode");
            var vnpSecureHash = queryString["vnp_SecureHash"]; // hash của dữ liệu trả về
            var orderInfo = vnPay.GetResponseData("vnp_OrderInfo");
            var amount = vnPay.GetResponseData("vnp_Amount");
            var payDate = vnPay.GetResponseData("vnp_PayDate");
            var bankcod = vnPay.GetResponseData("vnp_BankCode");
            double vnpayamount;
           vnpayamount= Double.Parse(amount);

            // Kiểm tra chữ ký
            var checkSignature = vnPay.ValidateSignature(vnpSecureHash, hashSecret);
            if (!checkSignature)
            {
                return new PaymentResponseModel()
                {
                    Success = false
                };
            }
            


            return new PaymentResponseModel()
            {

                Success = true,
                PaymentMethod = "VnPay",
                OrderDescription = orderInfo,
                OrderId = orderId.ToString(),
                PaymentId = vnPayTranId.ToString(),
                TransactionId = vnPayTranId.ToString(),
                Token = vnpSecureHash,
                VnPayResponseCode = vnpResponseCode,
                VnPayAmount=vnpayamount,
                vnp_PayDate= payDate,
                vnp_BankCode=bankcod
            

    };
        }
        public string GetIpAddress(HttpRequestBase request)
        {
            string ipAddress = string.Empty;

            try
            {
                ipAddress = request.UserHostAddress;

                if (IPAddress.TryParse(ipAddress, out var ip))
                {
                    if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        var ipv4 = Dns.GetHostEntry(ip)
                                      .AddressList
                                      .FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);

                        if (ipv4 != null)
                        {
                            ipAddress = ipv4.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.IsNullOrEmpty(ipAddress) ? "127.0.0.1" : ipAddress;
        }


        public void AddRequestData(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _requestData.Add(key, value);
            }
        }

        public void AddResponseData(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _responseData.Add(key, value);
            }
        }
        public string GetResponseData(string key)
        {
            return _responseData.TryGetValue(key, out var retValue) ? retValue : string.Empty;
        }
        public string CreateRequestUrl(string baseUrl, string vnpHashSecret)
        {
            var data = new StringBuilder();

            // Duyệt qua các cặp key-value trong `_requestData`
            foreach (var kv in _requestData)
            {
                var key = kv.Key;
                var value = kv.Value;

                if (!string.IsNullOrEmpty(value))
                {
                    data.Append(WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(value) + "&");
                }
            }

            var querystring = data.ToString();

            // Thêm querystring vào baseUrl
            baseUrl += "?" + querystring;

            var signData = querystring;

            // Xóa ký tự `&` cuối cùng nếu tồn tại
            if (signData.Length > 0)
            {
                signData = signData.Substring(0, signData.Length - 1);
            }

            // Tạo chữ ký bảo mật (SecureHash)
            var vnpSecureHash = HmacSha512(vnpHashSecret, signData);

            // Thêm chữ ký vào URL
            baseUrl += "vnp_SecureHash=" + vnpSecureHash;

            return baseUrl;
        }

        public bool ValidateSignature(string inputHash, string secretKey)
        {
            var rspRaw = GetResponseData();
            var myChecksum = HmacSha512(secretKey, rspRaw);
            return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
        }
        private string HmacSha512(string key, string inputData)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "The key cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(inputData))
            {
                throw new ArgumentNullException(nameof(inputData), "The inputData cannot be null or empty.");
            }
            var hash = new StringBuilder();
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                var hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }
        private string GetResponseData()
        {
            var data = new StringBuilder();

            // Loại bỏ các khóa không cần thiết
            if (_responseData.ContainsKey("vnp_SecureHashType"))
            {
                _responseData.Remove("vnp_SecureHashType");
            }

            if (_responseData.ContainsKey("vnp_SecureHash"))
            {
                _responseData.Remove("vnp_SecureHash");
            }

            // Duyệt qua các cặp key-value trong `_responseData`
            foreach (var kv in _responseData)
            {
                var key = kv.Key;
                var value = kv.Value;

                if (!string.IsNullOrEmpty(value))
                {
                    data.Append(WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(value) + "&");
                }
            }

            // Xóa ký tự `&` cuối cùng
            if (data.Length > 0)
            {
                data.Remove(data.Length - 1, 1);
            }

            return data.ToString();
        }






    }
    public class VnPayCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var vnpCompare = CompareInfo.GetCompareInfo("en-US");
            return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
        }
    }

}
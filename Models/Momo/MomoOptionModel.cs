using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenPet.Models.Momo
{
    public class MomoOptionModel
    {
        public string MomoApiUrl { get; set; }
        public string SecretKey { get; set; }
        public string AccessKey { get; set; }
        public string PartnerCode { get; set; }
        public string RequestType { get; set; }
        public string ReturnUrl { get; set; }
        public string NotifyUrl { get; set; }
    }

}
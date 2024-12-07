using GoldenPet.Models.Momo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace GoldenPet.Help
{
    public class MomoOptionProvider
    {
        public static MomoOptionModel GetMomoOptions()
        {
            return new MomoOptionModel
            {
                MomoApiUrl = WebConfigurationManager.AppSettings["MomoApiUrl"],
                SecretKey = WebConfigurationManager.AppSettings["SecretKey"],
                AccessKey = WebConfigurationManager.AppSettings["AccessKey"],
                PartnerCode = WebConfigurationManager.AppSettings["PartnerCode"],
                RequestType = WebConfigurationManager.AppSettings["RequestType"],
                ReturnUrl = WebConfigurationManager.AppSettings["ReturnUrl"],
                NotifyUrl = WebConfigurationManager.AppSettings["NotifyUrl"]
            };
        }
    }
}
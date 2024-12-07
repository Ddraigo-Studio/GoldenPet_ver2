using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc5;
using Unity;
using GoldenPet.Service.Momo;
using GoldenPet.Models.Momo;
using Microsoft.Extensions.Options;
using Unity.Injection;
using GoldenPet.Service.VnPay;
namespace GoldenPet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new UnityContainer();

            Application["VnPayService"] = new VnPayService();

            // Đăng ký các dịch vụ của bạn
            container.RegisterType<IMomoService, MomoService>();

            // Đăng ký cấu hình MomoOptionModel nếu dùng IOptions
            container.RegisterType<IOptions<MomoOptionModel>, OptionsWrapper<MomoOptionModel>>(new InjectionConstructor(new MomoOptionModel
            {
                MomoApiUrl = "https://test-payment.momo.vn/gw_payment/transactionProcessor",
                SecretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz",
                AccessKey = "F8BBA842ECF85",
                ReturnUrl = "https://localhost:44322/Checkout/PaymentCallBack",
                NotifyUrl = "https://localhost:44322/Checkout/MomoNotify",
                PartnerCode = "MOMO",
                RequestType = "captureMoMoWallet"
            }));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        }
    }
}

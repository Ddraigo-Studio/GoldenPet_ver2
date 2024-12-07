using GoldenPet.Models.Momo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenPet.Models.Momo;
using GoldenPet.Models;
using System.Web;

namespace GoldenPet.Service.Momo
{
    internal interface IMomoService
    {
        MomoCreatePaymentResponseModel CreatePaymentMomo(OrderInfoModel model);
        MomoExecuteResponseModel PaymentExecuteAsync(HttpRequestBase request);

    }
}

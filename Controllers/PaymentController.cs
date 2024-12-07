using GoldenPet.Models;
using GoldenPet.Models.VNPay;
using GoldenPet.Service.Momo;
using GoldenPet.Service.VnPay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace GoldenPet.Controllers
{
    public class PaymentController : Controller
    {
        goldenpetEntities _db = new goldenpetEntities();
        Order order= new Order();
        Cart cart = new Cart();
        OrderItem orderItem = new OrderItem();

        private readonly MomoService _momoService;
        public ActionResult CreatePaymentMomo()
        {
            return View();
        }
        public PaymentController(MomoService momoService)
        {
            _momoService = momoService;
            _vnPayService = new VnPayService();
        }
        [HttpPost]
        public ActionResult CreatePaymentMomo(OrderInfoModel model)
        {
            var response = _momoService.CreatePaymentMomo(model);
            return Redirect(response.PayUrl);
        }

        [HttpGet]
        public ActionResult PaymentCallback()
        {
            var response = _momoService.PaymentExecuteAsync(Request);
            return View(response);
        }

        private readonly IVnPayService _vnPayService;

            // Khởi tạo trực tiếp trong constructor (hoặc sử dụng Service Locator nếu cần)
        

        // Tạo URL thanh toán
            [HttpPost]
        public ActionResult CreatePaymentUrlVnpay(PaymentInformationModel model)
        {
            int userID = (int)Session["UserId"];

            // Step 1: Create a new order
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                UserID = userID,
                TotalAmount = 0, // Initialize with 0
                Status="Pending"
            };
            _db.Orders.Add(order);
            _db.SaveChanges(); // Save the order to get its OrderID

            // Step 2: Add items to the order
            var items = CardController.GetItemsByUserId(_db, userID);

            if (!items.Any())
            {
                throw new Exception("No items found for the user in the cart.");
            }

            foreach (var item in items)
            {
                OrderItem orderItem = new OrderItem
                {
                    Quantity = item.Quantity,
                    ProductID = item.ProductID,
                    Price = (decimal)item.tb_Product.price,
                    OrderID = order.OrderID // Associate with the order
                };

                _db.OrderItems.Add(orderItem);
                order.TotalAmount += orderItem.Price * orderItem.Quantity; // Update total
            }

            // Step 3: Save order items
            _db.SaveChanges();

            // Step 4: Update the order's total amount
            _db.Entry(order).State = (System.Data.Entity.EntityState)EntityState.Modified;
            _db.SaveChanges();

            var url = _vnPayService.CreatePaymentUrl(model, Request); // Truyền HttpRequest thay vì HttpContext
                return Redirect(url);
            }
        //Lấy item trong giỏ hàng(itemcart) sao đó biến chúng thành(orderitem) sau đó đẩy vào giao dịch (oder)
        //Sort trong giỏ hàng đẩy vào 

        // Xử lý callback từ VNPay
        [HttpGet]

        public ActionResult PaymentCallbackVnpay()
            {
            int userID = (int)Session["UserId"];

            var response = _vnPayService.PaymentExecute(Request.QueryString);
            int resposeCode = int.Parse(_vnPayService.PaymentExecute(Request.QueryString).VnPayResponseCode);
            var orderID = _db.Orders.FirstOrDefault(i => i.UserID == userID);
            if (resposeCode == 00)
            {
                CardController.ClearCartByUserIdandChangeOrderStatus(_db, userID);
               
                return View(orderID);
            }
            orderID.Status = "Failed";
            return View("FailedPayment",orderID);
           


            //if (img != null)
            //{
            //    filename = Path.GetFileName(img.FileName);  // Ensure filename is sanitized

            //    path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/img"), filename);

            //    img.SaveAs(path);
            //    tb_News.ThumbnailImageURL = filename;  // Set the image URL
            //}
            //else
            //{
            //    tb_News.ThumbnailImageURL = "logo.png";  // Default image if none uploaded
            //}

            //db.tb_News.Add(tb_News);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }
        }

    }


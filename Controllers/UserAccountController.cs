using GoldenPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebGrease.Activities;

namespace GoldenPet.Controllers
{
    public class UserAccountController : Controller
    {
        goldenpetEntities _db = new goldenpetEntities();

        // GET: UserAccount
        public ActionResult Login(string username, string password)
        {
            // Tìm người dùng trong bảng Customer
            var user = _db.tb_Customer.SingleOrDefault(c => c.customerName == username &&  c.password== password);

            if (user != null)
            {
                // Đăng nhập thành công, lưu ID người dùng vào cookie
                FormsAuthentication.SetAuthCookie(user.customerName, false);

                // Cách khác để lưu thông tin ID nếu bạn cần truy vấn sau này:
                Session["UserId"] = user.id;  // Lưu ID người dùng vào Session
                var cart = _db.Carts.SingleOrDefault(c => c.UserID == user.id);
                Session["CartID"]= cart.CartID;


                // Chuyển hướng đến trang sau khi đăng nhập
                return RedirectToAction("Index", "Default");
            }
            else
            {
                // Nếu đăng nhập thất bại
                ViewBag.Message = "Tài khoản hoặc mật khẩu không chính xác";
                return View();
            }
        }
        public ActionResult SignUp() {
        return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include ="id,customerName,email,phone,createdDate,password")] tb_Customer tb_Customer)
        {
            if (ModelState.IsValid)
             {
                    _db.tb_Customer.Add(tb_Customer);
                _db.SaveChanges();
                Session["UserID"] = tb_Customer.id;

                var cart = new Cart
                {
                    UserID = tb_Customer.id,
                    CreatedAt = DateTime.Now
                };
                _db.Carts.Add(cart);
                _db.SaveChanges();
                Session["CartID"] = cart.CartID;

                return RedirectToAction("Index","Default");
             }

                return View(tb_Customer);
            
        }
    }
}
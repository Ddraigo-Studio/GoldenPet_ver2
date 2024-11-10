using GoldenPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenPet.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        goldenpetEntities _db = new goldenpetEntities();

        public ActionResult Index()
        {
            var CartID = Convert.ToInt32(Session["CartID"]);


            var v = _db.Carts.SingleOrDefault(t => t.CartID == CartID);


            return View(v);
        }
        public ActionResult DeafualtCart()
        {
            var v = from t in _db.Carts
                    select t;

            return PartialView(v.ToList());
           
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "CartID,ProductID,Quantity,AddedAt")] CartItem cartItem)
        {
            var CartID = Convert.ToInt32(Session["CartID"]);
            cartItem.CartID = CartID;

            if (ModelState.IsValid)
            {
                // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
                var existingCartItem = _db.CartItems
                    .FirstOrDefault(ci => ci.CartID == CartID && ci.ProductID == cartItem.ProductID);

                if (existingCartItem != null)
                {
                    // Nếu sản phẩm đã tồn tại trong giỏ hàng, tăng số lượng
                    existingCartItem.Quantity += cartItem.Quantity;
                }
                else
                {
                    // Nếu sản phẩm chưa tồn tại, thêm vào giỏ hàng
                    _db.CartItems.Add(cartItem);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cartItem);
        }


        //public ActionResult CreateCart([Bind(Include = "CartID,UserID,CreatedAt")] Cart cart)
        //{
        //    var userId = Session["UserId"];
        //    cart.UserID = Convert.ToInt32(userId);

        //    if (ModelState.IsValid)
        //    {
        //        _db.Carts.Add(cart);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(cart);
        //}

    }
}
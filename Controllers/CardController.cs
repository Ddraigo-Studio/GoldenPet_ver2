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
        [HttpPost]
        public JsonResult UpdateQuantity(int productId, int quantity)
        {
            var cartId = Convert.ToInt32(Session["CartID"]);
            var cartItem = _db.CartItems.FirstOrDefault(ci => ci.CartID == cartId && ci.ProductID == productId);

            if (cartItem != null)
            {
                // Update the quantity
                cartItem.Quantity = quantity;
                _db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Item not found in cart" });
        }

        public static IEnumerable<CartItem> GetItemsByUserId(goldenpetEntities _db, int userId)
        {
            // Find the cart for the given user ID
            var cart = _db.Carts.SingleOrDefault(c => c.UserID == userId);

            if (cart == null)
            {
                throw new Exception("No cart found for the given user ID.");
            }

            // Get all items that belong to the found cart
            var items = _db.CartItems.Where(ci => ci.CartID == cart.CartID).ToList();

            if (!items.Any())
            {
                throw new Exception("No items found in the cart for the given user ID.");
            }

            return items; // Return the items
        }
        public static void ClearCartByUserIdandChangeOrderStatus(goldenpetEntities _db, int userId)
        {
            // Tìm cart của người dùng
            var cart = _db.Carts.SingleOrDefault(c => c.UserID == userId);
            var order = _db.Orders
                .Where(c => c.UserID == userId)
                .OrderByDescending(o => o.OrderDate) // Lấy order mới nhất
                .FirstOrDefault();
            if (cart == null)
            {
                throw new Exception("No cart found for the given user ID.");
            }

            // Tìm các CartItems liên quan đến cart này
            var cartItems = _db.CartItems.Where(ci => ci.CartID == cart.CartID).ToList();

            if (!cartItems.Any())
            {
                Console.WriteLine("The cart is already empty.");
                return;
            }
            order.Status = "Finish";
            // Xóa tất cả các CartItems
            _db.CartItems.RemoveRange(cartItems);

            // Lưu thay đổi vào database
            _db.SaveChanges();

        }
        public void deleteItemsCart(int ItemsID,int CartID)
        {
            var cartId= _db.Carts.FirstOrDefault(ci=> ci.CartID == CartID);
            var cartItem = _db.CartItems.FirstOrDefault(ci => ci.tb_Product.id == ItemsID && ci.CartID == CartID);
         
            // Remove the item from the cart
            _db.CartItems.Remove(cartItem);

            // Save changes to the database
            _db.SaveChanges();
        }
        public int CartItemsCount(int CartID)
        {
            // Kiểm tra nếu _db không được khởi tạo
            if (_db == null)
            {
                throw new Exception("Database context (_db) is not initialized.");
            }

            // Lấy danh sách CartItems
            var cartItems = _db.CartItems.Where(c => c.CartID == CartID).ToList();
            // Kiểm tra nếu CartID không hợp lệ (không có CartItems nào)
            if (cartItems == null || !cartItems.Any())
            {
                return 0;
            }

            // Trả về số lượng
            return cartItems.Count();
        }
        public ActionResult LoadCartItems()
        {
            
                
                    int CartID = (int)Session["CartID"];
                    var cartItems = _db.CartItems.Where(c => c.CartID == CartID).ToList();
                    return PartialView(cartItems);
                
            
          
        }


    }
}
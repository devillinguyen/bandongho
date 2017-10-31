using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BanDongHo.Models;
using BanDongHo.ViewModels;

namespace BanDongHo.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CartController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            List<CartItem> cartItems;
            if (Session["ShoppingCart"] == null)
            {
                // Create new cart
                cartItems = new List<CartItem>();
                cartItems.Add(new CartItem {Quantity = 1, Product = _dbContext.Products.Single(p => p.Id == id)});
                Session["ShoppingCart"] = cartItems;
            }
            else
            {
                bool flag = false;
                cartItems = (List<CartItem>) Session["ShoppingCart"];
                foreach (CartItem item in cartItems)
                {
                    if (item.Product.Id == id)
                    {
                        item.Quantity++;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    cartItems.Add(new CartItem {Quantity = 1, Product = _dbContext.Products.Single(p => p.Id == id)});
                }
                Session["ShoppingCart"] = cartItems;
            }
            // count quantity in cart
            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            foreach (CartItem item in ls)
            {
                cartcount += item.Quantity;
            }
            return Json(new {ItemAmount = cartcount});
        }

        public ActionResult GetShoppingCart()
        {
            int cartcount = 0;
            if (Session["ShoppingCart"] != null)
            {
                List<CartItem> cartItems = (List<CartItem>) Session["ShoppingCart"];
                foreach (CartItem item in cartItems)
                {
                    cartcount += item.Quantity;
                }
            }
            return PartialView("ShoppingCartPartial", cartcount);
        }
        // GET: LISTcartItem
        public ActionResult ListCartItem()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpdateQuantity(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>) Session["ShoppingCart"];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(p => p.Product.Id == item.Product.Id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session["ShoppingCart"] = sessionCart;
            return Json(new {status = true});
        }

        public ActionResult DeleteAll()
        {
            Session.Remove("ShoppingCart");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            var cartItems = (List<CartItem>) Session["ShoppingCart"];
            cartItems.RemoveAll(c => c.Product.Id == id);
            return RedirectToAction("ListCartItem", "Cart");
        }
        // GET: Checkout
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(CheckoutViewmodel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Checkout");
            }
            var listCartItem = (List<CartItem>) Session["ShoppingCart"];
            if (listCartItem == null)
            {
                return RedirectToAction("Index", "Error");
            }
            else
            {
                double total = 0;
                var customer = new Customer
                {
                    Name = viewmodel.Name,
                    Email = viewmodel.Email,
                    PhoneNumber = viewmodel.PhoneNumber,
                    Address = viewmodel.Address
                };
                var order = new Order
                {
                    CustomerId = customer.Id,
                    Status = false,
                    DateTime = DateTime.Now
                };
                foreach (var item in listCartItem)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = item.Product.Id,
                        Price = item.Product.Price,
                        Quantity = item.Quantity
                    };
                    _dbContext.OrderDetails.Add(orderDetail);
                    total += (item.Quantity * item.Product.Price);
                }
                order.Total = total;
                _dbContext.Customers.Add(customer);
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                Session.Remove("ShoppingCart");
                return RedirectToAction("ThankYou");
            }
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
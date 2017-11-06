using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
using BanDongHo.ViewModels;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class AdminOrdersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminOrdersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: AdminOrders
        public ActionResult Index() // Waiting for checkout...
        {
            var orders = _dbContext.Orders
                .Where(o => o.Status == false)
                .Include(c => c.Customer)
                .ToList();
            return View(orders);
        }
        // GET: OrderDetail
        public ActionResult OrderDetail(long id)
        {
            var orderDetails = _dbContext.OrderDetails
                .Where(o => o.OrderId == id)
                .Include(p => p.Product)
                .ToList();
            return View(orderDetails);
        }
        // GET: Customer
        public ActionResult Customer(long id)
        {
            var customer = _dbContext.Customers.Single(c => c.Id == id);
            return View(customer);
        }
        // GET: Delete
        public ActionResult Delete (long id)
        {
            var order = _dbContext.Orders.SingleOrDefault(o => o.Id == id); // Single or Default cho phép null
            if (order == null)
            {
                return RedirectToAction("Index", "AdminOrders");
            }
            else
            {
                var customer = _dbContext.Customers.Single(c => c.Id == order.CustomerId);
                var viewModel = new OrderViewModel
                {
                    Id = order.Id,
                    Total = order.Total,
                    CustomerName = customer.Name
                };
                return  View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(OrderViewModel viewModel)
        {
            var order = _dbContext.Orders.Single(o => o.Id == viewModel.Id);
            var orderDetails = _dbContext.OrderDetails
                .Where(o => o.OrderId == viewModel.Id)
                .ToList();
            foreach (var item in orderDetails)
            {
                _dbContext.OrderDetails.Remove(item);
            }
            var customer = _dbContext.Customers.Single(c => c.Id == order.CustomerId);
            _dbContext.Orders.Remove(order);
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "AdminOrders");
        }
        // GET: 
        public ActionResult Paid()
        {
            var orders = _dbContext.Orders
                .Where(o => o.Status == true)
                .Include(c => c.Customer)
                .ToList();
            return View(orders);
        }
        // POST: Checked
        [HttpPost]
        public ActionResult Checked(long id)
        {
            var order = _dbContext.Orders.Single(o => o.Id == id);
            order.Status = true;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "AdminOrders");
        }
        // POST: UnChecked
        [HttpPost]
        public ActionResult UnChecked(long id)
        {
            var order = _dbContext.Orders.Single(o => o.Id == id);
            order.Status = false;
            _dbContext.SaveChanges();
            return RedirectToAction("Paid", "AdminOrders");
        }
    }
}
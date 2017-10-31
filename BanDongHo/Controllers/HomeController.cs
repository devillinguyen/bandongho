using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
using BanDongHo.ViewModels;

namespace BanDongHo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Products = _dbContext.Products.AsEnumerable(),
                Categories = _dbContext.Categories.AsEnumerable(),
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            var about = _dbContext.Abouts.ToList();
            if (about != null)
            {
                return View(about);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Contact()
        {
            var contact = _dbContext.Contacts.ToList();
            if (contact != null)
            {
                return View(contact);
            }
            else
            {
                return View();
            }
        }
        // GET: Single
        public ActionResult Single(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }

        public ActionResult AboutPartial()
        {
            var about = _dbContext.Abouts.ToList();
            return PartialView("AboutPartial", about);
        }
    }
}
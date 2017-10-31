using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
using BanDongHo.ViewModels;

namespace BanDongHo.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult ListCategory()
        {
            var categories = _dbContext.Categories.AsEnumerable();
            return PartialView("CategoriesPartial", categories);
        }
        // GET: Categories
        public ActionResult ListProduct(int id)
        {
//            var viewModel = new ListProductWithCategory
//            {
//                Categories = _dbContext.Categories.AsEnumerable(),
//                Products = _dbContext.Products
//                .Where(c => c.CategoryId == id)
//                .AsEnumerable()
//            };
            var products = _dbContext.Products
                .Where(c => c.CategoryId == id)
                .AsEnumerable();
            return View(products);
        }
    }
}
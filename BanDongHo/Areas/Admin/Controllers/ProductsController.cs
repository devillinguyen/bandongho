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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = _dbContext.Products
                .Include(c => c.Category)
                .ToList();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }
            var product = new Product
            {
                Name = viewModel.Name,
                CategoryId = viewModel.CategoryId,
                Image = viewModel.Image,
                Description = viewModel.Description,
                Price = double.Parse(viewModel.Price),
                Hot = viewModel.Hot,
                Male = viewModel.Male,
                Date = DateTime.Now
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _dbContext.Products.Single(p => p.Id == id);
            var viewModel = new ProductViewModel
            {
                Id = id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price.ToString(),
                Hot = product.Hot,
                Male = product.Male,
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Edit", viewModel);
            }
            var product = _dbContext.Products.Single(p => p.Id == viewModel.Id);
            product.Name = viewModel.Name;
            product.CategoryId = viewModel.CategoryId;
            product.Image = viewModel.Image;
            product.Description = viewModel.Description;
            product.Price = double.Parse(viewModel.Price);
            product.Hot = viewModel.Hot;
            product.Male = viewModel.Male;
            product.Date = DateTime.Now;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _dbContext.Products.Single(p => p.Id == id);
            var viewModel = new ProductViewModel
            {
                Id = id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price.ToString(),
                Hot = product.Hot,
                Male = product.Male,
                Date = product.Date
            };
            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductViewModel viewModel)
        {
            var product = _dbContext.Products.Single(p => p.Id == viewModel.Id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}


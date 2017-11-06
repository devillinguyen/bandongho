using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
using BanDongHo.ViewModels;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class AboutsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AboutsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: About
        public ActionResult Index()
        {
            var abouts = _dbContext.Abouts.ToList();
            return View(abouts);
        }

        // GET: About/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: About/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: About/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            var about = new About
            {
                Title = viewModel.Title,
                Content = viewModel.Content
            };
            _dbContext.Abouts.Add(about);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: About/Edit/5
        public ActionResult Edit(int id)
        {
            var about = _dbContext.Abouts.SingleOrDefault(a => a.Id == id);
            if (about == null)
            {
                return View("Error");
            }
            else
            {
                var viewModel = new AboutViewModel
                {
                    Id = id,
                    Title = about.Title,
                    Content = about.Content
                };
                return View(viewModel);
            }
            
        }

        // POST: About/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AboutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }
            var about = _dbContext.Abouts.Single(a => a.Id == viewModel.Id);
            about.Title = viewModel.Title;
            about.Content = viewModel.Content;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: About/Delete/5
        public ActionResult Delete(int id)
        {
            var about = _dbContext.Abouts.SingleOrDefault(a => a.Id == id);
            if (about == null)
            {
                return View("Error");
            }
            else
            {
                var viewModel = new AboutViewModel
                {
                    Id = id,
                    Title = about.Title,
                    Content = about.Content
                };
                return View(viewModel);
            }
        }

        // POST: About/Delete/5
        [HttpPost]
        public ActionResult Delete(AboutViewModel viewModel)
        {
            var about = _dbContext.Abouts.Single(a => a.Id == viewModel.Id);
            _dbContext.Abouts.Remove(about);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

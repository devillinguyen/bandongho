using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
using BanDongHo.ViewModels;

namespace BanDongHo.Areas.Admin.Controllers
{ 
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = _dbContext.Contacts.ToList();
            return View(contacts);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            var contact = new Contact
            {
                Title = viewModel.Title,
                Company = viewModel.Company,
                PhoneNumber = viewModel.PhoneNumber,
                Address = viewModel.Address
            };
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            var contact = _dbContext.Contacts.SingleOrDefault(a => a.Id == id);
            if (contact == null)
            {
                return View("Error");
            }
            else
            {
                var viewModel = new ContactViewModel
                {
                    Id = id,
                    Title = contact.Title,
                    Company = contact.Company,
                    PhoneNumber = contact.PhoneNumber,
                    Address = contact.Address
                };
                return View(viewModel);
            }
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }
            var contact = _dbContext.Contacts.Single(a => a.Id == viewModel.Id);
            contact.Title = viewModel.Title;
            contact.Company = viewModel.Company;
            contact.PhoneNumber = viewModel.PhoneNumber;
            contact.Address = viewModel.Address;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            var contact = _dbContext.Contacts.SingleOrDefault(a => a.Id == id);
            if (contact == null)
            {
                return View("Error");
            }
            else
            {
                var viewModel = new ContactViewModel
                {
                    Id = id,
                    Title = contact.Title,
                    Company = contact.Company,
                    PhoneNumber = contact.PhoneNumber,
                    Address = contact.Address
                };
                return View(viewModel);
            }
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(ContactViewModel viewModel)
        {
            var contact = _dbContext.Contacts.Single(c => c.Id == viewModel.Id);
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

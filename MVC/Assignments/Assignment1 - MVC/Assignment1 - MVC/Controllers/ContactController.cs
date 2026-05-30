using Assignment1___MVC.Models;
using Assignment1___MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment1___MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepositories _repository;
        public ContactController()
        {
            _repository = new ContactRepository();
        }

        public async Task<ActionResult> Index()
        {
            var data = await _repository.GetAllAsync();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        

        public async Task<ActionResult> Edit(long id)
        {
            var data = await _repository.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(long id)
        {
            var data = await _repository.GetByIdAsync(id);
            return View(data);
        }

        
    }
}
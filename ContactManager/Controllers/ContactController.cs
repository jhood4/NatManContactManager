using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using ContactManager.Data;
using ContactManager.Data.Repository.IRepository;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Add()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Add()
        //{
        //    ViewBag.Action = "Add";
        //    ViewBag.Category = _unitOfWork.Categories.OrderBy(g => g.Name).ToList();
        //    return View("Edit", new Contact());
        //}
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Action = "Edit";
        //    ViewBag.Category = _unitOfWork.Categories.OrderBy(g => g.Name).ToList();
        //    var contact = _unitOfWork.Contacts.Find(id);
        //    return View(contact);
        //}
        //[HttpPost]
        //public IActionResult Edit(Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (contact.ContactId == 0)
        //        {
        //            _unitOfWork.Contacts.Add(contact);
        //        }
        //        else
        //        {
        //            _unitOfWork.Contacts.Update(contact);
        //        }
        //        _unitOfWork.SaveChanges();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
        //        ViewBag.Category = _unitOfWork.Category.OrderBy(g => g.Name).ToList();
        //        return View(contact);
        //    }
        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var contact = _unitOfWork.Contacts.Find(id);
        //    return View(contact);
        //}
        //[HttpPost]
        //public IActionResult Delete(Contact contact)
        //{
        //    _unitOfWork.Contacts.Remove(contact);
        //    _unitOfWork.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
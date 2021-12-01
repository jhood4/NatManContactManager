using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using ContactManager.Data;
using ContactManager.Data.Repository.IRepository;
using ContactManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var list = _unitOfWork.Categories.GetAll();
            AddContactVM vm = new AddContactVM
            {
                CategoryList = list.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }),
                Contact = new Contact()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(AddContactVM vm)
        {
            _unitOfWork.Contacts.Add(vm.Contact);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var list = _unitOfWork.Categories.GetAll();
            AddContactVM vm = new AddContactVM
            {
                CategoryList = list.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }),
                Contact = _unitOfWork.Contacts.GetFirstOrDefault(filter: x => x.ContactId == id)
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var obj = _unitOfWork.Contacts.GetFirstOrDefault(x => x.ContactId == contact.ContactId);
            obj = contact;
            _unitOfWork.Contacts.Update(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var contact = _unitOfWork.Contacts.GetFirstOrDefault(filter: x => x.ContactId == id);
            _unitOfWork.Contacts.Remove(contact);
            _unitOfWork.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}
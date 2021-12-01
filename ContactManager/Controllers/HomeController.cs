using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ContactManager.Models;
using ContactManager.Data;
using ContactManager.Data.Repository.IRepository;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfOWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfOWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var contacts = context.Contacts
            //    .Include(m => m.Category)
            //    .OrderBy(m => m.FirstName)
            //    .ToList();
            //return View(contacts);
            var contacts = _unitOfOWork.Contacts.GetAll(includeProps: "Category");
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var details = _unitOfOWork.Contacts.GetFirstOrDefault(filter: x => x.ContactId == id, includeProps: "Category");
            return View(details);
        }
    }
}
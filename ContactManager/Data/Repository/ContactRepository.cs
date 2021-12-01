using ContactManager.Data.Repository.IRepository;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Data.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly AppDbContext _db;
        public ContactRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Contact contact)
        {
            var obj = _db.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            obj.FirstName = contact.FirstName;
            obj.LastName = contact.LastName;
            obj.PhoneNumber = contact.PhoneNumber;
            obj.Email = contact.Email;
            obj.CategoryId = contact.CategoryId;

            _db.SaveChanges();
        }
    }
}

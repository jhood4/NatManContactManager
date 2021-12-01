using ContactManager.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Contacts = new ContactRepository(_db);
            Categories = new CategoryRepository(_db);
        }
        public IContactRepository Contacts { get; set; }

        public ICategoryRepository Categories { get; set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

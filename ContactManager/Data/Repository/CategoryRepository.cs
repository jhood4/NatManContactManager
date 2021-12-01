using ContactManager.Data.Repository.IRepository;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            var obj = _db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            obj.Name = category.Name;

            _db.SaveChanges();
        }
    }
}

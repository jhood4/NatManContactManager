using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Data.Repository.IRepository
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        void Update(Contact contact);
    }
}

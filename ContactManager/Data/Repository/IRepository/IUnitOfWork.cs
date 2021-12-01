using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IContactRepository Contacts { get; }
        ICategoryRepository Categories { get; }
        void Save();
    }
}

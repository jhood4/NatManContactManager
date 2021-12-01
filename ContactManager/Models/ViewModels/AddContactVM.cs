using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models.ViewModels
{
    public class AddContactVM
    {
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public Contact Contact { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorcycleWebPage.Infrastructure.Data;

namespace MotorcycleWebPage.Web.Pages.Manufacturers
{
    public class ViewModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public ViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Founded { get; set; }
        public string Description { get; set; }

        public void OnGet(int id)
        {
            var manufacture = _dbContext.Manufacturers.First(c => c.Id == id);
            Id = manufacture.Id;
            Name = manufacture.Name;
            Country = manufacture.Country;
            Founded = manufacture.Founded;
            Description = manufacture.Description;
        }
    }
}

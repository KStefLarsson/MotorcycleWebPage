using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorcycleWebPage.Core.Interfaces.Services;
using MotorcycleWebPage.Core.Models;
using MotorcycleWebPage.Infrastructure.Data;

namespace MotorcycleWebPage.Web.Pages.Manufacturers
{
    public class EditModel : PageModel
    {
        private readonly IManufacturersService _manufacturersService;
        private readonly ApplicationDbContext _dbContext;
        public EditModel(IManufacturersService manufacturersService, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _manufacturersService = manufacturersService;
        }

        public int Id { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [BindProperty]
        [MaxLength(50)]
        [Required]
        public string Country { get; set; }
        [BindProperty]
        [Range(1800, 2025)]
        [Required]
        public int Founded { get; set; }
        [BindProperty]
        [Required]
        public string Description { get; set; }
        //public List<Manufacture> Facturers { get; set; }


        public void OnGet(int id)
        {
            var manufacture = _dbContext.Manufacturers.First(c => c.Id == id);
            Id = manufacture.Id;
            Name = manufacture.Name;
            Country = manufacture.Country;
            Founded = manufacture.Founded;
            Description = manufacture.Description;
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var manufacture = _dbContext.Manufacturers.First(c => c.Id == id);
                manufacture.Name = Name;
                manufacture.Country = Country;
                manufacture.Founded = Founded;
                manufacture.Description = Description;

                _dbContext.SaveChanges();
                return RedirectToPage("/Manufacturers/Index");
            }
            return Page();
        }
    }
}

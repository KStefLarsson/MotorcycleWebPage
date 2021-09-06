using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorcycleWebPage.Core.Interfaces.Services;
using MotorcycleWebPage.Core.Models;

namespace MotorcycleWebPage.Web.Pages.Manufacturers
{
    public class NewModel : PageModel
    {
        private readonly IManufacturersService _manufacturersService;
        public NewModel(IManufacturersService manufacturersService)
        {
            _manufacturersService = manufacturersService;
        }

        public int Id { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [BindProperty]
        [Required]
        [Range(1950, 2025)]
        public int Founded { get; set; }
        [BindProperty]
        [Required]
        public string Description { get; set; }
        public Manufacture NewManufacture { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                NewManufacture = new Manufacture
                {
                    Name = Name,
                    Country = Country,
                    Founded = Founded,
                    Description = Description
                };

                _manufacturersService.Add(NewManufacture);
                _manufacturersService.Save();
                return RedirectToPage("/Manufacturers/Index");
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotorcycleWebPage.Core.Interfaces.Services;
using MotorcycleWebPage.Core.Models;

namespace MotorcycleWebPage.Web.Pages.Motorcycles
{
    //[Authorize(Roles = "Admin")]
    public class NewModel : PageModel
    {
        private readonly IMotorcyclesService _motorcyclesService;
        public NewModel(IMotorcyclesService motorcyclesService)
        {
            _motorcyclesService = motorcyclesService;
        }
        public int Id { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [BindProperty]
        [MaxLength(10)]
        [Required]
        public string TopSpeed { get; set; }
        [BindProperty]
        [MaxLength(10)]
        [Required]
        public string HorsePower { get; set; }
        [BindProperty]
        [Range(1950, 2022)]
        [Required]
        public int Year { get; set; }
        [BindProperty]
        [MaxLength(20)]
        [Required]
        public string TypeOfModel { get; set; }
        [BindProperty]
        [MaxLength(50)]
        [Required]
        public string ManufactureName { get; set; }

        [BindProperty]
        [Range(1, 3)]
        public List<SelectListItem> AllBikeModels { get; set; }
        public void FillTypeOfModel()
        {
            AllBikeModels = new List<SelectListItem>
            {
                new SelectListItem("Välj typ av motorcykel...", " "),
                new SelectListItem("Touring", "Touring"),
                new SelectListItem("Sport", "Sport"),
                new SelectListItem("Custom", "Custom")
            };
        }
        [BindProperty]
        [Range(1, 4)]
        public List<SelectListItem> AllManufacturers { get; set; }
        public void FillManufacturer()
        {
            AllManufacturers = new List<SelectListItem>
            {
                new SelectListItem("Tillverkare...", " "),
                new SelectListItem("Triumph", "Triumph"),
                new SelectListItem("Yamaha", "Yamaha"),
                new SelectListItem("Kawazaki", "Kawazaki"),
                new SelectListItem("Ducati", "Ducati")
            };
        }

        public void OnGet()
        {
            FillManufacturer();
            FillTypeOfModel();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newMotorcycle = new Motorcycle
                {
                    Model = Model,
                    Year = Year,
                    TopSpeed = TopSpeed,
                    HorsePower = HorsePower,
                    TypeOfModel = TypeOfModel,
                    Description = Description,
                    ManufactureName = ManufactureName
                };
                FillManufacturer();
                FillTypeOfModel();

                _motorcyclesService.Add(newMotorcycle);
                _motorcyclesService.Save();
                return RedirectToPage("/Motorcycle/Index");
            }
            FillManufacturer();
            FillTypeOfModel();
            return Page();
        }
    }
}

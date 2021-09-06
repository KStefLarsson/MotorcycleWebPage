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
using MotorcycleWebPage.Infrastructure.Data;

namespace MotorcycleWebPage.Web.Pages.Motorcycles
{
    public class EditModel : PageModel
    {
        private readonly IMotorcyclesService _motorcyclesService;
        private readonly ApplicationDbContext _dbContext;
        public EditModel(IMotorcyclesService motorcyclesService, ApplicationDbContext dbContext)
        {
            _motorcyclesService = motorcyclesService;
            _dbContext = dbContext;
        }

        public int Id { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [BindProperty]
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(10)]
        public string TopSpeed { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(10)]
        public string HorsePower { get; set; }
        [BindProperty]
        [Required]
        [Range(1950, 2025)]
        public int Year { get; set; }
        [BindProperty]
        [Required]
        public string TypeOfModel { get; set; }
        [BindProperty]
        [Required]
        public string ManufactureName { get; set; }
        [BindProperty]
        public int MotorcycleId { get; set; }
        public Manufacture Manufactures { get; set; }
        public List<SelectListItem> AllBikeModels { get; set; }

        public void FillTypeOfModel()
        {
            AllBikeModels = new List<SelectListItem>
            {
                new SelectListItem("Touring", "Touring"),
                new SelectListItem("Sport", "Sport"),
                new SelectListItem("Custom", "Custom")
            };
        }
        public List<SelectListItem> AllManufacturers { get; set; }
        public void FillManufacturer()
        {
            AllManufacturers = new List<SelectListItem>
            {
                new SelectListItem("Triumph", "Triumph"),
                new SelectListItem("Yamaha", "Yamaha"),
                new SelectListItem("Kawazaki", "Kawazaki"),
                new SelectListItem("Ducati", "Ducati")
            };
        }
        public void OnGet(int id)
        {
            var bike = _dbContext.Motorcycles.First(c => c.Id == id);
            Id = bike.Id;
            Model = bike.Model;
            TypeOfModel = bike.TypeOfModel;
            Year = bike.Year;
            TopSpeed = bike.TopSpeed;
            Description = bike.Description;
            HorsePower = bike.HorsePower;
            ManufactureName = bike.ManufactureName;
            FillManufacturer();
            FillTypeOfModel();
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var motorcycle = _dbContext.Motorcycles.First(x => x.Id == id);
                motorcycle.Model = Model;
                motorcycle.TypeOfModel = TypeOfModel;
                motorcycle.Year = Year;
                motorcycle.TopSpeed = TopSpeed;
                motorcycle.Description = Description;
                motorcycle.HorsePower = HorsePower;
                motorcycle.ManufactureName = ManufactureName;
                FillManufacturer();
                FillTypeOfModel();

                _dbContext.SaveChanges();

                return RedirectToPage("/Motorcycles/Index");
            }
            FillManufacturer();
            FillTypeOfModel();
            return Page();
        }
    }
}

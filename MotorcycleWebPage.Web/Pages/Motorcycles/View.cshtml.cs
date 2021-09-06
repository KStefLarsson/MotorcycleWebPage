using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorcycleWebPage.Core.Models;
using MotorcycleWebPage.Infrastructure.Data;

namespace MotorcycleWebPage.Web.Pages.Motorcycles
{
    public class ViewModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public ViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        [MaxLength(10)]
        public string TopSpeed { get; set; }
        [BindProperty]
        [MaxLength(10)]
        public string HorsePower { get; set; }
        [BindProperty]
        public int Year { get; set; }
        [BindProperty]
        [Required]
        public string TypeOfModel { get; set; }
        [BindProperty]
        [Required]
        public string ManufactureName { get; set; }
        [BindProperty]
        public Manufacture Manufactures { get; set; }
        public List<Motorcycle> Motorcycles { get; set; }
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
        }
    }
}

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
        public string Model { get; set; }
        public string Description { get; set; }
        public string TopSpeed { get; set; }
        public string HorsePower { get; set; }
        public int Year { get; set; }
        public string TypeOfModel { get; set; }
        public string ManufactureName { get; set; }
        //public Manufacture Manufactures { get; set; }
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

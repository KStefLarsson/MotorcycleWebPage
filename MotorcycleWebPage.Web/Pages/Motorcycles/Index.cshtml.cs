using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorcycleWebPage.Core.Interfaces.Services;
using MotorcycleWebPage.Core.Models;


namespace MotorcycleWebPage.Web.Pages.Motorcycles
{
    public class IndexModel : PageModel
    {
        private readonly IMotorcyclesService _motorcyclesService;
        public IndexModel(IMotorcyclesService motorcyclesService)
        {
            _motorcyclesService = motorcyclesService;
        }

        public int Id { get; set; }
        public List<Motorcycle> Motorcycles { get; set; }
        public string ManufactureName { get; set; }

        public void OnGet()
        {
            Motorcycles = _motorcyclesService.GetAll();
        }
    }
}

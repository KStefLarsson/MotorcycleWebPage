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
    public class SportBikesModel : PageModel
    {
        private readonly IMotorcyclesService _motorcyclesService;
        public SportBikesModel(IMotorcyclesService motorcyclesService)
        {
            _motorcyclesService = motorcyclesService;
        }

        public List<Motorcycle> SportBikes { get; set; }
        public void OnGet()
        {
            SportBikes = _motorcyclesService.GetAll()
            .Where(x => x.TypeOfModel == "Sport").ToList();
        }
    }
}

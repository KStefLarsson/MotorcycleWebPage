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
    public class TouringBikesModel : PageModel
    {
        private readonly IMotorcyclesService _motorcyclesService;
        public TouringBikesModel(IMotorcyclesService motorcyclesService)
        {
            _motorcyclesService = motorcyclesService;
        }

        public List<Motorcycle> TouringBikes { get; set; }

        public void OnGet()
        {
            TouringBikes = _motorcyclesService.GetAll()
                .Where(x => x.TypeOfModel == "Touring").ToList();
        }
    }
}

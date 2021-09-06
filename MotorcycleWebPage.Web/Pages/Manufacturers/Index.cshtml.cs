using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorcycleWebPage.Core.Interfaces.Services;
using MotorcycleWebPage.Core.Models;

namespace MotorcycleWebPage.Web.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly IManufacturersService _manufacturersService;
        public IndexModel(IManufacturersService manufacturersService)
        {
            _manufacturersService = manufacturersService;
        }

        public int Id { get; set; }
        public List<Manufacture> Facturers { get; set; }

        public void OnGet()
        {
            Facturers = _manufacturersService.GetAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorcycleWebPage.Infrastructure.Data;

namespace MotorcycleWebPage.Web.Pages.SearchResult
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class ProductListItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ManufactureName { get; set; }
            public string Desription { get; set; }
            public string TypeOfModel { get; set; }
        }

        public string SearchWord { get; set; }

        public List<ProductListItem> Products { get; set; }

        public void OnGet(string query)
        {
            Products = _dbContext.Motorcycles.Where(r => r.Model.Contains(query)
                                            || r.ManufactureName.Contains(query)
                                            || r.Description.Contains(query)
                                            || r.TypeOfModel.Contains(query)
            ).Select(p => new ProductListItem
            {
                Id = p.Id,
                Name = p.Model,
                Desription = p.Description,
                TypeOfModel = p.TypeOfModel,
                ManufactureName = p.ManufactureName
            }).ToList();

            SearchWord = query;
        }
    }
}

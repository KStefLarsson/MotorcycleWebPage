using MotorcycleWebPage.Core.Interfaces.Services;
using MotorcycleWebPage.Core.Models;
using MotorcycleWebPage.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebPage.Infrastructure.Services
{
    public class ManufacturersService : IManufacturersService
    {
        private readonly ApplicationDbContext _dbContext;
        public ManufacturersService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Manufacture GetByName(string name)
        {
            return _dbContext.Manufacturers.Where(a => a.Name == name).FirstOrDefault();
        }
        public List<Manufacture> GetAll() => _dbContext.Manufacturers.ToList();

        public void Add(Manufacture manufacture) => _dbContext.Manufacturers.Add(manufacture);
        public void Update(Manufacture manufacture) => _dbContext.Manufacturers.Update(manufacture);

        public void Save() => _dbContext.SaveChanges();
    }
}

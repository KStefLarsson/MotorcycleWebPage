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
    public class MotorcyclesService : IMotorcyclesService
    {
        private readonly ApplicationDbContext _dbContext;
        public MotorcyclesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Motorcycle GetMotorcycleByType(string typeOfModel)
        {
            return _dbContext.Motorcycles.Where(a => a.TypeOfModel == typeOfModel).FirstOrDefault();
        }

        public List<Motorcycle> GetAll() => _dbContext.Motorcycles.ToList();

        public void Add(Motorcycle motorcycle) => _dbContext.Motorcycles.Add(motorcycle);
        public void Update(Motorcycle motorcycle) => _dbContext.Motorcycles.Update(motorcycle);
        public void Save() => _dbContext.SaveChanges();
    }
}

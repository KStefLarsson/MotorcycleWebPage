
using MotorcycleWebPage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebPage.Core.Interfaces.Services
{
    public interface IMotorcyclesService
    {
        List<Motorcycle> GetAll();
        public Motorcycle GetMotorcycleByType(string typeOfModel);
        public void Add(Motorcycle motorcycle);
        public void Update(Motorcycle motorcycle);
        public void Save();
    }
}

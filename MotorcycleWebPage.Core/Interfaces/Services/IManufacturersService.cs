using MotorcycleWebPage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebPage.Core.Interfaces.Services
{
    public interface IManufacturersService
    {
        List<Manufacture> GetAll();
        Manufacture GetByName(string name);
        public void Add(Manufacture manufacturer);
        public void Update(Manufacture manufacturer);
        public void Save();
    }
}

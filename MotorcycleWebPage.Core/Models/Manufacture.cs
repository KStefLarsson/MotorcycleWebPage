using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebPage.Core.Models
{
    public class Manufacture
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [Range(1800, 2025)]
        public int Founded { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public List<Motorcycle> Motorcycles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebPage.Core.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Model { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(10)]
        public string TopSpeed { get; set; }
        [MaxLength(10)]
        public string HorsePower { get; set; }
        [Range(1950, 2025)]
        public int Year { get; set; }
        public string TypeOfModel { get; set; }
        [MaxLength(20)]
        public string ManufactureName { get; set; }
        public Manufacture Manufacturers { get; set; }
    }
}

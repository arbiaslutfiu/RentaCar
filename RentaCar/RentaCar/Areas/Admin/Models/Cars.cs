using RentaCar.Models;
using RentaCar.Models.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Areas.Admin.Models
{
    
    public class Cars
    {   public int    id        { get; set; }
        public string Name      { get; set; }
        public Modeli Model     { get; set; }
        public Color Color     { get; set; }
        public Tipi Type      { get; set; }
        public DateTime Year    { get; set; }
        public double Price     { get; set; }
        public bool   Available { get; set; }
        public string Image     { get; set; }

        public int AutoSallonId { get; set; }
        public AutoSallon AutoSallon { get; set; }


        public IEnumerable<RentaCar.Areas.Admin.Models.Cars> Carss { get; set; }


    }
}

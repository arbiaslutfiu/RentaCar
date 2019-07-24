using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Models.Home
{
    public class IndexViewModel
    {
        public PaginatedList<RentaCar.Areas.Admin.Models.Cars> Cars { get; set; }
        public List<RentaCar.Areas.Admin.Models.Cars> Carss { get; set; }
        public List<RentaCar.Areas.Admin.Models.AutoSallon> AutoSallon { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Areas.Admin.Models
{
    public class AutoSallon
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        //the one who created the autosallon
        public string SuperAcountId { get; set; }
        public IdentityUser SuperAcount { get; set; }

        public List<AutoSallonUser> AutoSallonUsers { get; set; }

    }
}

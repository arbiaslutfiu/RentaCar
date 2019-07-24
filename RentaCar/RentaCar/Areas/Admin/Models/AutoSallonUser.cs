using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Areas.Admin.Models
{
    public class AutoSallonUser
    {
        public int AutoSallonId { get; set; }
        public AutoSallon AutoSallon { get; set; }

       
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}

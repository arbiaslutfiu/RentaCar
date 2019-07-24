using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Areas.Admin.Models.Users
{
    public class ManageUsersViewModel
    {
        public int Id { get; set; }
        public IEnumerable<IdentityUser> AssignedUsers { get; set; }
        public IEnumerable<IdentityUser> AvailableUsers { get; set; }

        public IEnumerable<SelectListItem> AvailableUsersSelectList
        {
            get
            {
                return AvailableUsers != null ? AvailableUsers.Select(u => new SelectListItem { Text = u.Email, Value = u.Id }) : null;
            }
        }
    }
}

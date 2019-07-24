using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Areas.Admin.Models.Users
{
    public class EditUserModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool isAdmin { get; set; }
        public bool isSuperAdmin { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentaCar.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator,Admin")]
    [Area("Admin")]
    public class AdminPanelController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
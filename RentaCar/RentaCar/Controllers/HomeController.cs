using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentaCar.Data;
using RentaCar.Models;
using RentaCar.Models.Home;
using RentaCar.Areas.Admin.Models;

namespace RentaCar.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> AllCars(int? page)
        {
            var cars = _dbContext.Cars                                   
                                    .AsNoTracking();

            int pageSize = 3;

            var vm = new IndexViewModel
            {
                Cars = await PaginatedList<RentaCar.Areas.Admin.Models.Cars>.CreateAsync(cars, page ?? 1, pageSize)
            };

            return View(vm);
        }
        public async Task<IActionResult> Search(RentaCar.Areas.Admin.Models.Cars viewModel)
        {
            var q = _dbContext.Cars.AsQueryable();

            // Filter by name (Name must contain given value)
            if (!String.IsNullOrEmpty(viewModel.Name))
            {
                q = q.Where(p => p.Name == viewModel.Name );
            }

            if (viewModel.Model!=null && viewModel.Model != 0 )
            {
                q = q.Where(p => p.Model ==(viewModel.Model));
            }

            if (viewModel.Color!= null && viewModel.Color != 0)
            {
                q = q.Where(p => p.Color==(viewModel.Color));
            }

            if (viewModel.Type!= null && viewModel.Type != 0)
            {
                q = q.Where(p => p.Type==(viewModel.Type));
            }


            viewModel.Carss = await q.ToListAsync();

            return View(viewModel);
        }
        /*public IActionResult Index()
        {
            var Cars = _dbContext.Cars.ToList();

            var vm = new IndexViewModel
            {
                Cars = Cars
            };
            return View(vm);
        }*/

        public IActionResult Index()
        {
            //var AutoSallon = _dbContext.AutoSallons.ToList();

           // ViewData["Autosallonat"] = new SelectList(_dbContext.AutoSallons, "Name");
       
            return View();
        }
        public IActionResult AdminPanel()
        {

            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentaCar.Data;
using RentaCar.Areas.Admin.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RentaCar.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Admin")]
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static int IdAts { get;set; }

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            

            // find all the autosallons this User is conected to 
            var atsList = _context.AutoSallons
             .Where(ats => ats.AutoSallonUsers
             .FirstOrDefault(s => s.UserId == CurrentUserId) != null);

            IdAts =0;
            ViewBag.AutoSallon = new SelectList(atsList, "Id", "Name");

            var bolu = _context.AutoSallons.FirstOrDefault(
                a=>a.AutoSallonUsers.FirstOrDefault(astu => astu.UserId == CurrentUserId
            || a.SuperAcountId == CurrentUserId) != null);
            
         
           ViewBag.Boull = bolu!=null? true: false;

        
            var newList = await _context.Cars.Where(cr=>cr.AutoSallon.
            AutoSallonUsers.FirstOrDefault(astu=>astu.UserId==CurrentUserId
            || cr.AutoSallon.SuperAcountId== CurrentUserId)!=null).ToListAsync();

            var vm = new ViewModel
            {
                Kerri = newList,
                ATS=0
            };

            return View(vm);
   
        }
        [HttpPost]
        public async Task<IActionResult> Index(ViewModel autoSallon)
        {                   
            //search cars that only belong to that user(Autosallon Owner)
            var idd = autoSallon.ATS;
            IdAts = idd;

            var bolu = _context.AutoSallons.FirstOrDefault(
            a => a.AutoSallonUsers.FirstOrDefault(astu => astu.UserId == CurrentUserId
          || a.SuperAcountId == CurrentUserId) != null);

            ViewBag.Boull = bolu != null ? true : false;

            var titlel = _context.AutoSallons
                        .FirstOrDefault(ats => ats.AutoSallonUsers
                        .FirstOrDefault(s => s.AutoSallonId == idd)!= null).Name;
            ViewBag.tituli = titlel;
            //search cars that only belong to that user(Autosallon staff)
            var newList2 = await _context.Cars.Where(a => a.AutoSallonId ==idd).ToListAsync();
           
            var vm = new ViewModel
            {
                Kerri = newList2,
                ATS = idd
            };
            var atsList = _context.AutoSallons
            .Where(ats => ats.AutoSallonUsers
            .FirstOrDefault(s => s.UserId == CurrentUserId) != null);

            ViewBag.AutoSallon = new SelectList(atsList, "Id", "Name",idd);
            return View(vm);
        }
        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .FirstOrDefaultAsync(m => m.id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cars cars, IFormFile imageFile)
        {
            if (ModelState.IsValid && imageFile != null)
            {

                var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
                var fileDirectory = "wwwroot/images";

                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }                
                var filePath = fileDirectory + "/" + fileName;

                // Copy file to path...
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                cars.Image = fileName;

                // Add object to db
                if (IdAts!=null&&IdAts!=0) {
                    cars.AutoSallon = _context.AutoSallons
                        .FirstOrDefault(ats => ats.Id == IdAts);
                }
                else
                {
                    cars.AutoSallon = _context.AutoSallons
                   .FirstOrDefault(ats => ats.AutoSallonUsers
                   .FirstOrDefault(s => s.AutoSallonId == ats.Id).AutoSallon.SuperAcountId == CurrentUserId);
                }
                _context.Add(cars);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Model,Color,Type,Year,Price,Available,Image,AutoSallon,AutoSallonId")] Cars cars, IFormFile imageFile)
        {
            if (id != cars.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null)
                    {
                        var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
                        var fileDirectory = "wwwroot/images";

                        if (!Directory.Exists(fileDirectory))
                        {
                            Directory.CreateDirectory(fileDirectory);
                        }

                        var filePath = fileDirectory + "/" + fileName;

                        // Copy file to path...
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        cars.Image = fileName;
                    }
                    else
                    {

                    }
                    if (cars.AutoSallon != null)
                    {
                        _context.Update(cars);
                    }
                    else
                    {

                        if (IdAts != null && IdAts != 0)
                        {
                            cars.AutoSallon = _context.AutoSallons
                                .FirstOrDefault(ats => ats.Id == IdAts);
                            _context.Update(cars);
                        }
                        else
                        {
                            cars.AutoSallon = _context.AutoSallons
                           .FirstOrDefault(ats => ats.AutoSallonUsers
                           .FirstOrDefault(s => s.AutoSallonId == ats.Id).AutoSallon.SuperAcountId == CurrentUserId);
                            _context.Update(cars);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsExists(cars.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .FirstOrDefaultAsync(m => m.id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cars = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsExists(int id)
        {
            return _context.Cars.Any(e => e.id == id);
        }
    }
}

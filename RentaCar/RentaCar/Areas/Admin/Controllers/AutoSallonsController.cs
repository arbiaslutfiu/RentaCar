using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentaCar.Data;
using RentaCar.Areas.Admin.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RentaCar.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class AutoSallonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AutoSallonsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;


        }
        public string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }
        // GET: Admin/AutoSallons
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";            var cars = from s in _context.AutoSallons                       select s;            switch (sortOrder)            {                case "name_desc":                    cars = cars.OrderByDescending(s => s.Name);                    break;                case "Price":                    cars = cars.OrderBy(s => s.SuperAcount);                    break;                case "price_desc":                    cars = cars.OrderByDescending(s => s.SuperAcount);                    break;                default:                    cars = cars.OrderBy(s => s.Name);                    break;            }            

            var applicationDbContext = cars.Include(a => a.SuperAcount);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/AutoSallons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoSallon = await _context.AutoSallons
                .Include(a => a.SuperAcount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoSallon == null)
            {
                return NotFound();
            }

            return View(autoSallon);
        }

        // GET: Admin/AutoSallons/Create
        public IActionResult Create()
        {
            ViewData["SuperAcountId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Admin/AutoSallons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SuperAcountId")] AutoSallon autoSallon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoSallon);
                
                _context.AutoSallonUsers.Add(new AutoSallonUser
                {
                    UserId = autoSallon.SuperAcountId,
                    AutoSallon = autoSallon
                });
                 
                await _context.SaveChangesAsync();

              
                return RedirectToAction(nameof(Index));

             
            }
            ViewData["SuperAcountId"] = new SelectList(_context.Users, "Id", "Email", autoSallon.SuperAcountId);
            return View(autoSallon);
        }

        // GET: Admin/AutoSallons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoSallon = await _context.AutoSallons.FindAsync(id);
            if (autoSallon == null)
            {
                return NotFound();
            }
            ViewData["SuperAcountId"] = new SelectList(_context.Users, "Id", "Email", autoSallon.SuperAcountId);
            return View(autoSallon);
        }

        // POST: Admin/AutoSallons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SuperAcountId")] AutoSallon autoSallon)
        {
            if (id != autoSallon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoSallon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoSallonExists(autoSallon.Id))
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
            ViewData["SuperAcountId"] = new SelectList(_context.Users, "Id", "Email", autoSallon.SuperAcountId);
            return View(autoSallon);
        }

        // GET: Admin/AutoSallons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoSallon = await _context.AutoSallons
                .Include(a => a.SuperAcount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoSallon == null)
            {
                return NotFound();
            }

            return View(autoSallon);
        }

        // POST: Admin/AutoSallons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoSallon = await _context.AutoSallons.FindAsync(id);
            _context.AutoSallons.Remove(autoSallon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoSallonExists(int id)
        {
            return _context.AutoSallons.Any(e => e.Id == id);
        }


        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ManageUsers(int id)
        {
            var autosallon = await _context.AutoSallons
                                .Include(a => a.AutoSallonUsers)
                                .ThenInclude(au => au.User)
                                .SingleOrDefaultAsync(a => a.Id == id);

            var allUsers = await _userManager.GetUsersInRoleAsync(Util.SD.AdminEndUser);

            var vm = new ManageUsersViewModel();
            vm.Id = id;
            vm.AssignedUsers = autosallon.AutoSallonUsers.Select(au => au.User);
            vm.AvailableUsers = allUsers.Where(u => !vm.AssignedUsers.Any(x => x.Id == u.Id));

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddUserToAutoSallon(int id, string userId)
        {
            
            if (userId != null && userId != "")
            {
                _context.AutoSallonUsers.Add(new AutoSallonUser
                {
                    AutoSallonId = id,
                    UserId = userId
                });
                // _context.AutoSallons.FirstOrDefault(a=>a.Id ==id).SuperAcountId =userId;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ManageUsers), new { id = id });
            }
            else return View("errori");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveUserFromAutosSallon(int id, string userId)
        {   
            var au = await _context.AutoSallonUsers.SingleOrDefaultAsync(a => a.UserId == userId && a.AutoSallonId == id);
           // var aa =await _context.AutoSallons.SingleOrDefaultAsync(a=>a.SuperAcountId==userId);
            if (au != null)
            {
                _context.AutoSallonUsers.Remove(au);
                //_context.AutoSallons.Remove(aa);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(ManageUsers), new { id = id });
        }

        private async Task<bool> HasAccessToAutoSallon(int autosallonId)
        {
            if (User.IsInRole("Administrator"))
                return true;

            var autosallon = await _context.AutoSallons
                                .Where(a => a.Id == autosallonId)
                                .Where(a => a.AutoSallonUsers.Exists(au => au.UserId == CurrentUserId))
                                .SingleOrDefaultAsync();

            return autosallon != null;
        }

    }
}

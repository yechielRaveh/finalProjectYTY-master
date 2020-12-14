using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using invoiceProject.Data;
using invoiceProject.Models;

namespace invoiceProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly invoiceProjectContext _context;

        public UsersController(invoiceProjectContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        // GET: Users
        public async Task<IActionResult> Login()
        {
            return View();
        }
        /*// POST: Users/Login
         public async Task<IActionResult> Login()
         {
             return View();
         }
        */
        public async Task<IActionResult> Register()
        {
            return View();
        }


        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FirstName,LastName,UserName,Password,IsAdmin,Email,EnteranceDate")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,FirstName,LastName,UserName,Password,IsAdmin,Email,EnteranceDate")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MyAccount()
        {
            return View();
        }
        public async Task<IActionResult> ViewInvoices()
        {
            return View();
        }
        public async Task<IActionResult> ViewCredits()
        {
            return View();
        }
        public async Task<IActionResult> ViewGiftCards()
        {
            return View();
        }
        public async Task<IActionResult> NewGiftCard()
        {
            return View();
        }
        public async Task<IActionResult> NewInvoice()
        {
            return View();
        }
        public async Task<IActionResult> NewCredit()
        {
            return View();
        }

        public async Task<IActionResult> Admin()
        {
            return View();
        }
        public async Task<IActionResult> AdminViewInvoices()
        {
            return View();
        }
        public async Task<IActionResult> AdminViewCredits()
        {
            return View();
        }
        public async Task<IActionResult> AdminViewGiftCards()
        {
            return View();
        }
        public async Task<IActionResult> AdminNewInvoice()
        {
            return View();
        }
        public async Task<IActionResult> AdminNewCredit()
        {
            return View();
        }
        public async Task<IActionResult> AdminNewGiftCard()
        {
            return View();
        }
        public async Task<IActionResult> AdminViewUsers()
        {
            return View();
        }
        public async Task<IActionResult> AdminNewUser()
        {
            return View();
        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserID == id);
        }
    }
}

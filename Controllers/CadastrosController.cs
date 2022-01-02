using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prover.Data;
using Prover.Models;

namespace Prover.Controllers
{
    [Authorize]
    public class CadastrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cadastros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cadastros.Include(c => c.Cargos);
            return View(await applicationDbContext
                .AsNoTracking()
                .Where(x => x.User == User.Identity.Name)
                .ToListAsync());
        }

        // GET: Cadastros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .Include(c => c.Cargos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            if(cadastro.User != User.Identity.Name)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastros/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Description");
            return View();
        }

        // POST: Cadastros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Telephone,DateOfBirth,Age,MaleOrFemale,CargoId,User,Active")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                cadastro.User = User.Identity.Name;
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Description", cadastro.CargoId);
            return View(cadastro);
        }

        // GET: Cadastros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            if(cadastro.User != User.Identity.Name)
            {
                return NotFound();
            }

            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Description", cadastro.CargoId);
            return View(cadastro);
        }

        // POST: Cadastros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Telephone,DateOfBirth,Age,MaleOrFemale,CargoId,User,Active")] Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cadastro.User = User.Identity.Name;
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.Id))
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
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Description", cadastro.CargoId);
            return View(cadastro);
        }

        // GET: Cadastros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .Include(c => c.Cargos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            if(cadastro.User != User.Identity.Name)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            _context.Cadastros.Remove(cadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int id)
        {
            return _context.Cadastros.Any(e => e.Id == id);
        }
    }
}

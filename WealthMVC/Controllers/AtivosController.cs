using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealth.Tools.database;
using WealthMVC.Models;
using WealthMVC.Services;

namespace WealthMVC.Controllers
{
    public class AtivosController : Controller
    {
        private readonly Contexto _context;
        //private readonly AtivosService _service;

        #region Controller
        public AtivosController(Contexto context)
        {
            _context = context;
        }
        #endregion

        #region Get Index
        // GET: Ativos
        public async Task<IActionResult> Index()
        {
            return _context.Ativos != null ?
                        View(await _context.Ativos.ToListAsync()) :
                        Problem("Entity set 'Contexto.Ativos'  is null.");
        }
        #endregion

        #region Get Details
        // GET: Ativos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Ativos == null)
            {
                return NotFound();
            }

            var ativos = await _context.Ativos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ativos == null)
            {
                return NotFound();
            }

            return View(ativos);
        }
        #endregion

        #region Get Create
        // GET: Ativos/Create
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Post Create
        // POST: Ativos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Classe,Codigo,Descricao,Id")] Ativos ativos)
        {
            ativos.Codigo = ativos.Codigo.ToUpper();
            ativos.Id = _context.ValidaId(ativos.Id);
            if (ModelState.IsValid)
            {
                _context.Add(ativos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ativos);
        }
        #endregion

        #region Get Edit
        // GET: Ativos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Ativos == null)
            {
                return NotFound();
            }

            var ativos = await _context.Ativos.FindAsync(id);
            if (ativos == null)
            {
                return NotFound();
            }
            return View(ativos);
        }
        #endregion

        #region Post Edit
        // POST: Ativos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Classe,Codigo,Descricao,Id")] Ativos ativos)
        {
            if (id != ativos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ativos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtivosExists(ativos.Id))
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
            return View(ativos);
        }
        #endregion

        #region Get Delete
        // GET: Ativos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Ativos == null)
            {
                return NotFound();
            }

            var ativos = await _context.Ativos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ativos == null)
            {
                return NotFound();
            }

            return View(ativos);
        }
        #endregion

        #region Post Delete Confirmed
        // POST: Ativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Ativos == null)
            {
                return Problem("Entity set 'Contexto.Ativos'  is null.");
            }
            var ativos = await _context.Ativos.FindAsync(id);
            if (ativos != null)
            {
                _context.Ativos.Remove(ativos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Ativos Exists
        private bool AtivosExists(string id)
        {
            return (_context.Ativos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion

    }
}

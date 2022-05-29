using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealth.Tools.database;
using WealthMVC.Models;

namespace WealthMVC.Controllers
{
    public class OperacoesController : Controller
    {
        private readonly Contexto _context;

        public OperacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Operacoes
        public async Task<IActionResult> Index()
        {
            return _context.Operacoes != null ?
                        View(await _context.Operacoes.ToListAsync()) :
                        Problem("Entity set 'Contexto.Operacoes'  is null.");
        }

        // GET: Operacoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Operacoes == null)
            {
                return NotFound();
            }

            var operacoes = await _context.Operacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operacoes == null)
            {
                return NotFound();
            }

            return View(operacoes);
        }

        // GET: Operacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Data,AtivosId,Quantidade,Preco")] Operacoes operacoes)
        {

            operacoes.Id = _context.ValidaId(operacoes.Id);
            if (ModelState.IsValid)
            {
                _context.Add(operacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operacoes);
        }

        // GET: Operacoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Operacoes == null)
            {
                return NotFound();
            }

            var operacoes = await _context.Operacoes.FindAsync(id);
            if (operacoes == null)
            {
                return NotFound();
            }
            return View(operacoes);
        }

        // POST: Operacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Tipo,Data,AtivosId,Quantidade,Preco")] Operacoes operacoes)
        {
            if (id != operacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperacoesExists(operacoes.Id))
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
            return View(operacoes);
        }

        // GET: Operacoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Operacoes == null)
            {
                return NotFound();
            }

            var operacoes = await _context.Operacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operacoes == null)
            {
                return NotFound();
            }

            return View(operacoes);
        }

        // POST: Operacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Operacoes == null)
            {
                return Problem("Entity set 'Contexto.Operacoes'  is null.");
            }
            var operacoes = await _context.Operacoes.FindAsync(id);
            if (operacoes != null)
            {
                _context.Operacoes.Remove(operacoes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperacoesExists(string id)
        {
            return (_context.Operacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

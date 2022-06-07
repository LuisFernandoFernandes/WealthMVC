using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealth.Tools.database;
using WealthMVC.Enums;
using WealthMVC.Models;
using WealthMVC.Repository;
using WealthMVC.Services;
using WealthMVC.Services.Interfaces;
using WealthMVC.Tools.wrapper;

namespace WealthMVC.Controllers
{
    public class AtivosController : Controller
    {

        #region Construtor
        private readonly Contexto _context;
        private readonly IAtivosService _service;

        public AtivosController(Contexto context)
        {
            _context = context;
            _service = new AtivosService(new ModelStateWrapper(ModelState), new AtivosRepository(_context.Ativos));
        }
        #endregion

        #region Get Index
        public async Task<IActionResult> Index()
        {
            return _service != null ? View(await _service.ListaAtivos()) : Problem("Entity set 'Contexto.Ativos'  is null.");
        }
        #endregion

        #region Get Create
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Classe,Codigo,Descricao,Id")] Ativos ativos)
        {
            return (await _service.Create(ativos, _context) is eBoolean.Sim) ? RedirectToAction(nameof(Index)) : View(ativos);
        }
        #endregion

        #region Get Edit
        public async Task<IActionResult> Edit(string id)
        {

            return (await _service.GetEdit(id, _context) is eBoolean.Sim) ? View(await _context.Ativos.FindAsync(id)) : NotFound();
        }
        #endregion

        #region Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Classe,Codigo,Descricao,Id")] Ativos ativos)
        {
            return (await _service.PostEdit(id, ativos, _context) is eBoolean.Sim) ? RedirectToAction(nameof(Index)) :
                (await _service.ValidaModelState(id, ativos, _context) is eBoolean.Nao) ? View(ativos) : NotFound();
            #endregion

            //#region Get Delete
            //// GET: Ativos/Delete/5
            //public async Task<IActionResult> Delete(string id)
            //{
            //    if (id == null || _context.Ativos == null)
            //    {
            //        return NotFound();
            //    }

            //    var ativos = await _context.Ativos
            //        .FirstOrDefaultAsync(m => m.Id == id);
            //    if (ativos == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(ativos);
            //}
            //#endregion

            //#region Post Delete Confirmed
            //// POST: Ativos/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> DeleteConfirmed(string id)
            //{
            //    if (_context.Ativos == null)
            //    {
            //        return Problem("Entity set 'Contexto.Ativos'  is null.");
            //    }
            //    var ativos = await _context.Ativos.FindAsync(id);
            //    if (ativos != null)
            //    {
            //        _context.Ativos.Remove(ativos);
            //    }

            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //#endregion
        }
    }
}

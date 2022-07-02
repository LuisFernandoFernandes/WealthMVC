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
        #region Variáveis
        private readonly Contexto _context;
        private readonly IAtivosService _service;
        #endregion

        #region Construtor
        public AtivosController(Contexto context)
        {
            _context = context;
            _service = new AtivosService(new ModelStateWrapper(ModelState), new AtivosRepository(_context.Ativos));
        }
        #endregion

        #region Get Index
        public async Task<IActionResult> Index()
        {
            return _service != null ? View(await _service.GetAtivos()) : Problem("Entity set 'Contexto.Ativos'  is null.");
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
            return (await _service.Create(ativos, _context) is eResult.Ok) ? RedirectToAction(nameof(Index)) : View(ativos);
        }
        #endregion

        #region Get Edit
        public async Task<IActionResult> Edit(string id)
        {

            return (await _service.GetEdit(id, _context) is eResult.Ok) ? View(await _service.GetAtivoById(id, _context)) : NotFound();
        }
        #endregion

        #region Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Classe,Codigo,Descricao,Id")] Ativos ativos)
        {
            return (await _service.ValidaModelState(id, ativos) is eResult.Invalid) ? View(ativos) : (await _service.PostEdit(id, ativos, _context) is eResult.Ok) ? RedirectToAction(nameof(Index)) : NotFound();
        }
        #endregion

        #region Get Delete
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _service.Delete(id, _context);

            switch (result)
            {
                case eResult.Ok:
                    return View(await _service.GetAtivoById(id, _context));
                case eResult.Invalid:
                    return NotFound("O Ativo não pode ser excluído.");
                default:
                    return NotFound();
            }

            //return (await _service.Delete(id, _context) is eResult.Ok) ? View(await _service.GetAtivoById(id, _context)) : NotFound("O Ativo não pode ser excluído.");
        }
        #endregion

        #region Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            return (await _service.DeleteConfirmed(id, _context) is eResult.Ok) ? RedirectToAction(nameof(Index)) : Problem("Entity set 'Contexto.Ativos'  is null.");
        }
        #endregion
    }
}


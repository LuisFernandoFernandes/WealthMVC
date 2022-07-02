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
    public class OperacoesController : Controller
    {
        #region Variáveis
        private readonly Contexto _context;
        private readonly IOperacoesService _service;
        #endregion

        #region Construtor
        public OperacoesController(Contexto context)
        {
            _context = context;
            _service = new OperacoesService(new ModelStateWrapper(ModelState), new OperacoesRepository(_context.Operacoes));

        }
        #endregion

        #region Get Index
        public async Task<IActionResult> Index()
        {
            return _context.Operacoes != null ? View(await _service.GetOperacoes(_context)) : Problem("Entity set 'Contexto.Operacoes'  is null.");
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
        public async Task<IActionResult> Create([Bind("Id,Tipo,Data,AtivosId,Quantidade,Preco")] Operacoes operacao, Ativos ativos)
        {

            return (await _service.Create(operacao, ativos, _context) is eResult.Ok) ? RedirectToAction(nameof(Index)) : (await _service.Create(operacao, ativos, _context) is eResult.Invalid) ? View(operacao) : RedirectToAction(nameof(Create), nameof(Ativos));
        }
        #endregion

        # region Get Edit
        public async Task<IActionResult> Edit(string id)
        {

            return (await _service.GetEdit(id, _context) is eResult.Ok) ? View(await _service.GetOperacaoById(id, _context)) : NotFound();
        }
        #endregion

        #region Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Tipo,Data,AtivosId,Quantidade,Preco")] Operacoes operacoes)
        {
            return (await _service.ValidaModelState(id, operacoes) is eResult.Invalid) ? View(operacoes) : (await _service.PostEdit(id, operacoes, _context) is eResult.Ok) ? RedirectToAction(nameof(Index)) : NotFound();
        }
        #endregion

        #region Get Delete
        public async Task<IActionResult> Delete(string id)
        {

            return (await _service.Delete(id, _context) is eResult.Ok) ? View(await _service.GetOperacaoById(id, _context)) : NotFound();
        }
        #endregion

        #region Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            return (await _service.DeleteConfirmed(id, _context) is eResult.Ok) ? RedirectToAction(nameof(Index)) : Problem("Entity set 'Contexto.Operacoes'  is null.");
        }
        #endregion

    }
}

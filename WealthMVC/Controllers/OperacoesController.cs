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
    public class OperacoesController : Controller
    {
        private readonly Contexto _context;

        #region Construtor
        public OperacoesController(Contexto context)
        {
            _context = context;
        }
        #endregion

        #region Get Index
        public async Task<IActionResult> Index()
        {

            var operacoes = await _context.Operacoes.ToListAsync();

            List<Operacoes> operacoesList = new List<Operacoes>();
            foreach (var operacao in operacoes)
            {
                var ativo = _context.Ativos.AsQueryable()
                     .Where(a => a.Id == operacao.AtivosId).FirstOrDefault();

                operacao.Ativos = ativo;
                operacoesList.Add(operacao);
            }

            return _context.Operacoes != null ?
                        View(operacoesList) :
                        Problem("Entity set 'Contexto.Operacoes'  is null.");
        }
        #endregion

        #region Get Details
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
        public async Task<IActionResult> Create([Bind("Id,Tipo,Data,AtivosId,Quantidade,Preco, QuantidadeAtual, PrecoAtual")] Operacoes operacao, Ativos ativos)
        {
            ativos.Codigo = ativos.Codigo.ToUpper();

            ativos = _context.Ativos.AsQueryable().Where(a => a.Codigo == ativos.Codigo).FirstOrDefault();

            operacao.Ativos = ativos;

            operacao.AtivosId = operacao.Ativos.Id;

            operacao.Id = _context.ValidaId(operacao.Id);

            var operacoes = _context.Operacoes.AsQueryable().Where(a => a.AtivosId == ativos.Id).ToList();

            if (operacoes.Count == 0)
            {
                operacao.QuantidadeAtual = operacao.Quantidade;
                operacao.PrecoAtual = operacao.Preco;
            }
            else
            {


                decimal quantidadeAtual = 0;
                decimal quantidadeComprada = 0;
                decimal valorTotal = 0;


                foreach (var item in operacoes)
                {
                    if (item.Tipo == Enums.eOperacoesTipo.Compra)
                    {
                        valorTotal = (item.Preco * item.Quantidade) + valorTotal;
                        quantidadeComprada = quantidadeComprada + item.Quantidade;
                        quantidadeAtual = quantidadeAtual + item.Quantidade;
                    }
                    else if (item.Tipo == Enums.eOperacoesTipo.Venda)
                    {
                        quantidadeAtual = quantidadeAtual - item.Quantidade;
                    }
                }

                if (operacao.Tipo == Enums.eOperacoesTipo.Compra)
                {
                    valorTotal = (operacao.Preco * operacao.Quantidade) + valorTotal;
                    quantidadeComprada = quantidadeComprada + operacao.Quantidade;
                    quantidadeAtual = quantidadeAtual + operacao.Quantidade;
                }
                else if (operacao.Tipo == Enums.eOperacoesTipo.Venda)
                {
                    quantidadeAtual = quantidadeAtual - operacao.Quantidade;
                }

                if (quantidadeAtual != 0)
                {
                    var precoMedio = valorTotal / quantidadeComprada;

                    operacao.QuantidadeAtual = quantidadeAtual;
                    operacao.PrecoAtual = precoMedio;
                }
            }


            if (ModelState.IsValid)
            {
                _context.Add(operacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operacao);
        }
        #endregion

        # region Get Edit
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

            var ativo = _context.Ativos.AsQueryable()
                     .Where(a => a.Id == operacoes.AtivosId).FirstOrDefault();
            operacoes.Ativos = ativo;

            return View(operacoes);
        }
        #endregion

        #region Post Edit
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
        #endregion

        #region Get Delete
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
        #endregion

        #region Post Delete
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
        #endregion

        #region Operacoes Exists
        private bool OperacoesExists(string id)
        {
            return (_context.Operacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}

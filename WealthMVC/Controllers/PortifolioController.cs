
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealth.Tools.database;
using WealthMVC.Interfaces;
using WealthMVC.Models;
using WealthMVC.Repository;
using WealthMVC.Services;
using WealthMVC.Tools.wrapper;

namespace WealthMVC.Controllers
{
    public class PortifolioController : Controller
    {
        private readonly Contexto _context;
        private readonly IPortifolioService _service;

        public PortifolioController(Contexto context)
        {
            _context = context;
            _service = new PortifolioService(new ModelStateWrapper(ModelState), new PortifolioRepository(_context.Portifolio));
        }

        #region Get Portifolio
        public async Task<IActionResult> Index()
        {
            var portifolio = await _context.Portifolio.ToListAsync();

            List<Portifolio> portifolioList = new List<Portifolio>();
            foreach (var item in portifolio)
            {
                if (item.Quantidade != 0)
                {

                    var ativo = _context.Ativos.AsQueryable()
                         .Where(a => a.Id == item.AtivosId).FirstOrDefault();

                    item.Ativos = ativo;
                    portifolioList.Add(item);
                }
            }

            return _context.Portifolio != null ? View(await _service.GetPortifolio(_context)) : Problem("Entity set 'Contexto.Operacoes'  is null.");
        }
        #endregion
    }
}


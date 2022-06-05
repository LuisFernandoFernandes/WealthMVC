
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
    public class PortifolioController : Controller
    {
        private readonly Contexto _context;

        public PortifolioController(Contexto context)
        {
            _context = context;
        }

        #region Get Portifolio
        public async Task<IActionResult> Index()
        {

            var operacoes = _context.Operacoes.OrderByDescending(a => a.Data);
            var ativos = await _context.Ativos.ToListAsync();

            List<Portifolio> retorno = new List<Portifolio>();
            foreach (var ativo in ativos)
            {
                foreach (var operacao in operacoes)
                {
                    if (operacao.AtivosId == ativo.Id)
                    {
                        Portifolio portifolio = new Portifolio
                        {
                            Ativos = ativo,
                            Operacoes = operacao
                        };
                        retorno.Add(portifolio);
                        break;
                    }
                }
            }

            return View(retorno);



            //var contexto = _context.Portifolio.Include(p => p.Ativos);
            //return View(await _context.Portifolio.ToListAsync());
        }
        #endregion

    }
}


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


            //var ativos = await _context.Ativos.ToListAsync();

            //List<object> lista = new List<object>();
            //foreach (var ativo in ativos)
            //{
            //    lista.Add(GetDados(ativo.Id));
            //}

            //return View(lista);

            // var contexto = _context.Portifolio.Include(p => p.Ativos);
            return View(await _context.Portifolio.ToListAsync());
        }
        #endregion

        #region Get Dados
        /// <summary>
        /// Retorna os dados que compoem o portifólio: Ativos, PrecoMedio, QuantidadeAtual, TotalAquisicao.
        /// </summary>
        /// <param name="ativoId"></param>
        public List<Object> GetDados(string ativoId)
        {
            List<Object> portifolioItem = new List<Object>();
            var ativo = _context.Ativos.AsQueryable().Where(a => a.Id == ativoId).FirstOrDefault();
            var operacoes = _context.Operacoes.AsQueryable().Where(a => a.AtivosId == ativoId).ToList();


            decimal quantidadeComprada = 0;
            decimal quantidadeAtual = 0;
            decimal valorTotal = 0;
            foreach (var operacao in operacoes)
            {
                if (operacao.Tipo == Enums.eOperacoesTipo.Compra)
                {
                    valorTotal = (operacao.Preco * operacao.Quantidade) + valorTotal;
                    quantidadeComprada = quantidadeComprada + operacao.Quantidade;
                }
                else if (operacao.Tipo == Enums.eOperacoesTipo.Venda)
                {
                    quantidadeAtual = quantidadeComprada - operacao.Quantidade;
                }
            }
            if (quantidadeAtual == 0) { return portifolioItem; }
            var precoMedio = valorTotal / quantidadeComprada;
            var totalAquisicao = precoMedio * quantidadeAtual;

            portifolioItem.Add(ativo);
            portifolioItem.Add(precoMedio);
            portifolioItem.Add(quantidadeAtual);
            portifolioItem.Add(totalAquisicao);

            return portifolioItem;
        }
        #endregion

    }
}

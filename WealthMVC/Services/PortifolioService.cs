﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using System.Text.Json;
using System.Text.RegularExpressions;
using Wealth.Tools.database;
using WealthMVC.Interfaces;
using WealthMVC.Models;
using WealthMVC.Repository;
using WealthMVC.Services.Interfaces;

namespace WealthMVC.Services
{
    public class PortifolioService : GenericService<Portifolio>, IPortifolioService
    {
        #region Variáveis
        private IValidationDictionary _validatonDictionary;
        private PortifolioRepository _repository;
        //private Contexto _context;

        ModelStateDictionary modelState = new ModelStateDictionary();
        #endregion

        #region Construtor
        public PortifolioService(IValidationDictionary validatonDictionary, PortifolioRepository repository)
        {
            _validatonDictionary = validatonDictionary;
            _repository = repository;
        }
        #endregion

        #region Get Portifolio
        public async Task<List<Portifolio>> GetPortifolio(Contexto context)
        {
            var portifolio = await _repository.ListaPortifolio();

            List<Portifolio> portifolioList = new List<Portifolio>();
            foreach (var item in portifolio)
            {
                if (item.Quantidade != 0)
                {

                    var ativo = context.Ativos.AsQueryable()
                         .Where(a => a.Id == item.AtivosId).FirstOrDefault();

                    item.Ativos = ativo;
                    portifolioList.Add(item);
                }
            }
            await AtualizaCotacao(portifolioList, context);
            return portifolioList;
        }
        #endregion

        #region Atualiza Cotação
        public async Task AtualizaCotacao(List<Portifolio> portifolioList, Contexto context)
        {
            try
            {
                //List<Portifolio> list = await GetPortifolio();
                var region = "US";
                var lang = "en";
                var symbols = string.Empty;

                //var quoteApi = RestService.For<IQuoteApiService>("https://yfapi.net");
                var httpClient = new HttpClient { BaseAddress = new Uri("https://yfapi.net") };
                httpClient.DefaultRequestHeaders.Add("X-API-KEY",
    "3is5bPA8jz2qISzKAokjk8kzWrbaxfwc850dCT7M");
                httpClient.DefaultRequestHeaders.Add("accept",
    "application/json");

                var count = 0;
                var lastItem = 0;
                //List<double> precosAtuais = new List<double>();
                foreach (var item in portifolioList)
                {
                    var ticker = AdequaTicker(item.Ativos.Codigo);
                    //if(item.Ativos.Region == eRegion.US) - Criar enum para valiadar a region

                    symbols = (count == 0) ? ticker : symbols + "%2C" + ticker;
                    count = (count != 9) ? count + 1 : count = 0;
                    lastItem++;

                    if (count == 0 || lastItem == portifolioList.Count)
                    {
                        QuoteResponse quote = new QuoteResponse();

                        //Não apagar, funciona
                        var response = await httpClient.GetAsync($"v6/finance/quote?region={region}&lang={lang}&symbols={symbols}");

                        //response para teste.
                        //var response = await httpClient.GetAsync($"v6/finance/quote?region={region}&lang={lang}&symbols=AAPL%2CMSFT%2CURA");


                        var responseBody = await response.Content.ReadAsStringAsync();


                        var data = JsonConvert.DeserializeObject<Root>(responseBody);
                        var results = data.quoteResponse.result;





                        for (int i = 0; i < results.Count; i++)
                        {
                            var ativoResult = context.Portifolio.AsQueryable().Where(a => a.Ativos.Codigo == results[i].symbol).FirstOrDefault();
                            ativoResult.PrecoAtual = results[i].regularMarketPrice;
                            await context.SaveChangesAsync();
                            //precosAtuais.Add(data.quoteResponse.result[i].regularMarketPrice);
                        }






                        //Não apagar, funciona
                        //var data = JsonConvert.DeserializeObject<Root>(responseBody);
                        //var precos = data.quoteResponse.result[0].regularMarketPrice;

                        //Não apagar, funciona
                        //var data = (JObject)JsonConvert.DeserializeObject(responseBody);
                        //var address2 = data.SelectToken("quoteResponse.result[0].symbol").Value<string>();

                    }

                }

                //foreach (var item in portifolioList)


            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Adequa Ticker
        private string AdequaTicker(string ticker)
        {
            return (Char.IsNumber(ticker[ticker.Length - 1])) ? ticker + ".SA" : ticker;
        }
        #endregion
    }
}

using Refit;
using WealthMVC.Models;

namespace WealthMVC.Interfaces
{
    public interface IQuoteApiService
    {
        /// <summary>
        /// Retorna informações sobre até dez ativos da mesma região em tempo real.
        /// É necessário definir a região dos ativos, o idioma do retorno e concatenar os ativos.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="lang"></param>
        /// <param name="symbols"></param>
        /// <returns></returns>
        [Get("/v6/finance/quote?region={region}&lang={lang}&symbols={symbols}")]
        Task<QuoteResponse> GetDataAsync(string region, string lang, string symbols);
    }
}

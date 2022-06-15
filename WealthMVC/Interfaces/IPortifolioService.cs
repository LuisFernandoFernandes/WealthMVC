using Wealth.Tools.database;
using WealthMVC.Models;
using WealthMVC.Services.Interfaces;

namespace WealthMVC.Interfaces
{
    internal interface IPortifolioService : IGenericService<Portifolio>
    {
        Task<List<Portifolio>> GetPortifolio(Contexto context);
    }
}
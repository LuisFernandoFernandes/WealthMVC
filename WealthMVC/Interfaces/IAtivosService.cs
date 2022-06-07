using Microsoft.AspNetCore.Mvc;
using Wealth.Tools.database;
using WealthMVC.Enums;
using WealthMVC.Models;

namespace WealthMVC.Services.Interfaces
{
    public interface IAtivosService : IGenericService<Ativos>
    {
        Task<IEnumerable<Ativos>> ListaAtivos();
        Task<eBoolean> Create(Ativos ativos, Contexto context);
        Task<eBoolean> GetEdit(string id, Contexto context);
        Task<eBoolean> PostEdit(string id, Ativos ativos, Contexto context);
        Task<eBoolean> ValidaModelState(string id, Ativos ativos, Contexto context);
        bool AtivosExists(string id, Contexto context);
    }
}
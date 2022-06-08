using Microsoft.AspNetCore.Mvc;
using Wealth.Tools.database;
using WealthMVC.Enums;
using WealthMVC.Models;

namespace WealthMVC.Services.Interfaces
{
    public interface IAtivosService : IGenericService<Ativos>
    {
        Task<IEnumerable<Ativos>> GetAtivos();
        Task<eResult> Create(Ativos ativos, Contexto context);
        Task<eResult> GetEdit(string id, Contexto context);
        Task<eResult> PostEdit(string id, Ativos ativos, Contexto context);
        Task<eResult> Delete(string id, Contexto context);
        Task<eResult> DeleteConfirmed(string id, Contexto context);
        Task<Ativos> GetAtivoById(string id, Contexto context);
        Task<eResult> ValidaModelState(string id, Ativos ativos);
        bool AtivosExists(string id, Contexto context);
    }
}
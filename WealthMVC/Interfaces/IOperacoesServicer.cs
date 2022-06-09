using Wealth.Tools.database;
using WealthMVC.Enums;
using WealthMVC.Models;

namespace WealthMVC.Services.Interfaces
{
    public interface IOperacoesService : IGenericService<Operacoes>
    {
        Task<List<Operacoes>> GetOperacoes(Contexto context);
        Task<Operacoes> GetOperacaoById(string id, Contexto context);
        Task<eResult> ValidaModelState(string id, Operacoes operacoes);
        bool OperacoesExists(string id, Contexto context);
        Task<eResult> Create(Operacoes operacao, Ativos ativos, Contexto context);
        Task<eResult> GetEdit(string id, Contexto context);
        Task<eResult> PostEdit(string id, Operacoes operacoes, Contexto context);
        Task<eResult> Delete(string id, Contexto context);
        Task<eResult> DeleteConfirmed(string id, Contexto context);
    }
}
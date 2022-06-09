using WealthMVC.Models;

namespace WealthMVC.Interfaces
{
    public interface IOperacoesRepository
    {
        Task<IEnumerable<Operacoes>> ListaOperacoes();
    }
}

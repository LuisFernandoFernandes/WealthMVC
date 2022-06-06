using WealthMVC.Models;

namespace WealthMVC.Services.Interfaces
{
    public interface IAtivosService : IGenericService<Ativos>
    {
        //public IEnumerable<Ativos> ListaAtivos();
        public Task<IEnumerable<Ativos>> ListaAtivos();
    }
}
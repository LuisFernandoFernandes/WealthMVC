using WealthMVC.Models;

namespace WealthMVC.Interfaces
{
    public interface IAtivosRepository
    {
        //public IEnumerable<Ativos> ListaAtivos();
        public Task<IEnumerable<Ativos>> ListaAtivos();
    }
}
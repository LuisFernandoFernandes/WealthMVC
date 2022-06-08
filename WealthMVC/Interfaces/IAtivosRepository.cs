using WealthMVC.Models;

namespace WealthMVC.Interfaces
{
    public interface IAtivosRepository
    {
        public Task<IEnumerable<Ativos>> ListaAtivos();
    }
}
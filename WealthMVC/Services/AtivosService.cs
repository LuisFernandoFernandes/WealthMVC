using WealthMVC.Models;

namespace WealthMVC.Services
{
    public class AtivosService : GenericService<Ativos>, IAtivosService
    {
        public AtivosService(GenericService<Ativos> service) : base(service)
        {
        }
    }
}

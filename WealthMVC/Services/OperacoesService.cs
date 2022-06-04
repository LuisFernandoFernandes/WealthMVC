using WealthMVC.Models;

namespace WealthMVC.Services
{
    public class OperacoesService : GenericService<Operacoes>, IOperacoesServicer
    {
        public OperacoesService(GenericService<Operacoes> service) : base(service)
        {
        }
    }
}

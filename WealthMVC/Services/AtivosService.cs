using Microsoft.AspNetCore.Mvc.ModelBinding;
using Wealth.Tools.database;
using WealthMVC.Models;
using WealthMVC.Services.Interfaces;

namespace WealthMVC.Services
{
    public class AtivosService : GenericService<Ativos>, IAtivosService
    {
        private IValidationDictionary _validatonDictionary;
        private Contexto _contexto;

        public AtivosService(IValidationDictionary validatonDictionary, Contexto contexto, GenericService<Ativos> service) : base(service)
        {
            _validatonDictionary = validatonDictionary;
            _contexto = contexto;
        }


    }
}

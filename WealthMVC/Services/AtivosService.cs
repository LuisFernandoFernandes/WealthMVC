using Microsoft.AspNetCore.Mvc.ModelBinding;
using Wealth.Tools.database;
using WealthMVC.Interfaces;
using WealthMVC.Models;
using WealthMVC.Repository;
using WealthMVC.Services.Interfaces;
using WealthMVC.Tools.wrapper;

namespace WealthMVC.Services
{
    public class AtivosService : GenericService<Ativos>, IAtivosService
    {
        private IValidationDictionary _validatonDictionary;
        private AtivosRepository _repository;
        //private ModelStateWrapper _modelStateWrapper;

        //public AtivosService(ModelStateWrapper modelStateWrapper, AtivosRepository repository)
        //{
        //    _modelStateWrapper = modelStateWrapper;
        //    _repository = repository;
        //}

        public AtivosService(IValidationDictionary validatonDictionary, AtivosRepository repository)
        {
            _validatonDictionary = validatonDictionary;
            _repository = repository;
        }

        public async Task<IEnumerable<Ativos>> ListaAtivos()
        {
            return await _repository.ListaAtivos();
        }

        //IEnumerable<Ativos> IAtivosService.ListaAtivos()
        //{
        //    return _repository.ListaAtivos();
        //}
    }
}

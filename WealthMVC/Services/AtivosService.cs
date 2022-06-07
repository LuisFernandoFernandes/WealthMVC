using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Wealth.Tools.database;
using WealthMVC.Enums;
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

        ModelStateDictionary modelState = new ModelStateDictionary();

        public AtivosService(IValidationDictionary validatonDictionary, AtivosRepository repository)
        {
            _validatonDictionary = validatonDictionary;
            _repository = repository;

        }

        public async Task<IEnumerable<Ativos>> ListaAtivos()
        {
            return await _repository.ListaAtivos();
        }

        public async Task<eBoolean> Create(Ativos ativos, Contexto context)
        {

            ativos.Codigo = ativos.Codigo.ToUpper();
            ativos.Id = ValidaId(ativos.Id);
            if (modelState.IsValid)
            {

                context.Add(ativos);
                context.SaveChangesAsync();
                return eBoolean.Sim;
            }
            return eBoolean.Nao;
        }

        public async Task<eBoolean> GetEdit(string id, Contexto context)
        {
            if (id == null || context.Ativos == null)
            {
                return eBoolean.Nao;
            }

            var ativos = await context.Ativos.FindAsync(id);
            if (ativos == null)
            {
                return eBoolean.Nao;
            }
            return eBoolean.Sim;
        }

        public async Task<eBoolean> PostEdit(string id, Ativos ativos, Contexto context)
        {

            if (id != ativos.Id) { return eBoolean.Nao; }


            if (modelState.IsValid)
            {
                try
                {
                    context.Update(ativos);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtivosExists(ativos.Id, context)) return eBoolean.Nao;
                    else throw;
                }
                return eBoolean.Sim;
            }
            return eBoolean.Nao;
        }

        public async Task<eBoolean> ValidaModelState(string id, Ativos ativos, Contexto context)
        {
            return (id == ativos.Id && !modelState.IsValid) ? eBoolean.Nao : eBoolean.Sim;
        }

        #region Ativos Exists
        public bool AtivosExists(string id, Contexto context)
        {
            return (context.Ativos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}

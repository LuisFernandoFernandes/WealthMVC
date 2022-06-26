using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        #region Variáveis
        private IValidationDictionary _validatonDictionary;
        private AtivosRepository _repository;

        ModelStateDictionary modelState = new ModelStateDictionary();
        #endregion

        #region Construtor
        public AtivosService(IValidationDictionary validatonDictionary, AtivosRepository repository)
        {
            _validatonDictionary = validatonDictionary;
            _repository = repository;
        }
        #endregion

        #region Lista Ativos
        public async Task<IEnumerable<Ativos>> GetAtivos()
        {
            return await _repository.ListaAtivos();
        }
        #endregion

        #region Create
        public async Task<eResult> Create(Ativos ativos, Contexto context)
        {

            ativos.Id = ValidaId(ativos.Id);
            ativos.Codigo = AdequaTicker(ativos.Codigo);
            if (modelState.IsValid)
            {


                context.Add(ativos);
                context.SaveChangesAsync();
                return eResult.Ok;
            }
            return eResult.Invalid;
        }
        #endregion

        #region Get Edit
        public async Task<eResult> GetEdit(string id, Contexto context)
        {
            if (id == null || context.Ativos == null)
            {
                return eResult.NotFound;
            }

            var ativos = await context.Ativos.FindAsync(id);
            if (ativos == null)
            {
                return eResult.NotFound;
            }
            return eResult.Ok;
        }
        #endregion

        #region Post Edit
        public async Task<eResult> PostEdit(string id, Ativos ativos, Contexto context)
        {

            if (id != ativos.Id) { return eResult.NotFound; }

            try
            {
                context.Update(ativos);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtivosExists(ativos.Id, context)) return eResult.NotFound;
                else throw;
            }
            return eResult.Ok;
        }
        #endregion

        #region Delete
        public async Task<eResult> Delete(string id, Contexto context)
        {
            if (id == null || _repository == null) { return eResult.NotFound; }

            var ativos = await context.Ativos.FirstOrDefaultAsync(a => a.Id == id);

            if (ativos == null) { return eResult.NotFound; }

            return eResult.Ok;
        }
        #endregion

        #region Delete Confirmed
        public async Task<eResult> DeleteConfirmed(string id, Contexto context)
        {
            if (context.Ativos == null) { return eResult.Invalid; }

            var ativos = await context.Ativos.FindAsync(id);

            if (ativos != null) { context.Ativos.Remove(ativos); }

            await context.SaveChangesAsync();

            return eResult.Ok;
        }
        #endregion

        #region Get Ativo By Id
        public async Task<Ativos> GetAtivoById(string id, Contexto context)
        {
            return await context.Ativos.FirstOrDefaultAsync(a => a.Id == id);
        }
        #endregion

        #region Valida Model State
        public async Task<eResult> ValidaModelState(string id, Ativos ativos)
        {
            return (id == ativos.Id && !modelState.IsValid) ? eResult.Invalid : eResult.Ok;
        }
        #endregion

        #region Ativos Exists
        public bool AtivosExists(string id, Contexto context)
        {
            return (context.Ativos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion

        private string AdequaTicker(string ticker)
        {
            ticker = ticker.ToUpper();
            return (Char.IsNumber(ticker[ticker.Length - 1])) ? ticker + ".SA" : ticker;
        }
    }
}

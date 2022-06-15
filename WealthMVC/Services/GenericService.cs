using Microsoft.AspNetCore.Mvc.ModelBinding;
using Wealth.Tools.database;
using WealthMVC.Models;
using WealthMVC.Services.Interfaces;

namespace WealthMVC.Services
{
    public class GenericService<T> : IGenericService<T>
    {

        #region Variáveis

        public Contexto _context;
        public IValidationDictionary _validatonDictionary;

        public ModelStateDictionary _modelState = new ModelStateDictionary();
        #endregion


        #region Construtor
        //public GenericService(IValidationDictionary validationDictionary, ModelStateDictionary modelState)
        //{
        //    _validatonDictionary = validationDictionary;
        //    _modelState = modelState;
        //}

        public GenericService()
        {
        }
        #endregion

        #region ValidaId
        public string ValidaId(string id)
        {
            return id = (string.IsNullOrEmpty(id) || id.Length < 1) ? GeraId() : id;
        }
        #endregion

        #region GeraId
        public string GeraId()
        {
            Random random = new Random();

            var caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
        Enumerable.Repeat(caracteres, 30)
                  .Select(s => s[random.Next(s.Length)])
                  .ToArray());
            return result;
        }
        #endregion
    }
}

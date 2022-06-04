using WealthMVC.Models;

namespace WealthMVC.Services
{
    public class GenericService<T>
    {
        #region Construtor
        public GenericService(GenericService<T> service)
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

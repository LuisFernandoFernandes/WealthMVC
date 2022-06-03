using Microsoft.EntityFrameworkCore;
using WealthMVC.Models;

namespace Wealth.Tools.database
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Operacoes> Operacoes { get; set; }

        public DbSet<WealthMVC.Models.Ativos>? Ativos { get; set; }

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
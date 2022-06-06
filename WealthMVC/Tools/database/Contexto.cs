using Microsoft.EntityFrameworkCore;
using WealthMVC.Models;

namespace Wealth.Tools.database
{
    public class Contexto : DbContext
    {
        #region Construtor
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected Contexto(DbContextOptions contextOptions)
        : base(contextOptions)
        {
        }
        #endregion

        #region DbSet
        public DbSet<Operacoes> Operacoes { get; set; }
        public DbSet<Ativos> Ativos { get; set; }
        public DbSet<Portifolio> Portifolio { get; set; }
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
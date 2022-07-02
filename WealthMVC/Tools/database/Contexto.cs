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

    }
}
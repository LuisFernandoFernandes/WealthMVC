using Microsoft.EntityFrameworkCore;
using Wealth.Tools.database;
using WealthMVC.Interfaces;
using WealthMVC.Models;

namespace WealthMVC.Repository
{
    public class AtivosRepository : IAtivosRepository
    {
        private readonly DbSet<Ativos> _context;

        public AtivosRepository(DbSet<Ativos> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ativos>> ListaAtivos()
        {
            return await _context.ToListAsync();
        }
    }
}

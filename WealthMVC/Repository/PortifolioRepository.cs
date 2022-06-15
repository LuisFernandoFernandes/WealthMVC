using Microsoft.EntityFrameworkCore;
using WealthMVC.Interfaces;
using WealthMVC.Models;

namespace WealthMVC.Repository
{
    public class PortifolioRepository : IPortifolioRepository
    {
        private readonly DbSet<Portifolio> _context;

        public PortifolioRepository(DbSet<Portifolio> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Portifolio>> ListaPortifolio()
        {
            return await _context.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WealthMVC.Interfaces;
using WealthMVC.Models;

namespace WealthMVC.Repository
{
    public class OperacoesRepository : IOperacoesRepository
    {
        private readonly DbSet<Operacoes> _context;

        public OperacoesRepository(DbSet<Operacoes> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Operacoes>> ListaOperacoes()
        {
            return await _context.ToListAsync();
        }
    }
}

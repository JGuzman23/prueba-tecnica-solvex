using ATours.Entities.Interfaces;
using ATours.Entities.POCOEntities;
using ATours.Entities.Specifications;
using ATours.Repositories.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATours.Repositories.EFCore.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        readonly AToursContext _context;

        public ReservaRepository(AToursContext context)
        {
            _context = context;
        }

        public void Create(Reserva reserva)
        {
            _context.Add(reserva);
        }
        public async Task<List<Reserva>> GetByClient(int id)
        {
            var result = await _context.Reserva.Where(x=>x.ClienteId == id).ToListAsync();
            return result;
            
        }

        public IEnumerable<Reserva> GetOrderBySpecification(Specification<Reserva> specifications)
        {
            var ExpressionDelegate = specifications.Expression.Compile();
            return _context.Reserva.Where(ExpressionDelegate);

        }
    }
}

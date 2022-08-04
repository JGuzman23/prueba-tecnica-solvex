using ATours.Entities.Interfaces;
using ATours.Repositories.EFCore.DataContext;
using System.Threading.Tasks;

namespace ATours.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AToursContext _context;

        public UnitOfWork(AToursContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return  _context.SaveChangesAsync();
           
        }
    }
}

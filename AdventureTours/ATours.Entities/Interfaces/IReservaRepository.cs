using ATours.Entities.POCOEntities;
using ATours.Entities.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Entities.Interfaces
{
    public interface IReservaRepository
    {
        void Create(Reserva reserva);
        Task<List<Reserva>> GetByClient(int id);
        IEnumerable<Reserva> GetOrderBySpecification(Specification<Reserva> specifications);

    }
}

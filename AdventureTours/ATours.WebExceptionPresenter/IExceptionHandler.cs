using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ATours.WebExceptionPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}

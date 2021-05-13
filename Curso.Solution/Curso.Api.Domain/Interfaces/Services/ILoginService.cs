using Curso.Api.Domain.Entities;
using System.Threading.Tasks;

namespace Curso.Api.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}

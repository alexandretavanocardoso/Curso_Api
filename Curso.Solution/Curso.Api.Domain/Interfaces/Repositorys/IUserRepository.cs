using Curso.Api.Domain.Entities;
using System.Threading.Tasks;

namespace Curso.Api.Domain.Interfaces.Repositorys
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}

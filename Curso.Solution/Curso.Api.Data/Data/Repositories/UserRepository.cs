using Curso.Api.Data.Data.Context;
using Curso.Api.Domain.Entities;
using Curso.Api.Domain.Interfaces.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Curso.Api.Data.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dataSet;

        public UserRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return await _dataSet.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}

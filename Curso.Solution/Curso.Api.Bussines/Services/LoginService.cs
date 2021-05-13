using Curso.Api.Domain.Entities;
using Curso.Api.Domain.Interfaces.Repositorys;
using Curso.Api.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Api.Bussines.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            var baseUser = new UserEntity();

            if(user != null && string.IsNullOrWhiteSpace(user.Email))
                baseUser = await _userRepository.FindByLogin(user.Email);

            return baseUser;
        }
    }
}

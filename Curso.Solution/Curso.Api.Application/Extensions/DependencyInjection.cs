using Curso.Api.Bussines.Services;
using Curso.Api.Data.Data;
using Curso.Api.Data.Data.Repositories;
using Curso.Api.Domain.Interfaces;
using Curso.Api.Domain.Interfaces.Repositorys;
using Curso.Api.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.Api.Application.Extensions
{
    public static class DependencyInjection
    {
        public static void AddServicesDepency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
        }

        public static void AddRepositoryDepency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

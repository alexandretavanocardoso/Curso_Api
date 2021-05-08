using Curso.Api.Bussines.Services;
using Curso.Api.Data.Data;
using Curso.Api.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.Api.Application.Extensions
{
    public static class DependencyInjection
    {
        public static void AddServicesDepency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddRepositoryDepency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}

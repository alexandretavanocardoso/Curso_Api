using Curso.Api.Data.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Curso.Api.Application.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfig(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<MyContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("Persist Security Info=False;Initial Catalog=API;Server=DESKTOP-HSS7F3O\\SQLEXPRESS;Integrated Security=true;")));

            services.AddControllers();
        }

        public static void UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

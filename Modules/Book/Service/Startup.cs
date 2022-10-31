using System.Reflection;
using LibraryManagement.Book.Application;
using LibraryManagement.Book.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryManagement.Book.Service
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddApplication();
            services.AddAutoMapper(typeof(ServiceProfile));
            services.AddDbContext<BookDbContext>(option =>
            {
                option.UseMySQL("Server=localhost;Database=mydb;Port=3307;Persist Security Info=True;User=root;Password=abed123;"
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<BookService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Grpc Book Service.");
                });
            });
        }
    }
}

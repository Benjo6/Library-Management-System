using System.Reflection;
using LibraryManagement.Author.Application;
using LibraryManagement.Author.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryManagement.Author.Service
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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<AuthorDbContext>(option =>
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
                endpoints.MapGrpcService<AuthorService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Grpc Author Service.");
                });
            });
        }
    }
}

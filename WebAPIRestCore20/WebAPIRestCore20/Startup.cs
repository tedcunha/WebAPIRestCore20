using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPIRestCore20.Model.Context;
using WebAPIRestCore20.Business;
using WebAPIRestCore20.Business.Implementations;
using WebAPIRestCore20.Repository;
using WebAPIRestCore20.Repository.Implementations;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;

namespace WebAPIRestCore20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));

            services.AddMvc();

            services.AddApiVersioning();

            //Swagger
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "RESTfull API com ASP .NET Core 2.0",
                        Version = "v1"
                    });
            });
            // Fim Swagger

            // Bussines
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplem>();

            //Repository
            services.AddScoped<IPessoaRepository, PessoaRepositoryImplem>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Conf. Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/Swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            // Fim Swegger

            app.UseMvc();
        }
    }
}

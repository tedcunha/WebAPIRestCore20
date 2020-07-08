using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPIRestCore20.Model.Context;
using WebAPIRestCore20.Business;
using WebAPIRestCore20.Business.Implementations;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using WebAPIRestCore20.Repository.Generic;
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using WebAPIRestCore20.HyperMidia;
using WebAPIRestCore20.Repository;
using WebAPIRestCore20.Repository.Implementations;
using WebAPIRestCore20.Security.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Microsoft.AspNetCore.Authorization;

namespace WebAPIRestCore20
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region "Conexão connection"
            var connection = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
            #endregion

            #region "Autenticação"
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfigurations")
                ).Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
            #endregion

            // Forma Horiginal
            //services.AddMvc();

            #region "XML e JASON"
            // Para poder voltar na requisição formato XML ou Jason
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = false;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();
            #endregion

            #region "HATOAS"
            //HATOAS
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PessoaEnricher());
            services.AddSingleton(filterOptions);
            #endregion

            services.AddApiVersioning();

            #region "Swagger"
            //Swagger
            //services.AddSwaggerGen(c => 
            //{
            //    c.SwaggerDoc("v1",
            //        new Info
            //        {
            //            Title = "RESTfull API com ASP .NET Core 2.0",
            //            Version = "v1"
            //        });
            //});
            // Fim Swagger
            #endregion

            #region "Injeção de Dependencia"
            // Bussines
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplem>();
            services.AddScoped<ILivrosBusiness, LivrosBusinessImplem>();
            services.AddScoped<ILoginBusiness, LoginBusinessImplem>();
            services.AddScoped<IUsuariosBusiness, UsuariosBusinessImplem>();

            //Repsitory
            services.AddScoped<ILoginRepository,LoginRepositoryImpl> ();
            services.AddScoped<IPessoasRepository, PessoasRepositoryImpl> ();


            //Repository Generico
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Conf. Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c => {
            //    c.SwaggerEndpoint("/swagger/v1/Swagger.json", "My API V1");
            //});

            //var option = new RewriteOptions();
            //option.AddRedirect("^$", "swagger");
            //app.UseRewriter(option);
            // Fim Swegger

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "DefaultApi",
                        template: "{controller=values}/{id?}"
                    );
            });
        }
    }
}

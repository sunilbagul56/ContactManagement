﻿
namespace ContactManagement.API
{
    using ContactManagement.API.Filters;
    using ContactManagement.Domain.Interfaces;
    using ContactManagement.Engine.Engines;
    using ContactManagement.Storage.DbContexts;
    using ContactManagement.Storage.Repository;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using Swashbuckle.AspNetCore.Swagger;

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
            services.AddMvc(options =>
            {
                //Register filters
                options.Filters.AddService<CustomExceptionFilterAttribute>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Define service scope
            services.AddSingleton<ILogger>(x => Log.Logger);
            services.AddScoped<CustomExceptionFilterAttribute>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactEngine, ContactEngine>();
            services.AddEntityFrameworkSqlServer().
                AddDbContext<ContactDbContext>(option => option.UseSqlServer(Configuration["ConnectionStrings:ContactManagement.DefaultConnection"]));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info() { Title = "Contact Management API" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                //http://localhost/ContactManagement.API/api/contact/GetAllContacts
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Management V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

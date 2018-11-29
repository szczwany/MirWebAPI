using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MirWebAPI.Data;
using MirWebAPI.Helpers;
using MirWebAPI.Models;
using MirWebAPI.Repositories;
using System.Net;

namespace MirWebAPI
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
            services.AddDbContext<DataContext>(context => context.UseSqlServer(Configuration.GetConnectionString("test")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddTransient<Seed>();
            services.AddScoped<IRepository<Map>, MapsRepository>();
            services.AddScoped<IRepository<Monster>, MonstersRepository>();
            services.AddScoped<IRepository<Npc>, NpcsRepository>();
            services.AddScoped<IRepository<Floor>, FloorsRepository>();
            services.AddScoped<IRepository<Role>, RolesRepository>();
            services.AddScoped<IRepository<Skill>, SkillsRepository>();
            services.AddScoped<IRepository<Quest>, QuestsRepository>();
            services.AddScoped<IMapTypesRepository, MapTypesRepository>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });

                // app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // app.UseHttpsRedirection();

            // Seed maps and monster data to database
            // seeder.SeedRoles();
            // seeder.SeedSkills();
            // seeder.SeedMaps();
            // seeder.SeedMapTypes();
            // seeder.SeedMonsters();
            // seeder.SeedNpcs();
            // seeder.SeedFloors();
            // seeder.SeedQuests();

            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
        }
    }
}

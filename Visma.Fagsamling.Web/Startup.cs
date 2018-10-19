using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Visma.Fagsamling.Business;
using Visma.Fagsamling.Domain;
using Visma.Fagsamling.Domain.Interfaces;
using Visma.Fagsamling.External.EnTur;
using Visma.Fagsamling.External.Interfaces;
using Visma.Fagsamling.External.Oslobysykkel;

namespace Visma.Fagsamling.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddHttpClient(Constants.HttpClients.OsloBysykkelClient, client =>
            {
                throw new Exception("Legg til nøkkel for Oslo bysykkel: https://developer.oslobysykkel.no/api");
                client.DefaultRequestHeaders.Add("Client-Identifier", "<Key>");
                client.BaseAddress = new Uri("https://oslobysykkel.no/api/v1/");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IOslobysykkelClient, OslobysykkelClient>();
            services.AddScoped<ITripClient, TripClient>();
            services.AddScoped<IStationLogic, StationLogic>();
            services.AddScoped<ITripLogic, TripLogic>();
            services.AddScoped<ITopographicplaceClient, PlaceClient>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

namespace ProductsSearch.Web
{
    using DataAccess;
    using DataAccess.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using ProductsSearch.Infrastructure;
    using ProductsSearch.Web.Services;
    using System;
    using System.Net.Http;

    /// <summary>
    /// Startup Project class
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IMongoDataAccess, MongoDataAccess>();
            services.AddSingleton(s =>
            {
                return MappingProfileConfig.Activate();
            });
            services.AddScoped<IProductsService, ProductsService>();

            ApiSettings apiSettings = new ApiSettings();
            Configuration.Bind("ApiSettings", apiSettings);

            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(apiSettings.BaseUrl)
            });

            services.Configure<ApiSettings>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
